using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Cyotek.TaskScheduler;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cyotek.AzureContainerEcho
{
  public class EchoScheduledTask : ScheduledTask
  {
    #region Constructors

    public EchoScheduledTask()
    {
      this.RepeatingInterval = TimeSpan.FromMinutes(15);
    }

    #endregion

    #region Overridden Properties

    public override bool IsRepeating
    {
      get { return true; }
    }

    #endregion

    #region Overridden Members

    protected override void ExecuteJob()
    {
      EchoScheduledTaskOptions options;

      options = (EchoScheduledTaskOptions)this.Data["options"];

      if (options.Enabled)
      {
        StorageCredentials credentials;
        CloudStorageAccount account;
        CloudBlobClient client;
        CloudBlobContainer container;
        IList<ICloudBlob> pendingRemote;
        IDictionary<string, ICloudBlob> remoteItems;

        credentials = new StorageCredentials(options.AccountName, options.AccountKey);
        account = new CloudStorageAccount(credentials, true);
        client = account.CreateCloudBlobClient();
        container = client.GetContainerReference(options.ContainerName);

        Debug.Print("Running task '{0}'", this.Name);

        // create the container if it doesn't already exist
        container.CreateIfNotExists();

        // get all the remote items first so we don't have to query them twice
        remoteItems = new Dictionary<string, ICloudBlob>(StringComparer.InvariantCultureIgnoreCase);

        foreach (IListBlobItem blobItem in container.ListBlobs())
        {
          ICloudBlob blob;

          blob = blobItem as ICloudBlob;
          if (blob != null)
          {
            remoteItems.Add(blob.Name, blob);
          }
        }

        // download
        pendingRemote = this.GetMissingOrChangedRemoteBlobs(remoteItems, options.LocalPath, options.CheckForNewFilesOnly, options.LastRun);
        if (pendingRemote.Any() && !this.IsCancelPending)
          this.DownloadPendingBlobs(pendingRemote, options);

        //  upload
        if (options.AllowUploads && !this.IsCancelPending)
        {
          IList<string> pendingLocal;

          pendingLocal = this.GetMissingOrChangedLocalBlobs(remoteItems, options.LocalPath);
          if (pendingLocal.Any() && !this.IsCancelPending)
            this.UploadPendingBlobs(pendingLocal, container);
        }

        // mark the timestamp, so we can use this in future if required
        options.LastRun = DateTime.UtcNow;

        Debug.Print("Completed task '{0}'", this.Name);
      }
    }

    #endregion

    #region Members

    private void DownloadPendingBlobs(IEnumerable<ICloudBlob> pendingBlobs, EchoScheduledTaskOptions options)
    {
      foreach (ICloudBlob fileBlob in pendingBlobs)
      {
        string localFileName;

        Debug.Print("Downloading '{0}'", fileBlob.Name);

        localFileName = Path.Combine(options.LocalPath, fileBlob.Name);

        using (FileStream stream = File.OpenWrite(localFileName))
          fileBlob.DownloadToStream(stream);

        if (fileBlob.Properties.LastModified.HasValue)
          File.SetLastWriteTime(localFileName, fileBlob.Properties.LastModified.Value.UtcDateTime);

        if (this.IsCancelPending)
          break;
      }
    }

    private Guid GetBlobHash(ICloudBlob fileBlob)
    {
      return new Guid(Convert.FromBase64String(fileBlob.Properties.ContentMD5));
    }

    private Guid GetMd5HashFromFile(string fileName)
    {
      byte[] hash;

      using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        MD5 md5 = new MD5CryptoServiceProvider();
        hash = md5.ComputeHash(file);
      }

      return new Guid(hash);
    }

    private IList<string> GetMissingOrChangedLocalBlobs(IDictionary<string, ICloudBlob> remoteItems, string localPath)
    {
      IList<string> results;

      results = new List<string>();

      foreach (string fileName in Directory.GetFiles(localPath))
      {
        ICloudBlob fileBlob;

        // ReSharper disable once AssignNullToNotNullAttribute
        remoteItems.TryGetValue(Path.GetFileName(fileName), out fileBlob);

        if (fileBlob != null && string.IsNullOrEmpty(fileBlob.Properties.ContentMD5))
          fileBlob.FetchAttributes();

        if (fileBlob == null || string.IsNullOrEmpty(fileBlob.Properties.ContentMD5) || this.GetMd5HashFromFile(fileName) != this.GetBlobHash(fileBlob))
        {
          results.Add(fileName);

          if (this.IsCancelPending)
            break;
        }
      }

      Debug.Print("Found {0} missing or changed local files.", results.Count);

      return results;
    }

    private IList<ICloudBlob> GetMissingOrChangedRemoteBlobs(IEnumerable<KeyValuePair<string, ICloudBlob>> remoteItems, string localPath, bool checkForNewFilesOnly, DateTime? oldestModificationTime)
    {
      IList<ICloudBlob> results;

      results = new List<ICloudBlob>();

      foreach (KeyValuePair<string, ICloudBlob> pair in remoteItems)
      {
        bool shouldDownloadBlob;
        string localFileName;
        ICloudBlob fileBlob;

        fileBlob = pair.Value;
        localFileName = Path.Combine(localPath, fileBlob.Name);
        shouldDownloadBlob = false;

        // check to see if we should download the blob
        // I've split this up into a much more verbose if block to make it easier to follow expanding options
        if (checkForNewFilesOnly)
        {
          if (oldestModificationTime.HasValue && fileBlob.Properties.LastModified.HasValue && fileBlob.Properties.LastModified.Value > oldestModificationTime.Value)
          {
            // this file has been created/modified since the last time this job was run, so we'll download it
            shouldDownloadBlob = true;
          }
        }
        else
        {
          if (!File.Exists(localFileName))
          {
            // the file is missing from the local machine so download
            shouldDownloadBlob = true;
          }
          else
          {
            Guid remoteHash;

            // compare hashes to see if the file has been modified
            remoteHash = !string.IsNullOrEmpty(fileBlob.Properties.ContentMD5) ? this.GetBlobHash(fileBlob) : Guid.Empty;
            shouldDownloadBlob = remoteHash != this.GetMd5HashFromFile(localFileName);
          }
        }

        if (shouldDownloadBlob)
        {
          results.Add(fileBlob);
        }

        if (this.IsCancelPending)
          break;
      }

      Debug.Print("Found {0} missing or changed remote blobs.", results.Count);

      return results;
    }

    private void UploadPendingBlobs(IEnumerable<string> fileNames, CloudBlobContainer container)
    {
      foreach (string fileName in fileNames)
      {
        FileInfo fileInfo;
        CloudBlockBlob fileBlob;
        string mimeType;

        fileInfo = new FileInfo(fileName);
        fileBlob = container.GetBlockBlobReference(fileInfo.Name);

        Debug.Print("Uploading '{0}'", fileBlob.Name);

        // upload the core data
        using (FileStream stream = File.OpenRead(fileInfo.FullName))
          fileBlob.UploadFromStream(stream);

        // update the mimetype, if one was available, otherwise just leave it as is
        mimeType = MimeHelpers.GetMimeTypeFromExtension(fileInfo.Extension);
        if (!string.IsNullOrEmpty(mimeType))
        {
          fileBlob.FetchAttributes();
          fileBlob.Properties.ContentType = mimeType;
          fileBlob.SetProperties();
        }

        // check to see if something has requested the task be cancelled and break out if so
        if (this.IsCancelPending)
          break;
      }
    }

    #endregion
  }
}
