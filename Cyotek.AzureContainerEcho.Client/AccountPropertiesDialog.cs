using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal partial class AccountPropertiesDialog : BaseForm
  {
    #region Public Constructors

    public AccountPropertiesDialog()
    {
      InitializeComponent();
    }

    public AccountPropertiesDialog(EchoScheduledTaskOptions options)
      : this()
    {
      this.Options = options;
      accountNameTextBox.Text = options.AccountName;
      accessKeyTextBox.Text = options.AccountKey;
      containerTextBox.Text = options.ContainerName;
      localPathTextBox.Text = options.LocalPath;
      minutesNumericUpDown.Value = Math.Max(minutesNumericUpDown.Minimum, Math.Min(minutesNumericUpDown.Maximum, (decimal)options.Interval.TotalMinutes));
      allowUploadsCheckBox.Checked = options.AllowUploads;
      newFilesOnlyCheckBox.Checked = options.CheckForNewFilesOnly;
      enabledCheckBox.Checked = options.Enabled;
      deleteAfterDownloadCheckBox.Checked = options.DeleteAfterDownload;
    }

    #endregion

    #region Private Class Properties

    private EchoScheduledTaskOptions Options { get; set; }

    #endregion

    #region Private Members

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

    private bool ValidateOptions()
    {
      string message;
      string accountName;
      string accountKey;
      string container;
      string localPath;

      accountName = accountNameTextBox.Text;
      accountKey = accessKeyTextBox.Text;
      container = containerTextBox.Text;
      localPath = localPathTextBox.Text;

      if (string.IsNullOrWhiteSpace(accountName))
      {
        message = "Please enter the Azure storage account name.";
      }
      else if (string.IsNullOrWhiteSpace(accountKey))
      {
        message = "Please enter the Azure storage access key.";
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

    #endregion

    #region Event Handlers

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void localPathBrowseButton_Click(object sender, EventArgs e)
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

    private void localPathExploreButton_Click(object sender, EventArgs e)
    {
      this.OpenFolderInExplorer(localPathTextBox.Text);
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      if (!this.ValidateOptions())
      {
        this.DialogResult = DialogResult.None;
      }
      else
      {
        this.Options.AccountName = accountNameTextBox.Text;
        this.Options.AccountKey = accessKeyTextBox.Text;
        this.Options.ContainerName = containerTextBox.Text;
        this.Options.LocalPath = localPathTextBox.Text;
        this.Options.Interval = TimeSpan.FromMinutes((double)minutesNumericUpDown.Value);
        this.Options.AllowUploads = allowUploadsCheckBox.Checked;
        this.Options.CheckForNewFilesOnly = newFilesOnlyCheckBox.Checked;
        this.Options.Enabled = enabledCheckBox.Checked;
        this.Options.DeleteAfterDownload = deleteAfterDownloadCheckBox.Checked;

        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void testConnectionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

    #endregion
  }
}
