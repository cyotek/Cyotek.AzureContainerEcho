using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cyotek.AzureContainerEcho.Client
{
  internal static class StartupManager
  {
    #region Public Class Members

    public static bool IsRegisteredForStartup()
    {
      return IsRegisteredForStartup(Application.ProductName);
    }

    public static bool IsRegisteredForStartup(string applicationName)
    {
      return IsRegisteredForStartup(applicationName, false);
    }

    public static bool IsRegisteredForStartup(string applicationName, bool applyToAllUsers)
    {
      RegistryKey hive;
      RegistryKey registryKey;

      hive = applyToAllUsers ? Registry.LocalMachine : Registry.CurrentUser;
      registryKey = hive.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);

      return registryKey.GetValueNames().Any(n => n == applicationName);
    }

    public static void RegisterStartupApplication()
    {
      RegisterStartupApplication(Application.ProductName, string.Concat("\"", Application.ExecutablePath, "\""), false);
    }

    public static void RegisterStartupApplication(string applicationName, string program, bool applyToAllUsers)
    {
      RegisterStartupApplicationImpl(applicationName, program, true, applyToAllUsers);
    }

    public static void UnregisterStartupApplication()
    {
      UnregisterStartupApplication(Application.ProductName, false);
    }

    public static void UnregisterStartupApplication(string applicationName, bool applyToAllUsers)
    {
      RegisterStartupApplicationImpl(applicationName, null, false, applyToAllUsers);
    }

    #endregion

    #region Private Class Members

    private static void RegisterStartupApplicationImpl(string applicationName, string program, bool register, bool applyToAllUsers)
    {
      RegistryKey hive;
      RegistryKey registryKey;

      hive = applyToAllUsers ? Registry.LocalMachine : Registry.CurrentUser;
      registryKey = hive.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

      if (register)
      {
        registryKey.SetValue(applicationName, program);
      }
      else
      {
        registryKey.DeleteValue(applicationName, false);
      }
    }

    #endregion
  }
}
