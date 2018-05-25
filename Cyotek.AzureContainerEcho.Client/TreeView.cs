// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2018 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful? 
// https://www.paypal.me/cyotek

using System;

// Enabling shell styles for the ListView and TreeView controls in C#
// http://cyotek.com/blog/enabling-shell-styles-for-the-listview-and-treeview-controls-in-csharp

namespace Cyotek.Windows.Forms
{
  internal class TreeView : System.Windows.Forms.TreeView
  {
    #region Overridden Methods

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
      {
        NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
        this.ShowLines = false;
      }
      else
      {
        this.ShowLines = true;
      }
    }

    #endregion
  }
}
