// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful? 
// https://www.paypal.me/cyotek

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Cyotek.TaskScheduler;

namespace Cyotek.AzureContainerEcho
{
  public class EchoScheduledTask : ScheduledTask
  {
    #region Public Constructors

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

    #region Overridden Methods

    protected override void ExecuteJob()
    {
      EchoScheduledTaskOptions options;

      options = (EchoScheduledTaskOptions)this.Data["options"];

      if (options.Enabled)
      {
        BlobContainerClient container;
        IList<BlobItem> pendingRemote;
        IDictionary<string, BlobItem> remoteItems;

        container = new BlobContainerClient(options.GetConnectionString(), options.ContainerName);

        Debug.Print("Running task '{0}'", this.Name);

        // create the container if it doesn't already exist
        container.CreateIfNotExists();

        // get all the remote items first so we don't have to query them twice
        remoteItems = new Dictionary<string, BlobItem>(StringComparer.InvariantCultureIgnoreCase);

        foreach (BlobItem blobItem in container.GetBlobs())
        {
          remoteItems.Add(blobItem.Name, blobItem);
        }

        // download
        pendingRemote = this.GetMissingOrChangedRemoteBlobs(remoteItems, options.LocalPath, options.CheckForNewFilesOnly, options.LastRun);
        if (pendingRemote.Any() && !this.IsCancelPending)
        {
          this.DownloadPendingBlobs(container, pendingRemote, options);
        }

        //  upload
        if (options.AllowUploads && !this.IsCancelPending)
        {
          IList<string> pendingLocal;

          pendingLocal = this.GetMissingOrChangedLocalBlobs(remoteItems, options.LocalPath);
          if (pendingLocal.Any() && !this.IsCancelPending)
          {
            this.UploadPendingBlobs(pendingLocal, container);
          }
        }

        // mark the timestamp, so we can use this in future if required
        options.LastRun = DateTime.UtcNow;

        Debug.Print("Completed task '{0}'", this.Name);
      }
    }


    #endregion

    #region Private Members

    private void DownloadPendingBlobs(BlobContainerClient container, IEnumerable<BlobItem> pendingBlobs, EchoScheduledTaskOptions options)
    {
      foreach (BlobItem fileBlob in pendingBlobs)
      {
        BlobClient blobClient;
        string localFileName;

        Debug.Print("Downloading '{0}'", fileBlob.Name);

        blobClient = container.GetBlobClient(fileBlob.Name);
        localFileName = Path.Combine(options.LocalPath, fileBlob.Name);

        using (FileStream stream = File.OpenWrite(localFileName))
        {
          blobClient.DownloadTo(stream);
        }

        if (this.GetMd5HashFromFile(localFileName) != this.GetBlobHash(fileBlob))
        {
          throw new InvalidDataException(string.Format("Hash of local file '{0}' does not match remote hash.", localFileName));
        }

        if (fileBlob.Properties.LastModified.HasValue)
        {
          File.SetLastWriteTime(localFileName, fileBlob.Properties.LastModified.Value.UtcDateTime);
        }

        if (options.DeleteAfterDownload)
        {
          Debug.Print("Deleting '{0}'", fileBlob.Name);
          blobClient.Delete();
        }

        if (this.IsCancelPending)
        {
          break;
        }
      }
    }

    private Guid GetBlobHash(BlobItem fileBlob)
    {
      return new Guid(fileBlob.Properties.ContentHash);
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

    private IList<string> GetMissingOrChangedLocalBlobs(IDictionary<string, BlobItem> remoteItems, string localPath)
    {
      IList<string> results;

      results = new List<string>();

      foreach (string fileName in Directory.GetFiles(localPath))
      {
        BlobItem fileBlob;

        // ReSharper disable once AssignNullToNotNullAttribute
        remoteItems.TryGetValue(Path.GetFileName(fileName), out fileBlob);

        if (fileBlob == null || this.GetMd5HashFromFile(fileName) != this.GetBlobHash(fileBlob))
        {
          results.Add(fileName);

          if (this.IsCancelPending)
          {
            break;
          }
        }
      }

      Debug.Print("Found {0} missing or changed local files.", results.Count);

      return results;
    }

    private IList<BlobItem> GetMissingOrChangedRemoteBlobs(IEnumerable<KeyValuePair<string, BlobItem>> remoteItems, string localPath, bool checkForNewFilesOnly, DateTime? oldestModificationTime)
    {
      IList<BlobItem> results;

      results = new List<BlobItem>();

      foreach (KeyValuePair<string, BlobItem> pair in remoteItems)
      {
        bool shouldDownloadBlob;
        string localFileName;
        BlobItem fileBlob;

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
          shouldDownloadBlob = !File.Exists(localFileName) || this.GetBlobHash(fileBlob) != this.GetMd5HashFromFile(localFileName);
        }

        if (shouldDownloadBlob)
        {
          results.Add(fileBlob);
        }

        if (this.IsCancelPending)
        {
          break;
        }
      }

      Debug.Print("Found {0} missing or changed remote blobs.", results.Count);

      return results;
    }

    private void UploadPendingBlobs(IEnumerable<string> fileNames, BlobContainerClient container)
    {
      foreach (string fileName in fileNames)
      {
        FileInfo fileInfo;
        BlobClient fileBlob;
        string mimeType;

        fileInfo = new FileInfo(fileName);
        fileBlob = container.GetBlobClient(fileInfo.Name);
        mimeType = MimeHelpers.GetMimeTypeFromExtension(fileInfo.Extension);

        Debug.Print("Uploading '{0}'", fileBlob.Name);

        // upload the core data
        using (FileStream stream = File.OpenRead(fileInfo.FullName))
        {
          fileBlob.Upload(stream, new BlobHttpHeaders { ContentType = mimeType });
        }

        // check to see if something has requested the task be cancelled and break out if so
        if (this.IsCancelPending)
        {
          break;
        }
      }
    }

    #endregion
  }
}
