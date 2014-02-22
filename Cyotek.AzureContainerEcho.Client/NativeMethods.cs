using System;
using System.Runtime.InteropServices;

namespace Cyotek.Windows.Forms
{
  // http://cyotek.com/blog/enabling-shell-styles-for-the-listview-and-treeview-controls-in-csharp

  internal static class NativeMethods
  {
    #region Public Class Members

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    #endregion
  }
}
