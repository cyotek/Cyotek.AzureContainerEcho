
namespace Cyotek.AzureContainerEcho.Client
{
  partial class SettingsDialog
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.tabList = new Cyotek.Windows.Forms.TabList();
      this.settingsTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.generalSettingsGroupBox = new Cyotek.Windows.Forms.GroupBox();
      this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
      this.containersTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.containersGroupBox = new Cyotek.Windows.Forms.GroupBox();
      this.duplicateButton = new System.Windows.Forms.Button();
      this.removeButton = new System.Windows.Forms.Button();
      this.editButton = new System.Windows.Forms.Button();
      this.addButton = new System.Windows.Forms.Button();
      this.containersListView = new Cyotek.Windows.Forms.ListView();
      this.accountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.containerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.pathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.tabList.SuspendLayout();
      this.settingsTabListPage.SuspendLayout();
      this.generalSettingsGroupBox.SuspendLayout();
      this.containersTabListPage.SuspendLayout();
      this.containersGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.Visible = true;
      // 
      // tabList
      // 
      this.tabList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabList.Controls.Add(this.settingsTabListPage);
      this.tabList.Controls.Add(this.containersTabListPage);
      this.tabList.Location = new System.Drawing.Point(12, 12);
      this.tabList.Name = "tabList";
      this.tabList.Size = new System.Drawing.Size(671, 449);
      this.tabList.TabIndex = 0;
      // 
      // settingsTabListPage
      // 
      this.settingsTabListPage.Controls.Add(this.generalSettingsGroupBox);
      this.settingsTabListPage.Name = "settingsTabListPage";
      this.settingsTabListPage.Size = new System.Drawing.Size(513, 441);
      this.settingsTabListPage.Text = "Settings";
      // 
      // generalSettingsGroupBox
      // 
      this.generalSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.generalSettingsGroupBox.Controls.Add(this.startWithWindowsCheckBox);
      this.generalSettingsGroupBox.Location = new System.Drawing.Point(3, 3);
      this.generalSettingsGroupBox.Name = "generalSettingsGroupBox";
      this.generalSettingsGroupBox.Size = new System.Drawing.Size(507, 100);
      this.generalSettingsGroupBox.TabIndex = 0;
      this.generalSettingsGroupBox.TabStop = false;
      this.generalSettingsGroupBox.Text = "General Settings";
      // 
      // startWithWindowsCheckBox
      // 
      this.startWithWindowsCheckBox.AutoSize = true;
      this.startWithWindowsCheckBox.Location = new System.Drawing.Point(6, 22);
      this.startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
      this.startWithWindowsCheckBox.Size = new System.Drawing.Size(128, 19);
      this.startWithWindowsCheckBox.TabIndex = 0;
      this.startWithWindowsCheckBox.Text = "Start with &Windows";
      this.startWithWindowsCheckBox.UseVisualStyleBackColor = true;
      // 
      // containersTabListPage
      // 
      this.containersTabListPage.Controls.Add(this.containersGroupBox);
      this.containersTabListPage.Name = "containersTabListPage";
      this.containersTabListPage.Size = new System.Drawing.Size(513, 441);
      this.containersTabListPage.Text = "Accounts";
      // 
      // containersGroupBox
      // 
      this.containersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.containersGroupBox.Controls.Add(this.duplicateButton);
      this.containersGroupBox.Controls.Add(this.removeButton);
      this.containersGroupBox.Controls.Add(this.editButton);
      this.containersGroupBox.Controls.Add(this.addButton);
      this.containersGroupBox.Controls.Add(this.containersListView);
      this.containersGroupBox.Location = new System.Drawing.Point(3, 3);
      this.containersGroupBox.Name = "containersGroupBox";
      this.containersGroupBox.Size = new System.Drawing.Size(507, 435);
      this.containersGroupBox.TabIndex = 0;
      this.containersGroupBox.TabStop = false;
      this.containersGroupBox.Text = "Accounts";
      // 
      // duplicateButton
      // 
      this.duplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.duplicateButton.Enabled = false;
      this.duplicateButton.Location = new System.Drawing.Point(426, 109);
      this.duplicateButton.Name = "duplicateButton";
      this.duplicateButton.Size = new System.Drawing.Size(75, 23);
      this.duplicateButton.TabIndex = 4;
      this.duplicateButton.Text = "&Duplicate";
      this.duplicateButton.UseVisualStyleBackColor = true;
      this.duplicateButton.Click += new System.EventHandler(this.duplicateButton_Click);
      // 
      // removeButton
      // 
      this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.removeButton.Enabled = false;
      this.removeButton.Location = new System.Drawing.Point(426, 80);
      this.removeButton.Name = "removeButton";
      this.removeButton.Size = new System.Drawing.Size(75, 23);
      this.removeButton.TabIndex = 3;
      this.removeButton.Text = "&Remove...";
      this.removeButton.UseVisualStyleBackColor = true;
      this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
      // 
      // editButton
      // 
      this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.editButton.Enabled = false;
      this.editButton.Location = new System.Drawing.Point(426, 51);
      this.editButton.Name = "editButton";
      this.editButton.Size = new System.Drawing.Size(75, 23);
      this.editButton.TabIndex = 2;
      this.editButton.Text = "&Edit...";
      this.editButton.UseVisualStyleBackColor = true;
      this.editButton.Click += new System.EventHandler(this.editButton_Click);
      // 
      // addButton
      // 
      this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.addButton.Location = new System.Drawing.Point(426, 22);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(75, 23);
      this.addButton.TabIndex = 1;
      this.addButton.Text = "&Add...";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.addButton_Click);
      // 
      // containersListView
      // 
      this.containersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.containersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.accountColumnHeader,
            this.containerColumnHeader,
            this.pathColumnHeader});
      this.containersListView.FullRowSelect = true;
      this.containersListView.HideSelection = false;
      this.containersListView.Location = new System.Drawing.Point(6, 22);
      this.containersListView.Name = "containersListView";
      this.containersListView.Size = new System.Drawing.Size(414, 407);
      this.containersListView.TabIndex = 0;
      this.containersListView.UseCompatibleStateImageBehavior = false;
      this.containersListView.View = System.Windows.Forms.View.Details;
      this.containersListView.ItemActivate += new System.EventHandler(this.containersListView_ItemActivate);
      this.containersListView.SelectedIndexChanged += new System.EventHandler(this.containersListView_SelectedIndexChanged);
      // 
      // accountColumnHeader
      // 
      this.accountColumnHeader.Text = "Account";
      this.accountColumnHeader.Width = 90;
      // 
      // containerColumnHeader
      // 
      this.containerColumnHeader.Text = "Container";
      this.containerColumnHeader.Width = 120;
      // 
      // pathColumnHeader
      // 
      this.pathColumnHeader.Text = "Local Path";
      this.pathColumnHeader.Width = 120;
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(527, 467);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(608, 467);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 2;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // SettingsDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(695, 502);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.tabList);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.Name = "SettingsDialog";
      this.Text = "Settings";
      this.tabList.ResumeLayout(false);
      this.settingsTabListPage.ResumeLayout(false);
      this.generalSettingsGroupBox.ResumeLayout(false);
      this.generalSettingsGroupBox.PerformLayout();
      this.containersTabListPage.ResumeLayout(false);
      this.containersGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private Cyotek.Windows.Forms.TabList tabList;
    private Cyotek.Windows.Forms.TabListPage containersTabListPage;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private Cyotek.Windows.Forms.TabListPage settingsTabListPage;
    private Cyotek.Windows.Forms.GroupBox generalSettingsGroupBox;
    private System.Windows.Forms.CheckBox startWithWindowsCheckBox;
    private Windows.Forms.GroupBox containersGroupBox;
    private Cyotek.Windows.Forms.ListView containersListView;
    private System.Windows.Forms.Button removeButton;
    private System.Windows.Forms.Button editButton;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.ColumnHeader accountColumnHeader;
    private System.Windows.Forms.ColumnHeader containerColumnHeader;
    private System.Windows.Forms.ColumnHeader pathColumnHeader;
    private System.Windows.Forms.Button duplicateButton;
  }
}

