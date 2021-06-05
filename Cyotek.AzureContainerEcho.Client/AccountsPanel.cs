// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.AzureContainerEcho.Client
{
  internal partial class AccountsPanel : SettingsPanelBase
  {
    #region Public Constructors

    public AccountsPanel()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Methods

    public override void LoadSettings(ContainerEchoSettings settings)
    {
      accountCollectionEditor.Items = settings.Jobs.Clone();

      base.LoadSettings(settings);
    }

    public override void SaveSettings(ContainerEchoSettings settings)
    {
      settings.Jobs.Clear();
      settings.Jobs.AddRange(accountCollectionEditor.Items);

      base.SaveSettings(settings);
    }

    #endregion Public Methods
  }
}