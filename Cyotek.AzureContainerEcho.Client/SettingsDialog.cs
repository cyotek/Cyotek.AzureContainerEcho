// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

using Cyotek.AzureContainerEcho.Client.Properties;
using Cyotek.Demo.Windows.Forms;
using Cyotek.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal partial class SettingsDialog : BaseForm
  {
    #region Private Fields

    private ContainerEchoSettings _settings;

    #endregion Private Fields

    #region Public Constructors

    public SettingsDialog()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ContainerEchoSettings Settings
    {
      get => _settings;
      set => _settings = value;
    }

    #endregion Public Properties

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.Icon = Resources.ApplicationIcon;

      // selecting event isn't called on first load
      this.TabList_Selected(tabList, new TabListEventArgs(tabList.SelectedPage, tabList.SelectedIndex, TabListAction.Selected));
    }

    #endregion Protected Methods

    #region Private Methods

    private void AddPage<T>(TabListPage host)
      where T : UserControl, new()
    {
      T control;

      control = new T()
      {
        Dock = DockStyle.Fill
      };

      if (control is SettingsPanelBase settingsPanel)
      {
        settingsPanel.LoadSettings(_settings);
      }

      host.Controls.Add(control);
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private IEnumerable<SettingsPanelBase> GetSettingsPanels()
    {
      foreach (TabListPage page in tabList.TabListPages)
      {
        if (page.Controls.Count == 1 && page.Controls[0] is SettingsPanelBase settingsPanel)
        {
          yield return settingsPanel;
        }
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      this.SaveSettings();

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void SaveSettings()
    {
      foreach (SettingsPanelBase settingsPanel in this.GetSettingsPanels())
      {
        settingsPanel.SaveSettings(_settings);
      }
    }

    private void TabList_Selected(object sender, TabListEventArgs e)
    {
      TabListPage page;

      page = e.TabListPage;

      if (page?.Controls.Count == 0)
      {
        if (object.ReferenceEquals(page, accountsTabListPage))
        {
          this.AddPage<AccountsPanel>(page);
        }
        else if (object.ReferenceEquals(page, settingsTabListPage))
        {
          this.AddPage<SettingsPanel>(page);
        }
        else if (object.ReferenceEquals(page, aboutTabListPage))
        {
          this.AddPage<AboutPanel>(page);
        }
        else if (object.ReferenceEquals(page, logTabListPage))
        {
          this.AddPage<LogViewerPanel>(page);
        }
      }
    }

    private void WebLinkLabel_Click(object sender, EventArgs e)
    {
      AboutPanel.OpenCyotekHomePage();
    }

    #endregion Private Methods
  }
}