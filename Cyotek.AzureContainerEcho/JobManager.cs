// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho
// Copyright © 2013-2018 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful? 
// https://www.paypal.me/cyotek

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Cyotek.TaskScheduler;
using Newtonsoft.Json;

namespace Cyotek.AzureContainerEcho
{
  public class JobManager : IDisposable, IEnumerable<EchoScheduledTaskOptions>
  {
    #region Instance Fields

    private readonly List<EchoScheduledTaskOptions> _jobData;

    private readonly ITaskScheduler _scheduler;

    private bool _enabled;

    #endregion

    #region Public Constructors

    public JobManager()
    {
      _jobData = new List<EchoScheduledTaskOptions>();

      _scheduler = TaskScheduleManager.CreateScheduler("AzureContainerEcho");

      // HACK: Duplication of events for passthrough
      _scheduler.TaskStarted += this.SchedulerTaskStartedHandler;
      _scheduler.TaskCompleted += this.SchedulerTaskCompletedHandler;
      _scheduler.TaskCancelled += this.SchedulerTaskCancelledHandler;
      _scheduler.TaskException += this.SchedulerTaskExceptionHandler;
    }

    #endregion

    #region Destructors

    /// <summary>
    /// Finalizes an instance of the <see cref="JobManager" /> class.
    /// </summary>
    ~JobManager()
    {
      this.Dispose(false);
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the Enabled property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler EnabledChanged;

    public event EventHandler<ScheduledTaskEventArgs> TaskCancelled;

    public event EventHandler<ScheduledTaskEventArgs> TaskCompleted;

    public event EventHandler<ScheduledTaskExceptionEventArgs> TaskException;

    public event EventHandler<ScheduledTaskEventArgs> TaskStarted;

    #endregion

    #region Public Properties

    [Category("")]
    [DefaultValue("")]
    public virtual bool Enabled
    {
      get { return _enabled; }
      set
      {
        if (this.Enabled != value)
        {
          _enabled = value;

          this.OnEnabledChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is disposed.
    /// </summary>
    /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public bool IsDisposed { get; private set; }

    public ITaskScheduler Scheduler
    {
      get { return _scheduler; }
    }

    public string StorageFileName
    {
      get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "cyotek.AzureContainerEcho.jobs.json"); }
    }

    #endregion

    #region Public Members

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      this.Dispose(true);

      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<EchoScheduledTaskOptions> GetEnumerator()
    {
      return _jobData.GetEnumerator();
    }

    public EchoScheduledTask GetJob(Guid id)
    {
      return (EchoScheduledTask)this.Scheduler.SingleOrDefault(j => ((EchoScheduledTaskOptions)j.Data["options"]).Id == id);
    }

    public IEnumerable<IScheduledTask> GetJobs()
    {
      return this.Scheduler;
    }

    public void KillJob(Guid id)
    {
      EchoScheduledTask job;

      job = this.GetJob(id);
      if (job != null)
      {
        if (job.InProgress)
        {
          job.Cancel();
        }
        this.Scheduler.Remove(job);
        _jobData.Remove((EchoScheduledTaskOptions)job.Data["options"]);
      }
    }

    public void Load()
    {
      string fileName;

      fileName = this.StorageFileName;

      if (File.Exists(fileName))
      {
        JsonSerializer serializer;

        serializer = new JsonSerializer();

        using (Stream file = File.OpenRead(fileName))
        {
          using (TextReader reader = new StreamReader(file))
          {
            IEnumerable<EchoScheduledTaskOptions> jobs;

            jobs = (IEnumerable<EchoScheduledTaskOptions>)serializer.Deserialize(reader, typeof(IEnumerable<EchoScheduledTaskOptions>));

            _jobData.Clear();
            foreach (EchoScheduledTaskOptions job in jobs)
            {
              this.Schedule(job);
            }
          }
        }
      }
    }

    public void Save()
    {
      JsonSerializer serializer;
      JsonSerializerSettings serializerSettings;

      serializerSettings = new JsonSerializerSettings
                           {
                             Formatting = Formatting.Indented
                           };
      serializer = JsonSerializer.Create(serializerSettings);

      using (Stream file = File.Create(this.StorageFileName))
      {
        using (TextWriter writer = new StreamWriter(file))
        {
          serializer.Serialize(writer, _jobData);
        }
      }
    }

    public void Schedule(EchoScheduledTaskOptions options)
    {
      IScheduledTask job;

      job = new EchoScheduledTask
            {
              Name = options.ContainerName,
              RepeatingInterval = options.Interval
            };
      job.Data["Options"] = options;

      this.Scheduler.Add(job);

      _jobData.Add(options);
    }

    #endregion

    #region Protected Members

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
      if (!this.IsDisposed)
      {
        if (disposing)
        {
          this.Scheduler.Stop();
        }

        this.IsDisposed = true;
      }
    }

    /// <summary>
    /// Raises the <see cref="EnabledChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnEnabledChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.Enabled)
      {
        this.Scheduler.Start();
      }
      else
      {
        this.Scheduler.Stop();
      }

      handler = this.EnabledChanged;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    /// <summary>
    /// Raises the <see cref="TaskCancelled" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskCancelled(ScheduledTaskEventArgs e)
    {
      EventHandler<ScheduledTaskEventArgs> handler;

      handler = this.TaskCancelled;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    /// <summary>
    /// Raises the <see cref="TaskCompleted" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskCompleted(ScheduledTaskEventArgs e)
    {
      EventHandler<ScheduledTaskEventArgs> handler;

      handler = this.TaskCompleted;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    /// <summary>
    /// Raises the <see cref="TaskException" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskException(ScheduledTaskExceptionEventArgs e)
    {
      EventHandler<ScheduledTaskExceptionEventArgs> handler;

      handler = this.TaskException;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    /// <summary>
    /// Raises the <see cref="TaskStarted" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskStarted(ScheduledTaskEventArgs e)
    {
      EventHandler<ScheduledTaskEventArgs> handler;

      handler = this.TaskStarted;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    #endregion

    #region Private Members

    private void Log(string text)
    {
      // TODO: Log to file

      Debug.WriteLine(text);
    }

    #endregion

    #region Event Handlers

    private void SchedulerTaskCancelledHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.OnTaskCancelled(e);
    }

    private void SchedulerTaskCompletedHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.OnTaskCompleted(e);
    }

    private void SchedulerTaskExceptionHandler(object sender, ScheduledTaskExceptionEventArgs e)
    {
      this.Log(e.Exception.ToString());

      this.OnTaskException(e);
    }

    private void SchedulerTaskStartedHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.OnTaskStarted(e);
    }

    #endregion

    #region IEnumerable<EchoScheduledTaskOptions> Members

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    #endregion
  }
}
