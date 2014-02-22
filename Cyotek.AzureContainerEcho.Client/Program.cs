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
