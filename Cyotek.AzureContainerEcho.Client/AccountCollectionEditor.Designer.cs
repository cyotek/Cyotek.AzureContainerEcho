
namespace Cyotek.AzureContainerEcho.Client
{
  partial class AccountCollectionEditor
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ColumnHeader accountColumnHeader;
      System.Windows.Forms.ColumnHeader containerColumnHeader;
      System.Windows.Forms.ColumnHeader pathColumnHeader;
      System.Windows.Forms.ColumnHeader nameColumnHeader;
      this.duplicateButton = new System.Windows.Forms.Button();
      this.removeButton = new System.Windows.Forms.Button();
      this.editButton = new System.Windows.Forms.Button();
      this.addButton = new System.Windows.Forms.Button();
      this.containersListView = new Cyotek.Windows.Forms.ListView();
      this.selectionTimer = new System.Windows.Forms.Timer(this.components);
      accountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      containerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      pathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // duplicateButton
      // 
      this.duplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.duplicateButton.Enabled = false;
      this.duplicateButton.Location = new System.Drawing.Point(474, 87);
      this.duplicateButton.Name = "duplicateButton";
      this.duplicateButton.Size = new System.Drawing.Size(75, 23);
      this.duplicateButton.TabIndex = 4;
      this.duplicateButton.Text = "&Duplicate";
      this.duplicateButton.UseVisualStyleBackColor = true;
      this.duplicateButton.Click += new System.EventHandler(this.DuplicateButton_Click);
      // 
      // removeButton
      // 
      this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.removeButton.Enabled = false;
      this.removeButton.Location = new System.Drawing.Point(474, 58);
      this.removeButton.Name = "removeButton";
      this.removeButton.Size = new System.Drawing.Size(75, 23);
      this.removeButton.TabIndex = 3;
      this.removeButton.Text = "&Remove...";
      this.removeButton.UseVisualStyleBackColor = true;
      this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // editButton
      // 
      this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.editButton.Enabled = false;
      this.editButton.Location = new System.Drawing.Point(474, 29);
      this.editButton.Name = "editButton";
      this.editButton.Size = new System.Drawing.Size(75, 23);
      this.editButton.TabIndex = 2;
      this.editButton.Text = "&Edit...";
      this.editButton.UseVisualStyleBackColor = true;
      this.editButton.Click += new System.EventHandler(this.EditButton_Click);
      // 
      // addButton
      // 
      this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.addButton.Location = new System.Drawing.Point(474, 0);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(75, 23);
      this.addButton.TabIndex = 1;
      this.addButton.Text = "&Add...";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // containersListView
      // 
      this.containersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.containersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            nameColumnHeader,
            accountColumnHeader,
            containerColumnHeader,
            pathColumnHeader});
      this.containersListView.FullRowSelect = true;
      this.containersListView.HideSelection = false;
      this.containersListView.Location = new System.Drawing.Point(0, 0);
      this.containersListView.Name = "containersListView";
      this.containersListView.Size = new System.Drawing.Size(468, 269);
      this.containersListView.TabIndex = 0;
      this.containersListView.UseCompatibleStateImageBehavior = false;
      this.containersListView.View = System.Windows.Forms.View.Details;
      this.containersListView.ItemActivate += new System.EventHandler(this.ContainersListView_ItemActivate);
      this.containersListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ContainersListView_ItemChecked);
      this.containersListView.SelectedIndexChanged += new System.EventHandler(this.ContainersListView_SelectedIndexChanged);
      // 
      // accountColumnHeader
      // 
      accountColumnHeader.Text = "Connection";
      accountColumnHeader.Width = 120;
      // 
      // containerColumnHeader
      // 
      containerColumnHeader.Text = "Container";
      containerColumnHeader.Width = 120;
      // 
      // pathColumnHeader
      // 
      pathColumnHeader.Text = "Local Path";
      pathColumnHeader.Width = 120;
      // 
      // selectionTimer
      // 
      this.selectionTimer.Tick += new System.EventHandler(this.SelectionTimer_Tick);
      // 
      // nameColumnHeader
      // 
      nameColumnHeader.Text = "Name";
      nameColumnHeader.Width = 120;
      // 
      // AccountCollectionEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.duplicateButton);
      this.Controls.Add(this.removeButton);
      this.Controls.Add(this.editButton);
      this.Controls.Add(this.addButton);
      this.Controls.Add(this.containersListView);
      this.Name = "AccountCollectionEditor";
      this.Size = new System.Drawing.Size(549, 269);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button duplicateButton;
    private System.Windows.Forms.Button removeButton;
    private System.Windows.Forms.Button editButton;
    private System.Windows.Forms.Button addButton;
    private Windows.Forms.ListView containersListView;
    private System.Windows.Forms.Timer selectionTimer;
  }
}
