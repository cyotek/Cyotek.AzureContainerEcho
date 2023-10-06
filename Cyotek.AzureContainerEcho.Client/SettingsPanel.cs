// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

using System;
using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal partial class SettingsPanel : SettingsPanelBase
  {
    #region Public Constructors

    public SettingsPanel()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Methods

    public override void LoadSettings(ContainerEchoSettings settings)
    {
      startWithWindowsCheckBox.Checked = StartupManager.IsRegisteredForStartup();
      logDatesAsUtcCheckBox.Checked = settings.LogDatesAsUtc;

      base.LoadSettings(settings);
    }

    public override void SaveSettings(ContainerEchoSettings settings)
    {
      settings.LogDatesAsUtc = logDatesAsUtcCheckBox.Checked;

      this.UpdateStartupSetting();

      base.SaveSettings(settings);
    }

    #endregion Public Methods

    #region Private Methods

    private void UpdateStartupSetting()
    {
      try
      {
        if (StartupManager.IsRegisteredForStartup() != startWithWindowsCheckBox.Checked)
        {
          if (startWithWindowsCheckBox.Checked)
          {
            StartupManager.RegisterStartupApplication();
          }
          else
          {
            StartupManager.UnregisterStartupApplication();
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to process startup changes. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    #endregion Private Methods
  }
}