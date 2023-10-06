// Azure Container Echo

// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2018 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful? 
// https://www.paypal.me/cyotek

using System;
using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal static class Program
  {
    #region Private Class Members

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new ApplicationContext());
    }

    #endregion
  }
}
