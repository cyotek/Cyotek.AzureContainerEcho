using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cyotek.AzureContainerEcho
{
  [Serializable]
  public class EchoScheduledTaskOptions : ICloneable, IEquatable<EchoScheduledTaskOptions>
  {
    #region Constructors

    public EchoScheduledTaskOptions()
    {
      this.Enabled = true;
      this.Id = Guid.NewGuid();
    }

    #endregion

    #region Properties

    public string AccountKey { get; set; }

    public string AccountName { get; set; }

    public bool AllowUploads { get; set; }

    public string ContainerName { get; set; }

    public Guid Id { get; set; }

    public TimeSpan Interval { get; set; }

    public string LocalPath { get; set; }

    public bool CheckForNewFilesOnly { get; set; }

    public DateTime? LastRun { get; set; }

    public bool Enabled { get; set; }

    #endregion

    #region Members

    public EchoScheduledTaskOptions Clone()
    {
      return (EchoScheduledTaskOptions)this.MemberwiseClone();
    }

    public bool Equals(EchoScheduledTaskOptions obj)
    {
      return obj != null && this.Id == obj.Id && this.AccountName == obj.AccountName && this.AccountKey == obj.AccountKey && this.ContainerName == obj.ContainerName && this.LocalPath == obj.LocalPath && this.AllowUploads == obj.AllowUploads && this.CheckForNewFilesOnly == obj.CheckForNewFilesOnly && this.Enabled == obj.Enabled && this.Interval == obj.Interval;
    }

    #endregion

    #region ICloneable Members

    object ICloneable.Clone()
    {
      return this.Clone();
    }

    #endregion

    public bool DoesContainerExist()
    {
      StorageCredentials credentials;
      CloudStorageAccount account;
      CloudBlobClient client;
      CloudBlobContainer container;
      bool result;

      credentials = new StorageCredentials(this.AccountName, this.AccountKey);
      account = new CloudStorageAccount(credentials, true);
      client = account.CreateCloudBlobClient();
      client.GetServiceProperties(); // this bit validates that the connection settings are valid

      container = client.GetContainerReference(this.ContainerName);

      result = container.Exists();

      return result;
    }
  }
}
