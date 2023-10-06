// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful?
// https://www.paypal.me/cyotek

using Cyotek.AzureContainerEcho.Client.Properties;
using Cyotek.Demo.Windows.Forms;
using Cyotek.TaskScheduler;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Creating long running Windows Forms applications without a start-up form
// https://www.cyotek.com/blog/creating-long-running-windows-forms-applications-without-a-start-up-form

namespace Cyotek.AzureContainerEcho.Client
{
  internal class ApplicationContext : TrayIconApplicationContext
  {
    #region Private Fields

    private readonly JobManager _jobManager;

    private string _logFileName;

    private Stream _logStream;

    private TextWriter _logWriter;

    private SettingsDialog _settingsDialog;

    private string _settingsFileName;

    #endregion Private Fields

    #region Public Constructors

    public ApplicationContext()
    {
      _jobManager = new JobManager();
      _jobManager.TaskStarted += this.JobManagerTaskStartedHandler;
      _jobManager.TaskCompleted += this.JobManagerTaskCompletedHandler;
      _jobManager.TaskCancelled += this.JobManagerTaskCancelledHandler;
      _jobManager.TaskException += this.JobManagerTaskExceptionHandler;

      this.InitializeLog();
      this.LoadSettings();

      this.SetIcon();

      _jobManager.Enabled = true;
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_logWriter != null)
        {
          _logWriter.Flush();
          _logWriter.Dispose();
          _logWriter = null;
        }

        if (_logStream != null)
        {
          _logStream.Dispose();
          _logStream = null;
        }

        _jobManager?.Dispose();
      }

      base.Dispose(disposing);
    }

    protected override void OnInitializeContextMenu()
    {
      this.ContextMenu.Items.Add("&Settings...", Resources.Settings, this.SettingsContextMenuClickHandler).Font = new Font(this.ContextMenu.Font, FontStyle.Bold);
      this.ContextMenu.Items.Add("Open &Log", null, this.OpenLogContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&Run Now", Resources.Run, this.RunNowContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("E&xit", null, this.ExitContextMenuClickHandler);

      base.OnInitializeContextMenu();
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

    private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ExitThread();
    }

    private void InitializeLog()
    {
      _logFileName = Path.ChangeExtension(Application.ExecutablePath, ".log");

      _logStream = File.Open(_logFileName, FileMode.Append, FileAccess.Write, FileShare.Read);
      _logWriter = new StreamWriter(_logStream, Encoding.UTF8);
    }

    private void JobManagerTaskCancelledHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.Log(string.Format("Task Cancelled: {0}", e.Task.Name));

      this.SetIcon();
    }

    private void JobManagerTaskCompletedHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.Log(string.Format("Task Complete: {0}", e.Task.Name));

      this.SetIcon();
    }

    private void JobManagerTaskExceptionHandler(object sender, ScheduledTaskExceptionEventArgs e)
    {
      this.Log(string.Format("Task Failed: {0}\n{1}", e.Task.Name, e.Exception.Message));

      this.TrayIcon.ShowBalloonTip(10000, e.Task.Name, e.Exception.GetBaseException().Message, ToolTipIcon.Error);
    }

    private void JobManagerTaskStartedHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.Log(string.Format("Task Started: {0}", e.Task.Name));

      this.SetIcon();
    }

    private void LoadLegacySettings()
    {
      string fileName;

      fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "cyotek.azurecontainerecho.jobs.json");

      if (File.Exists(fileName))
      {
        Json.ParseFileInto(fileName, _jobManager.Settings.Jobs);
      }
    }

    private void LoadSettings()
    {
      _settingsFileName = Path.ChangeExtension(Application.ExecutablePath, ".json");

      if (File.Exists(_settingsFileName))
      {
        _jobManager.Settings = Json.ParseFile<ContainerEchoSettings>(_settingsFileName);
      }
      else
      {
        this.LoadLegacySettings();
      }
    }

    private void Log(string text)
    {
#if DEBUG
      System.Diagnostics.Debug.WriteLine(text);
#endif

      _logWriter.Write(_jobManager.Settings.LogDatesAsUtc ? DateTime.UtcNow : DateTime.Now);
      _logWriter.Write('\t');
      _logWriter.WriteLine(text);

      _logWriter.Flush();
    }

    private void OpenLogContextMenuClickHandler(object sender, EventArgs e)
    {
      AboutPanel.OpenUrl(_logFileName);
    }

    private void RunNowContextMenuClickHandler(object sender, EventArgs e)
    {
      foreach (IScheduledTask task in _jobManager.GetJobs())
      {
        task.Start((ITaskContext)_jobManager.Scheduler);
      }
    }

    private void SaveSettings()
    {
      Json.WriteFile(_settingsFileName, _jobManager.Settings, JsonOptions.WriteWhitespace);
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

    private void ShowSettings()
    {
      if (_settingsDialog == null)
      {
        using (_settingsDialog = new SettingsDialog
        {
          Settings = _jobManager.Settings
        })
        {
          if (_settingsDialog.ShowDialog() == DialogResult.OK)
          {
            this.SaveSettings();
          }
        }
        _settingsDialog = null;
      }
      else
      {
        _settingsDialog.Activate();
      }
    }

    #endregion Private Methods
  }
}