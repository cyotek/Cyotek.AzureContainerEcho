// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Cyotek.AzureContainerEcho
{
  public class EchoScheduledTaskOptionsCollection : KeyedCollection<Guid, EchoScheduledTaskOptions>, INotifyCollectionChanged
  {
    #region Public Events

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion Public Events

    #region Public Methods

    public void AddRange(IEnumerable<EchoScheduledTaskOptions> items)
    {
      foreach (EchoScheduledTaskOptions item in items)
      {
        this.Add(item);
      }
    }

    public EchoScheduledTaskOptionsCollection Clone()
    {
      EchoScheduledTaskOptionsCollection clone;

      clone = new EchoScheduledTaskOptionsCollection();

      for (int i = 0; i < this.Count; i++)
      {
        clone.Add(this[i].Clone());
      }

      return clone;
    }

    public EchoScheduledTaskOptions[] ToArray()
    {
      EchoScheduledTaskOptions[] results;

      results = new EchoScheduledTaskOptions[this.Count];
      this.Items.CopyTo(results, 0);

      return results;
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void ClearItems()
    {
      base.ClearItems();

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    protected override Guid GetKeyForItem(EchoScheduledTaskOptions item)
    {
      return item.Id;
    }

    protected override void InsertItem(int index, EchoScheduledTaskOptions item)
    {
      base.InsertItem(index, item);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
    }

    protected virtual void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
      NotifyCollectionChangedEventHandler handler;

      handler = this.CollectionChanged;

      handler?.Invoke(this, e);
    }

    protected override void RemoveItem(int index)
    {
      EchoScheduledTaskOptions oldItem;

      oldItem = this[index];

      base.RemoveItem(index);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
    }

    protected override void SetItem(int index, EchoScheduledTaskOptions item)
    {
      EchoScheduledTaskOptions oldItem;

      oldItem = this[index];

      base.SetItem(index, item);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, oldItem, index));
    }

    #endregion Protected Methods
  }
}