// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2018 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful? 
// https://www.paypal.me/cyotek

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal partial class SettingsDialog : BaseForm
  {
    #region Instance Fields

    private readonly List<EchoScheduledTaskOptions> _jobs;

    #endregion

    #region Public Constructors

    public SettingsDialog()
    {
      InitializeComponent();

      _jobs = new List<EchoScheduledTaskOptions>();
    }

    public SettingsDialog(JobManager manager)
      : this()
    {
      this.Manager = manager;
    }

    #endregion

    #region Overridden Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      foreach (EchoScheduledTaskOptions job in this.Manager)
      {
        _jobs.Add(job.Clone());
      }

      try
      {
        startWithWindowsCheckBox.Checked = StartupManager.IsRegisteredForStartup();
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to obtain startup status. {0}", ex.GetBaseException().Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      foreach (EchoScheduledTaskOptions job in _jobs)
      {
        this.ListJob(job);
      }
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      this.Activate();
    }

    #endregion

    #region Public Properties

    public JobManager Manager { get; set; }

    #endregion

    #region Private Members

    private void ApplySettings()
    {
      List<EchoScheduledTaskOptions> matchingJobs;

      // update registry
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
        MessageBox.Show(string.Format("Failed to process startup changes. {0}", ex.GetBaseException().Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      // first remove deleted jobs
      matchingJobs = this.Manager.Where(j => _jobs.All(j2 => j.Id != j2.Id)).ToList();
      foreach (EchoScheduledTaskOptions options in matchingJobs)
      {
        this.Manager.KillJob(options.Id);
      }

      // remove and re-add any changed jobs
      foreach (EchoScheduledTaskOptions options in _jobs)
      {
        EchoScheduledTaskOptions originalJob;

        originalJob = this.Manager.SingleOrDefault(j => j.Id == options.Id);
        if (originalJob != null && !options.Equals(originalJob))
        {
          this.Manager.KillJob(originalJob.Id);

          this.Manager.Schedule(options);
        }
      }

      // now add the new jobs
      matchingJobs = _jobs.Where(j => this.Manager.All(j2 => j.Id != j2.Id)).ToList();
      foreach (EchoScheduledTaskOptions options in matchingJobs)
      {
        this.Manager.Schedule(options);
      }

      this.Manager.Save();
    }

    private void ListJob(EchoScheduledTaskOptions job)
    {
      ListViewItem item;
      string key;

      key = job.Id.ToString();

      if (!containersListView.Items.ContainsKey(key))
      {
        item = new ListViewItem
               {
                 Name = key
               };

        for (int i = 0; i < containersListView.Columns.Count; i++)
        {
          item.SubItems.Add(string.Empty);
        }

        containersListView.Items.Add(item);
      }
      else
      {
        item = containersListView.Items[key];
      }

      item.SubItems[0].Text = job.AccountName;
      item.SubItems[1].Text = job.ContainerName;
      item.SubItems[2].Text = job.LocalPath;
      item.ForeColor = job.Enabled ? SystemColors.WindowText : SystemColors.GrayText;
    }

    private void ShowJobSettings(EchoScheduledTaskOptions options)
    {
      using (Form dialog = new AccountPropertiesDialog(options))
      {
        dialog.Text = string.Format("{0} Account", _jobs.Contains(options) ? "Edit" : "Add");

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          if (!_jobs.Contains(options))
          {
            _jobs.Add(options);
          }

          this.ListJob(options);
        }
      }
    }

    #endregion

    #region Event Handlers

    private void addButton_Click(object sender, EventArgs e)
    {
      this.ShowJobSettings(new EchoScheduledTaskOptions());
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void containersListView_ItemActivate(object sender, EventArgs e)
    {
      editButton.PerformClick();
    }

    private void containersListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      bool enabled;

      enabled = containersListView.SelectedItems.Count != 0;
      editButton.Enabled = enabled;
      removeButton.Enabled = enabled;
    }

    private void editButton_Click(object sender, EventArgs e)
    {
      EchoScheduledTaskOptions options;

      options = _jobs.Find(j => j.Id == new Guid(containersListView.SelectedItems[0].Name));
      if (options != null)
      {
        this.ShowJobSettings(options);
      }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      this.ApplySettings();

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void removeButton_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to remove the selected jobs?", "Remove Jobs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        List<EchoScheduledTaskOptions> jobsToRemove;

        jobsToRemove = containersListView.SelectedItems.Cast<ListViewItem>().Select(i => _jobs.Find(j => j.Id == new Guid(i.Name))).ToList();

        foreach (EchoScheduledTaskOptions job in jobsToRemove)
        {
          _jobs.Remove(job);
          containersListView.Items.RemoveByKey(job.Id.ToString());
        }
      }
    }

    #endregion
  }
}
