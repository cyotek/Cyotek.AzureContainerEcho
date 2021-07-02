// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License. See LICENSE.txt for the full text.

// Found this example useful?
// https://www.paypal.me/cyotek

using Cyotek.TaskScheduler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Cyotek.AzureContainerEcho
{
  public class JobManager : IDisposable, IEnumerable<EchoScheduledTaskOptions>
  {
    #region Private Fields

    private readonly List<EchoScheduledTaskOptions> _jobData;

    private readonly ITaskScheduler _scheduler;

    private bool _enabled;

    private ContainerEchoSettings _settings;

    #endregion Private Fields

    #region Public Constructors

    public JobManager()
    {
      _settings = new ContainerEchoSettings();
      _settings.Jobs.CollectionChanged += this.JobsCollectionChangedEventHandler;

      _jobData = new List<EchoScheduledTaskOptions>();

      _scheduler = TaskScheduleManager.CreateScheduler("AzureContainerEcho");

      // HACK: Duplication of events for passthrough
      _scheduler.TaskStarted += this.SchedulerTaskStartedHandler;
      _scheduler.TaskCompleted += this.SchedulerTaskCompletedHandler;
      _scheduler.TaskCancelled += this.SchedulerTaskCancelledHandler;
      _scheduler.TaskException += this.SchedulerTaskExceptionHandler;
    }

    #endregion Public Constructors

    #region Private Destructors

    /// <summary>
    /// Finalizes an instance of the <see cref="JobManager" /> class.
    /// </summary>
    ~JobManager()
    {
      this.Dispose(false);
    }

    #endregion Private Destructors

    #region Public Events

    /// <summary>
    /// Occurs when the Enabled property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler EnabledChanged;

    public event EventHandler<ScheduledTaskEventArgs> TaskCancelled;

    public event EventHandler<ScheduledTaskEventArgs> TaskCompleted;

    public event EventHandler<ScheduledTaskExceptionEventArgs> TaskException;

    public event EventHandler<ScheduledTaskEventArgs> TaskStarted;

    #endregion Public Events

    #region Public Properties

    [Category("")]
    [DefaultValue("")]
    public bool Enabled
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

    public ContainerEchoSettings Settings
    {
      get => _settings;
      set
      {
        if (!object.ReferenceEquals(_settings, value))
        {
          if (_settings != null)
          {
            this.KillAllJobs();
            _settings.Jobs.CollectionChanged -= this.JobsCollectionChangedEventHandler;
          }

          _settings = value;

          if (_settings != null)
          {
            _settings.Jobs.CollectionChanged += this.JobsCollectionChangedEventHandler;

            this.Schedule(_settings.Jobs);
          }
        }
      }
    }

    #endregion Public Properties

    #region Public Methods

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
      return (EchoScheduledTask)_scheduler.SingleOrDefault(j => ((EchoScheduledTaskOptions)j.Data["options"]).Id == id);
    }

    public IEnumerable<IScheduledTask> GetJobs() => _scheduler;

    public void KillJob(Guid id)
    {
      EchoScheduledTask job;

      job = this.GetJob(id);

      if (job != null)
      {
        this.KillJob(job);
      }
    }

    public void Schedule(EchoScheduledTaskOptions options)
    {
      if (options.Enabled)
      {
        IScheduledTask job;

#if DEBUG
        System.Diagnostics.Debug.WriteLine("Scheduling: " + options.Id);
#endif

        job = new EchoScheduledTask {Name = options.ContainerName, RepeatingInterval = options.Interval};
        job.Data["Options"] = options;

        _scheduler.Add(job);

        _jobData.Add(options);
      }
    }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    #endregion Public Methods

    #region Protected Methods

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
          _scheduler.Stop();
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
        _scheduler.Start();
      }
      else
      {
        _scheduler.Stop();
      }

      handler = this.EnabledChanged;

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="TaskCancelled" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskCancelled(ScheduledTaskEventArgs e)
    {
      EventHandler<ScheduledTaskEventArgs> handler;

      handler = this.TaskCancelled;

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="TaskCompleted" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskCompleted(ScheduledTaskEventArgs e)
    {
      EventHandler<ScheduledTaskEventArgs> handler;

      handler = this.TaskCompleted;

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="TaskException" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskException(ScheduledTaskExceptionEventArgs e)
    {
      EventHandler<ScheduledTaskExceptionEventArgs> handler;

      handler = this.TaskException;

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="TaskStarted" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTaskStarted(ScheduledTaskEventArgs e)
    {
      EventHandler<ScheduledTaskEventArgs> handler;

      handler = this.TaskStarted;

      handler?.Invoke(this, e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void JobsCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          this.Schedule(e.NewItems);
          break;

        case NotifyCollectionChangedAction.Remove:
          this.KillJobs(e.OldItems);
          break;

        case NotifyCollectionChangedAction.Replace:
          this.KillJobs(e.OldItems);
          this.Schedule(e.NewItems);
          break;

        case NotifyCollectionChangedAction.Move:
          // no-op
          break;

        case NotifyCollectionChangedAction.Reset:
          this.KillAllJobs();
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void KillAllJobs()
    {
      IScheduledTask[] jobs;

      jobs = this.GetJobs().ToArray();

      for (int i = 0; i < jobs.Length; i++)
      {
        this.KillJob((EchoScheduledTask)jobs[i]);
      }
    }

    private void KillJob(EchoScheduledTask job)
    {
#if DEBUG
      System.Diagnostics.Debug.WriteLine("Removing: " + ((EchoScheduledTaskOptions)job.Data["Options"]).Id);
#endif

      if (job.InProgress)
      {
        job.Cancel();
      }

      _scheduler.Remove(job);

      _jobData.Remove((EchoScheduledTaskOptions)job.Data["options"]);
    }

    private void KillJobs(IList items)
    {
      for (int i = 0; i < items.Count; i++)
      {
        this.KillJob(((EchoScheduledTaskOptions)items[i]).Id);
      }
    }

    private void Schedule(IList items)
    {
      for (int i = 0; i < items.Count; i++)
      {
        this.Schedule((EchoScheduledTaskOptions)items[i]);
      }
    }

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
      this.OnTaskException(e);
    }

    private void SchedulerTaskStartedHandler(object sender, ScheduledTaskEventArgs e)
    {
      this.OnTaskStarted(e);
    }

    #endregion Private Methods
  }
}