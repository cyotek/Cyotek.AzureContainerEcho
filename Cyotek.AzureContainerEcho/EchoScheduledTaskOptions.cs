// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful? 
// https://www.paypal.me/cyotek

using Azure.Storage.Blobs;
using System;

namespace Cyotek.AzureContainerEcho
{
  [Serializable]
  public class EchoScheduledTaskOptions : ICloneable, IEquatable<EchoScheduledTaskOptions>
  {
    #region Public Constructors

    public EchoScheduledTaskOptions()
    {
      this.Enabled = true;
      this.Id = Guid.NewGuid();
    }

    #endregion

    #region Public Properties

    public string AccountKey { get; set; }

    public string AccountName { get; set; }
    public string ConnectionString { get; set; }

    public bool AllowUploads { get; set; }

    public bool CheckForNewFilesOnly { get; set; }

    public string ContainerName { get; set; }

    public bool DeleteAfterDownload { get; set; }

    public bool Enabled { get; set; }

    public Guid Id { get; set; }

    public TimeSpan Interval { get; set; }

    public DateTime? LastRun { get; set; }

    public string LocalPath { get; set; }

    #endregion

    #region Public Members

    public string GetConnectionString()
    {
      return string.IsNullOrEmpty(this.ConnectionString)
        ? "DefaultEndpointsProtocol=https;AccountName=" + this.AccountName + ";AccountKey=" + this.AccountKey + ";EndpointSuffix=core.windows.net"
        : this.ConnectionString;
    }


    public EchoScheduledTaskOptions Clone()
    {
      return (EchoScheduledTaskOptions)this.MemberwiseClone();
    }

    public bool DoesContainerExist()
    {
      BlobContainerClient container;

      container = new BlobContainerClient(this.GetConnectionString(), this.ContainerName);

      return container.Exists().Value;
    }

    public bool Equals(EchoScheduledTaskOptions obj)
    {
      return obj != null && this.Id == obj.Id && this.AccountName == obj.AccountName && this.AccountKey == obj.AccountKey && this.ContainerName == obj.ContainerName && this.LocalPath == obj.LocalPath && this.AllowUploads == obj.AllowUploads && this.CheckForNewFilesOnly == obj.CheckForNewFilesOnly && this.Enabled == obj.Enabled && this.Interval == obj.Interval && this.DeleteAfterDownload == obj.DeleteAfterDownload;
    }

    #endregion

    #region ICloneable Members

    object ICloneable.Clone()
    {
      return this.Clone();
    }

    #endregion
  }
}
