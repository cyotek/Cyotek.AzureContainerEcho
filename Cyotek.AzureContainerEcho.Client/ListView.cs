using System;

namespace Cyotek.Windows.Forms
{
  // http://cyotek.com/blog/enabling-shell-styles-for-the-listview-and-treeview-controls-in-csharp

  internal class ListView : System.Windows.Forms.ListView
  {
    #region Overridden Methods

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
      {
        NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
      }
    }

    #endregion
  }
}
