// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal partial class AccountCollectionEditor : UserControl
  {
    #region Private Fields

    private EchoScheduledTaskOptionsCollection _items;

    private EchoScheduledTaskOptions _selectedItem;

    private EchoScheduledTaskOptions[] _selectedItems;

    private bool _skipChangeEvents;

    #endregion Private Fields

    #region Public Constructors

    public AccountCollectionEditor()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public EchoScheduledTaskOptionsCollection Items
    {
      get => _items;
      set
      {
        if (!object.ReferenceEquals(_items, value))
        {
          _items = value;

          this.Populate();
        }
      }
    }

    #endregion Public Properties

    #region Private Methods

    private void AddButton_Click(object sender, EventArgs e)
    {
      this.ShowJobSettings(new EchoScheduledTaskOptions());
    }

    private void AddItem(EchoScheduledTaskOptions item)
    {
      ListViewItem listViewItem;

      listViewItem = this.CreateListViewItem(item);

      this.Populate(item, listViewItem);

      containersListView.Items.Add(listViewItem);
    }

    private void ContainersListView_ItemActivate(object sender, EventArgs e)
    {
      editButton.PerformClick();
    }

    private void ContainersListView_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      if (!_skipChangeEvents)
      {
        ListViewItem listViewItem;
        EchoScheduledTaskOptions item;

        listViewItem = e.Item;
        item = (EchoScheduledTaskOptions)listViewItem.Tag;

        item.Enabled = listViewItem.Checked;

        this.Populate(item, listViewItem);
      }
    }

    private void ContainersListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      selectionTimer.Stop();
      selectionTimer.Start();
    }

    private ListViewItem CreateListViewItem(EchoScheduledTaskOptions item)
    {
      ListViewItem listViewItem;

      listViewItem = new ListViewItem
      {
        Tag = item
      };

      for (int j = 0; j < containersListView.Columns.Count; j++)
      {
        listViewItem.SubItems.Add(string.Empty);
      }

      return listViewItem;
    }

    private void DuplicateButton_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < _selectedItems.Length; i++)
      {
        EchoScheduledTaskOptions clone;

        clone = new EchoScheduledTaskOptions(_selectedItems[i]) { Id = Guid.NewGuid() };

        this.AddItem(clone);
      }
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
      if (_selectedItem != null)
      {
        this.ShowJobSettings(_selectedItem);
      }
    }

    private void Populate()
    {
      containersListView.BeginUpdate();
      containersListView.Items.Clear();

      if (_items != null)
      {
        _skipChangeEvents = true;

        for (int i = 0; i < _items.Count; i++)
        {
          this.AddItem(_items[i]);
        }

        _skipChangeEvents = false;
      }

      containersListView.EndUpdate();
    }

    private void Populate(EchoScheduledTaskOptions item, ListViewItem listViewItem)
    {
      listViewItem.ForeColor = item.Enabled
        ? SystemColors.WindowText
        : SystemColors.GrayText;
      listViewItem.SubItems[0].Text = item.Name;
      listViewItem.SubItems[1].Text = item.GetConnectionString();
      listViewItem.SubItems[2].Text = item.ContainerName;
      listViewItem.SubItems[3].Text = item.LocalPath;
      listViewItem.Checked = item.Enabled;
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to remove the selected items?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        EchoScheduledTaskOptions[] items;
        int[] indexes;

        items = (EchoScheduledTaskOptions[])_selectedItems.Clone();

        indexes = new int[items.Length];
        containersListView.SelectedIndices.CopyTo(indexes, 0);

        for (int i = 0; i < items.Length; i++)
        {
          _items.Remove(items[i]);
        }

        for (int i = indexes.Length; i > 0; i--)
        {
          containersListView.Items.RemoveAt(indexes[i - 1]);
        }
      }
    }

    private void SelectionTimer_Tick(object sender, EventArgs e)
    {
      bool one;
      bool many;

      selectionTimer.Stop();

      one = containersListView.FocusedItem != null;
      many = containersListView.SelectedIndices.Count > 1;

      removeButton.Enabled = one || many;
      editButton.Enabled = one;
      duplicateButton.Enabled = one || many;

      if (one || many)
      {
        _selectedItem = (EchoScheduledTaskOptions)containersListView.FocusedItem?.Tag;
        _selectedItems = new EchoScheduledTaskOptions[containersListView.SelectedIndices.Count];
        for (int i = 0; i < containersListView.SelectedIndices.Count; i++)
        {
          _selectedItems[i] = (EchoScheduledTaskOptions)containersListView.Items[containersListView.SelectedIndices[i]].Tag;
        }
      }
      else
      {
        _selectedItem = null;
        _selectedItems = null;
      }
    }

    private void ShowJobSettings(EchoScheduledTaskOptions options)
    {
      using (Form dialog = new AccountPropertiesDialog(options))
      {
        dialog.Text = string.Format("{0} Account", _items.Contains(options) ? "Edit" : "Add");

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          if (!_items.Contains(options))
          {
            this.AddItem(options);
          }
          else
          {
            this.UpdateSelection(options);
          }
        }
      }
    }

    private void UpdateSelection(EchoScheduledTaskOptions item)
    {
      foreach (ListViewItem listViewItem in containersListView.Items)
      {
        if (listViewItem.Tag != null && object.ReferenceEquals(listViewItem.Tag, item))
        {
          this.Populate(item, listViewItem);
          break;
        }
      }
    }

    #endregion Private Methods
  }
}