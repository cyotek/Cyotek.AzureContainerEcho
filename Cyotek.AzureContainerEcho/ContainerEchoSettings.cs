// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Cyotek.AzureContainerEcho
{
  public class ContainerEchoSettings : INotifyPropertyChanged
  {
    #region Private Fields

    private EchoScheduledTaskOptionsCollection _jobs;

    private bool _logDatesAsUtc;

    #endregion Private Fields

    #region Public Constructors

    public ContainerEchoSettings()
    {
      _jobs = new EchoScheduledTaskOptionsCollection();
      _jobs.CollectionChanged += this.JobsCollectionChangedHandler;

      _logDatesAsUtc = true;
    }

    #endregion Public Constructors

    #region Public Events

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion Public Events

    #region Public Properties

    public EchoScheduledTaskOptionsCollection Jobs
    {
      get => _jobs;
      set
      {
        if (!object.ReferenceEquals(_jobs, value))
        {
          if (_jobs != null)
          {
            _jobs.CollectionChanged -= this.JobsCollectionChangedHandler;
          }

          _jobs = value;

          if (value != null)
          {
            value.CollectionChanged += this.JobsCollectionChangedHandler;
          }

          this.OnPropertyChanged(nameof(this.Jobs));
        }
      }
    }

    public bool LogDatesAsUtc
    {
      get => _logDatesAsUtc;
      set => this.UpdateAssignment(ref _logDatesAsUtc, value, nameof(this.LogDatesAsUtc));
    }

    #endregion Public Properties

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="PropertyChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
      PropertyChangedEventHandler handler;

      handler = this.PropertyChanged;

      handler?.Invoke(this, e);
    }

    protected void OnPropertyChanged(string propertyName)
    {
      this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    protected void UpdateAssignment<T>(ref T value, T newValue, string propertyName)
    {
      if (!EqualityComparer<T>.Default.Equals(value, newValue))
      {
        value = newValue;

        this.OnPropertyChanged(propertyName);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void JobsCollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
      this.OnPropertyChanged(nameof(this.Jobs));
    }

    #endregion Private Methods
  }
}