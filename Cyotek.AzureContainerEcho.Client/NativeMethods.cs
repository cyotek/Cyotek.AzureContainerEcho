// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful?
// https://www.paypal.me/cyotek

using System;
using System.Runtime.InteropServices;

namespace Cyotek.Windows.Forms
{
  internal static class NativeMethods
  {
    #region Public Fields

    public const int IDC_HAND = 32649;

    public const int WM_SETCURSOR = 0x0020;

    #endregion Public Fields

    #region Public Methods

    [DllImport("user32.dll")]
    public static extern int LoadCursor(int hInstance, int lpCursorName);

    [DllImport("user32.dll")]
    public static extern int SetCursor(int hCursor);

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    #endregion Public Methods
  }
}