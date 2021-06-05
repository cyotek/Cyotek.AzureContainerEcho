// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful?
// https://www.paypal.me/cyotek

using Cyotek.Demo.Windows.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal partial class AccountPropertiesDialog : BaseForm
  {
    #region Private Fields

    private readonly EchoScheduledTaskOptions _options;

    #endregion Private Fields

    #region Public Constructors

    public AccountPropertiesDialog()
    {
      this.InitializeComponent();
    }

    public AccountPropertiesDialog(EchoScheduledTaskOptions options)
      : this()
    {
      _options = options;

      connectionStringTextBox.Text = options.ConnectionString;
      accountNameTextBox.Text = options.AccountName;
      accessKeyTextBox.Text = options.AccountKey;
      containerTextBox.Text = options.ContainerName;
      localPathTextBox.Text = options.LocalPath;
      minutesNumericUpDown.Value = Math.Max(minutesNumericUpDown.Minimum, Math.Min(minutesNumericUpDown.Maximum, (decimal)options.Interval.TotalMinutes));
      allowUploadsCheckBox.Checked = options.AllowUploads;
      newFilesOnlyCheckBox.Checked = options.CheckForNewFilesOnly;
      enabledCheckBox.Checked = options.Enabled;
      deleteAfterDownloadCheckBox.Checked = options.DeleteAfterDownload;
      nameTextBox.Text = options.Name;
    }

    #endregion Public Constructors

    #region Private Methods

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void LocalPathBrowseButton_Click(object sender, EventArgs e)
    {
      using (FolderBrowserDialog dialog = new FolderBrowserDialog
      {
        Description = "Select download &folder:",
        SelectedPath = localPathTextBox.Text,
        ShowNewFolderButton = true
      })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          localPathTextBox.Text = dialog.SelectedPath;
        }
      }
    }

    private void LocalPathExploreButton_Click(object sender, EventArgs e)
    {
      this.OpenFolderInExplorer(localPathTextBox.Text);
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (!this.ValidateOptions())
      {
        this.DialogResult = DialogResult.None;
      }
      else
      {
        _options.ConnectionString = connectionStringTextBox.Text;
        _options.AccountName = accountNameTextBox.Text;
        _options.AccountKey = accessKeyTextBox.Text;
        _options.ContainerName = containerTextBox.Text;
        _options.LocalPath = localPathTextBox.Text;
        _options.Interval = TimeSpan.FromMinutes((double)minutesNumericUpDown.Value);
        _options.AllowUploads = allowUploadsCheckBox.Checked;
        _options.CheckForNewFilesOnly = newFilesOnlyCheckBox.Checked;
        _options.Enabled = enabledCheckBox.Checked;
        _options.DeleteAfterDownload = deleteAfterDownloadCheckBox.Checked;
        _options.Name = nameTextBox.Text;

        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void OpenFolderInExplorer(string folderName)
    {
      if (string.IsNullOrEmpty(folderName))
      {
        MessageBox.Show("Please enter or select the path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!Directory.Exists(folderName))
      {
        MessageBox.Show(string.Format("Folder '{0}' does not exist.", folderName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        try
        {
          string program;
          string arguments;

          program = string.Format("{0}\\explorer.exe", Environment.ExpandEnvironmentVariables("%windir%"));
          arguments = string.Format("/n,\"{0}\"", folderName);

          Process.Start(program, arguments);
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Unable to start the specified program.\n\n{0}", ex.GetBaseException().Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
    }

    private void TestConnectionLinkLabel_Click(object sender, EventArgs e)
    {
      if (this.ValidateOptions())
      {
        try
        {
          bool containerExists;
          string suffix;

          this.Enabled = false;
          Application.DoEvents(); // HACK: Evil but thats what I get for being lazy

          containerExists = new EchoScheduledTaskOptions
          {
            ConnectionString = connectionStringTextBox.Text,
            AccountName = accountNameTextBox.Text,
            AccountKey = accessKeyTextBox.Text,
            ContainerName = containerTextBox.Text
          }.DoesContainerExist();

          suffix = containerExists ? "." : ", however the specified container does not exist.";

          MessageBox.Show(string.Concat("Connection successful", suffix), "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Connection failed. {0}", ex.GetBaseException().Message), "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
          this.Enabled = true;
        }
      }
    }

    private bool ValidateOptions()
    {
      string message;
      string connectionString;
      string accountName;
      string accountKey;
      string container;
      string localPath;
      bool hasConnectionString;
      bool hasCredentials;

      connectionString = connectionStringTextBox.Text;
      accountName = accountNameTextBox.Text;
      accountKey = accessKeyTextBox.Text;
      container = containerTextBox.Text;
      localPath = localPathTextBox.Text;
      hasConnectionString = !string.IsNullOrEmpty(connectionString);
      hasCredentials = !string.IsNullOrEmpty(accountName) && !string.IsNullOrEmpty(accountKey);

      if (hasConnectionString && hasCredentials)
      {
        message = "Please do not specify both a connection string and account credentials";
      }
      else if (!hasConnectionString && !hasCredentials)
      {
        message = "Please enter either a full connection string or the account key and name.";
      }
      else if (string.IsNullOrWhiteSpace(container))
      {
        message = "Please enter or select the Azure container name.";
      }
      else if (string.IsNullOrWhiteSpace(localPath))
      {
        message = "Please enter or select the local path to copy files into.";
      }
      else if (!Directory.Exists(localPath))
      {
        message = "Cannot find the specified local path.";
      }
      else
      {
        message = null;
      }

      if (!string.IsNullOrWhiteSpace(message))
      {
        MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      return string.IsNullOrEmpty(message);
    }

    #endregion Private Methods
  }
}