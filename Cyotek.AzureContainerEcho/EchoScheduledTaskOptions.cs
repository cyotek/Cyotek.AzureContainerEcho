using System;

namespace Cyotek.AzureContainerEcho
{
  [Serializable]
  public class EchoScheduledTaskOptions : ICloneable, IEquatable<EchoScheduledTaskOptions>
  {
    #region Constructors

    public EchoScheduledTaskOptions()
    {
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

    #endregion

    #region Members

    public EchoScheduledTaskOptions Clone()
    {
      return (EchoScheduledTaskOptions)this.MemberwiseClone();
    }

    public bool Equals(EchoScheduledTaskOptions obj)
    {
      return obj != null && this.Id == obj.Id && this.AccountName == obj.AccountName && this.AccountKey == obj.AccountKey && this.ContainerName == obj.ContainerName && this.LocalPath == obj.LocalPath && this.AllowUploads == obj.AllowUploads && this.CheckForNewFilesOnly == obj.CheckForNewFilesOnly;
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
