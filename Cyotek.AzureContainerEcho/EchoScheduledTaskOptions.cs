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

    public EchoScheduledTaskOptions(EchoScheduledTaskOptions copyFrom)
    {
      this.Name = copyFrom.Name;
      this.AccountKey = copyFrom.AccountKey;
      this.AccountName = copyFrom.AccountName;
      this.AllowUploads = copyFrom.AllowUploads;
      this.CheckForNewFilesOnly = copyFrom.CheckForNewFilesOnly;
      this.ConnectionString = copyFrom.ConnectionString;
      this.ContainerName = copyFrom.ContainerName;
      this.DeleteAfterDownload = copyFrom.DeleteAfterDownload;
      this.Enabled = copyFrom.Enabled;
      this.Id = copyFrom.Id;
      this.Interval = copyFrom.Interval;
      this.LastRun = copyFrom.LastRun;
      this.LocalPath = copyFrom.LocalPath;
    }

    #endregion Public Constructors

    #region Public Properties

    public string AccountKey { get; set; }

    public string AccountName { get; set; }

    public bool AllowUploads { get; set; }

    public bool CheckForNewFilesOnly { get; set; }

    public string ConnectionString { get; set; }

    public string ContainerName { get; set; }

    public bool DeleteAfterDownload { get; set; }

    public bool Enabled { get; set; }

    public Guid Id { get; set; }

    public TimeSpan Interval { get; set; }

    public DateTime? LastRun { get; set; }

    public string LocalPath { get; set; }

    public string Name { get; set; }

    #endregion Public Properties

    #region Public Methods

    public EchoScheduledTaskOptions Clone()
    {
      return new EchoScheduledTaskOptions(this);
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

    public string GetConnectionString()
    {
      return string.IsNullOrEmpty(this.ConnectionString)
        ? "DefaultEndpointsProtocol=https;AccountName=" + this.AccountName + ";AccountKey=" + this.AccountKey + ";EndpointSuffix=core.windows.net"
        : this.ConnectionString;
    }

    object ICloneable.Clone()
    {
      return this.Clone();
    }

    #endregion Public Methods
  }
}