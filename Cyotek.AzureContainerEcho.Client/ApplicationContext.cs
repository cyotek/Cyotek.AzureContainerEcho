// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2018 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful?
// https://www.paypal.me/cyotek

using Cyotek.AzureContainerEcho.Client.Properties;
using Cyotek.TaskScheduler;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// Creating long running Windows Forms applications without a start-up form
// https://www.cyotek.com/blog/creating-long-running-windows-forms-applications-without-a-start-up-form

namespace Cyotek.AzureContainerEcho.Client
{
  internal class ApplicationContext : TrayIconApplicationContext
  {
    #region Private Fields

    private readonly JobManager _jobManager;

    private readonly string _logFileName;

    private AboutDialog _aboutDialog;

    private SettingsDialog _settingsDialog;

    #endregion Private Fields

    #region Public Constructors

    public ApplicationContext()
    {
      string logPath;

      logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Cyotek\Azure Container Echo\");
      _logFileName = Path.Combine(logPath, "log.txt");

      if (!Directory.Exists(logPath))
      {
        Directory.CreateDirectory(logPath);
      }

      _jobManager = new JobManager();
      _jobManager.TaskStarted += this.JobManagerTaskStartedHandler;
      _jobManager.TaskCompleted += this.JobManagerTaskCompletedHandler;
      _jobManager.TaskCancelled += this.JobManagerTaskCancelledHandler;
      _jobManager.TaskException += this.JobManagerTaskExceptionHandler;
      _jobManager.Load();

      this.SetIcon();

      _jobManager.Enabled = true;
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);

      if (disposing && _jobManager != null)
      {
        _jobManager.Dispose();
      }
    }

    protected override void OnContextMenuOpening(CancelEventArgs e)
    {
      this.ContextMenu.Items.Add("&Settings...", Resources.Settings, this.SettingsContextMenuClickHandler).Font = new Font(this.ContextMenu.Font, FontStyle.Bold);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&Run Now", Resources.Run, this.RunNowContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("Open &Log", null, this.LogContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&About", null, this.AboutContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("E&xit", null, this.ExitContextMenuClickHandler);

      base.OnContextMenuOpening(e);
    }

    protected override void OnTrayIconDoubleClick(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.ShowSettings();
      }

      base.OnTrayIconDoubleClick(e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ShowDialog(ref _aboutDialog, null);
    }

    private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ExitThread();
    }

    private void JobManagerTaskCancelledHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.WriteLog("Task Cancelled: {0}", e.Task.Name);

      this.SetIcon();
    }

    private void JobManagerTaskCompletedHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.WriteLog("Task Complete: {0}", e.Task.Name);

      this.SetIcon();
    }

    private void JobManagerTaskExceptionHandler(object sender, ScheduledTaskExceptionEventArgs e)
    {
      this.WriteLog("Task Failed: {0}\n{1}", e.Task.Name, e.Exception.Message);

      this.TrayIcon.ShowBalloonTip(10000, e.Task.Name, e.Exception.GetBaseException().Message, ToolTipIcon.Error);
    }

    private void JobManagerTaskStartedHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.WriteLog("Task Started: {0}", e.Task.Name);

      this.SetIcon();
    }

    private void LogContextMenuClickHandler(object sender, EventArgs e)
    {
      try
      {
        Process.Start(_logFileName);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException().Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void RunNowContextMenuClickHandler(object sender, EventArgs e)
    {
      foreach (IScheduledTask task in _jobManager.GetJobs())
      {
        task.Start((ITaskContext)_jobManager.Scheduler);
      }
    }

    private void SetIcon()
    {
      Icon icon;
      string suffix;

      if (_jobManager.Any())
      {
        bool areJobsRunning;
        bool didJobsFail;

        areJobsRunning = _jobManager.GetJobs().Any(j => j.InProgress);
        didJobsFail = _jobManager.GetJobs().Any(j => j.Failed);
        icon = areJobsRunning ? Resources.SmallDownloadIcon : didJobsFail ? Resources.SmallErrorIcon : Resources.SmallIcon;
        suffix = areJobsRunning ? " - Downloading changes" : _jobManager.GetJobs().Any(j => j.IsComplete) ? " - Up to date" : string.Empty;
      }
      else
      {
        icon = Resources.SmallQueryIcon;
        suffix = " - No jobs defined";
      }

      this.TrayIcon.Icon = icon;
      this.TrayIcon.Text = string.Concat(Application.ProductName, suffix);
    }

    private void SettingsContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ShowSettings();
    }

    private void ShowDialog<T>(ref T localReference, Action<T> initialization) where T : Form, new()
    {
      if (localReference == null)
      {
        using (localReference = new T())
        {
          if (initialization != null)
          {
            initialization(localReference);
          }

          localReference.ShowDialog();
        }
        localReference = null;
      }
      else
      {
        localReference.Activate();
      }
    }

    private void ShowSettings()
    {
      this.ShowDialog(ref _settingsDialog, dialog => { dialog.Manager = _jobManager; });
    }

    private void WriteLog(string format, params object[] args)
    {
      File.AppendAllText(_logFileName, string.Concat(DateTime.UtcNow.ToShortDateString(), " ", DateTime.UtcNow.ToShortTimeString(), "\t", string.Format(format, args), Environment.NewLine));
    }

    #endregion Private Methods
  }
}