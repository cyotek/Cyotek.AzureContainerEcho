// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2018 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful? 
// https://www.paypal.me/cyotek

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Microsoft.Win32;

namespace Cyotek.AzureContainerEcho
{
  internal static class MimeHelpers
  {
    #region Constants

    private static readonly IDictionary<string, string> _mimeTypeExtensionCache;

    private static readonly object _lock = new object();

    #endregion

    #region Static Constructors

    static MimeHelpers()
    {
      _mimeTypeExtensionCache = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    #endregion

    #region Public Class Members

    public static string GetDefaultExtension(string mimeType)
    {
      string result;

      if (!_mimeTypeExtensionCache.TryGetValue(mimeType, out result))
      {
        try
        {
          RegistryKey key;
          object value;

          key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
          if (key != null)
          {
            value = key.GetValue("Extension", null);
            result = value != null ? value.ToString() : null;
          }
          else
          {
            // HACK: Nasty
            foreach (string name in Registry.ClassesRoot.GetSubKeyNames().Where(name => name[0] == '.'))
            {
              try
              {
                key = Registry.ClassesRoot.OpenSubKey(name, false);
              }
              catch (SecurityException)
              {
                key = null;
              }

              if (key != null)
              {
                value = key.GetValue("Content Type", null);
                if (value != null && value.ToString() == mimeType)
                {
                  result = name;
                  break;
                }
              }
            }
          }
        }
        catch (SecurityException)
        {
          result = null;
        }

        lock (_lock)
        {
          if (!_mimeTypeExtensionCache.ContainsKey(mimeType))
          {
            _mimeTypeExtensionCache.Add(mimeType, result);
          }
        }
      }

      return result;
    }

    public static string GetMimeType(string contentType)
    {
      string result;

      if (contentType == null)
      {
        contentType = string.Empty;
      }

      if (contentType.Contains(";"))
      {
        // TODO: Assume first or check all?
        result = contentType.Split(new[]
                                   {
                                     ";"
                                   }, StringSplitOptions.RemoveEmptyEntries)[0];
      }
      else
      {
        result = contentType;
      }

      return result.ToLowerInvariant().Trim();
    }

    public static string GetMimeTypeFromExtension(string extension)
    {
      string result;
      RegistryKey key;
      object value;

      if (!extension.StartsWith("."))
      {
        extension = "." + extension;
      }

      key = Registry.ClassesRoot.OpenSubKey(extension, false);
      value = key != null ? key.GetValue("Content Type", null) : null;
      result = value != null ? value.ToString() : null;

      return result;
    }

    public static string GetPerceivedType(string mimeType)
    {
      string result;
      string extension;

      extension = GetDefaultExtension(mimeType);
      if (!string.IsNullOrEmpty(extension))
      {
        RegistryKey key;
        object value;

        key = Registry.ClassesRoot.OpenSubKey(extension, false);
        value = key != null ? key.GetValue("PerceivedType", null) : null;
        result = value != null ? value.ToString() : null;
      }
      else
      {
        result = null;
      }

      return result;
    }

    #endregion
  }
}
