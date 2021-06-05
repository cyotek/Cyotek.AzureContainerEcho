namespace Cyotek.AzureContainerEcho.Client
{
  partial class AccountPropertiesDialog
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
      System.Windows.Forms.Label localPathLabel;
      System.Windows.Forms.Label containerLabel;
      System.Windows.Forms.Label accessKeyLabel;
      System.Windows.Forms.Label accountNameLabel;
      Cyotek.Windows.Forms.Line line1;
      System.Windows.Forms.Label connectionStringLabel;
      System.Windows.Forms.Label runEveryPrefixLabel;
      System.Windows.Forms.Label runEverySuffixLabel;
      Cyotek.Windows.Forms.Line line2;
      System.Windows.Forms.Label nameLabel;
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.settingsGroupBox = new System.Windows.Forms.GroupBox();
      this.connectionStringTextBox = new System.Windows.Forms.TextBox();
      this.localPathExploreButton = new System.Windows.Forms.Button();
      this.localPathBrowseButton = new System.Windows.Forms.Button();
      this.containerBrowseButton = new System.Windows.Forms.Button();
      this.localPathTextBox = new System.Windows.Forms.TextBox();
      this.containerTextBox = new System.Windows.Forms.TextBox();
      this.accessKeyTextBox = new System.Windows.Forms.TextBox();
      this.accountNameTextBox = new System.Windows.Forms.TextBox();
      this.newFilesOnlyCheckBox = new System.Windows.Forms.CheckBox();
      this.allowUploadsCheckBox = new System.Windows.Forms.CheckBox();
      this.minutesNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.enabledCheckBox = new System.Windows.Forms.CheckBox();
      this.testConnectionLinkLabel = new Cyotek.Windows.Forms.LinkLabel();
      this.downloadsGroupBox = new System.Windows.Forms.GroupBox();
      this.deleteAfterDownloadCheckBox = new System.Windows.Forms.CheckBox();
      this.uploadsGroupBox = new System.Windows.Forms.GroupBox();
      this.nameTextBox = new System.Windows.Forms.TextBox();
      localPathLabel = new System.Windows.Forms.Label();
      containerLabel = new System.Windows.Forms.Label();
      accessKeyLabel = new System.Windows.Forms.Label();
      accountNameLabel = new System.Windows.Forms.Label();
      line1 = new Cyotek.Windows.Forms.Line();
      connectionStringLabel = new System.Windows.Forms.Label();
      runEveryPrefixLabel = new System.Windows.Forms.Label();
      runEverySuffixLabel = new System.Windows.Forms.Label();
      line2 = new Cyotek.Windows.Forms.Line();
      nameLabel = new System.Windows.Forms.Label();
      this.settingsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.minutesNumericUpDown)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.downloadsGroupBox.SuspendLayout();
      this.uploadsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // localPathLabel
      // 
      localPathLabel.AutoSize = true;
      localPathLabel.Location = new System.Drawing.Point(6, 147);
      localPathLabel.Name = "localPathLabel";
      localPathLabel.Size = new System.Drawing.Size(60, 13);
      localPathLabel.TabIndex = 10;
      localPathLabel.Text = "Local &path:";
      // 
      // containerLabel
      // 
      containerLabel.AutoSize = true;
      containerLabel.Location = new System.Drawing.Point(6, 117);
      containerLabel.Name = "containerLabel";
      containerLabel.Size = new System.Drawing.Size(55, 13);
      containerLabel.TabIndex = 7;
      containerLabel.Text = "&Container:";
      // 
      // accessKeyLabel
      // 
      accessKeyLabel.AutoSize = true;
      accessKeyLabel.Location = new System.Drawing.Point(6, 77);
      accessKeyLabel.Name = "accessKeyLabel";
      accessKeyLabel.Size = new System.Drawing.Size(65, 13);
      accessKeyLabel.TabIndex = 4;
      accessKeyLabel.Text = "Access &key:";
      // 
      // accountNameLabel
      // 
      accountNameLabel.AutoSize = true;
      accountNameLabel.Location = new System.Drawing.Point(6, 48);
      accountNameLabel.Name = "accountNameLabel";
      accountNameLabel.Size = new System.Drawing.Size(79, 13);
      accountNameLabel.TabIndex = 2;
      accountNameLabel.Text = "Account &name:";
      // 
      // line1
      // 
      line1.Location = new System.Drawing.Point(9, 103);
      line1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
      line1.Name = "line1";
      line1.Size = new System.Drawing.Size(637, 2);
      line1.TabIndex = 6;
      line1.Text = "line1";
      // 
      // connectionStringLabel
      // 
      connectionStringLabel.AutoSize = true;
      connectionStringLabel.Location = new System.Drawing.Point(6, 22);
      connectionStringLabel.Name = "connectionStringLabel";
      connectionStringLabel.Size = new System.Drawing.Size(92, 13);
      connectionStringLabel.TabIndex = 0;
      connectionStringLabel.Text = "Connection &string:";
      // 
      // runEveryPrefixLabel
      // 
      runEveryPrefixLabel.AutoSize = true;
      runEveryPrefixLabel.Location = new System.Drawing.Point(6, 44);
      runEveryPrefixLabel.Name = "runEveryPrefixLabel";
      runEveryPrefixLabel.Size = new System.Drawing.Size(56, 13);
      runEveryPrefixLabel.TabIndex = 1;
      runEveryPrefixLabel.Text = "&Run every";
      // 
      // runEverySuffixLabel
      // 
      runEverySuffixLabel.AutoSize = true;
      runEverySuffixLabel.Location = new System.Drawing.Point(135, 44);
      runEverySuffixLabel.Name = "runEverySuffixLabel";
      runEverySuffixLabel.Size = new System.Drawing.Size(43, 13);
      runEverySuffixLabel.TabIndex = 3;
      runEverySuffixLabel.Text = "minutes";
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(589, 476);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 6;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(508, 476);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 5;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // settingsGroupBox
      // 
      this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.settingsGroupBox.Controls.Add(this.connectionStringTextBox);
      this.settingsGroupBox.Controls.Add(connectionStringLabel);
      this.settingsGroupBox.Controls.Add(line1);
      this.settingsGroupBox.Controls.Add(this.localPathExploreButton);
      this.settingsGroupBox.Controls.Add(this.localPathBrowseButton);
      this.settingsGroupBox.Controls.Add(this.containerBrowseButton);
      this.settingsGroupBox.Controls.Add(this.localPathTextBox);
      this.settingsGroupBox.Controls.Add(localPathLabel);
      this.settingsGroupBox.Controls.Add(this.containerTextBox);
      this.settingsGroupBox.Controls.Add(containerLabel);
      this.settingsGroupBox.Controls.Add(this.accessKeyTextBox);
      this.settingsGroupBox.Controls.Add(accessKeyLabel);
      this.settingsGroupBox.Controls.Add(this.accountNameTextBox);
      this.settingsGroupBox.Controls.Add(accountNameLabel);
      this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
      this.settingsGroupBox.Name = "settingsGroupBox";
      this.settingsGroupBox.Size = new System.Drawing.Size(652, 178);
      this.settingsGroupBox.TabIndex = 0;
      this.settingsGroupBox.TabStop = false;
      this.settingsGroupBox.Text = "Account Settings";
      // 
      // connectionStringTextBox
      // 
      this.connectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.connectionStringTextBox.Location = new System.Drawing.Point(103, 19);
      this.connectionStringTextBox.Name = "connectionStringTextBox";
      this.connectionStringTextBox.Size = new System.Drawing.Size(543, 20);
      this.connectionStringTextBox.TabIndex = 1;
      // 
      // localPathExploreButton
      // 
      this.localPathExploreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.localPathExploreButton.Image = global::Cyotek.AzureContainerEcho.Client.Properties.Resources.GoToFolder;
      this.localPathExploreButton.Location = new System.Drawing.Point(622, 143);
      this.localPathExploreButton.Name = "localPathExploreButton";
      this.localPathExploreButton.Size = new System.Drawing.Size(24, 23);
      this.localPathExploreButton.TabIndex = 13;
      this.localPathExploreButton.UseVisualStyleBackColor = true;
      this.localPathExploreButton.Click += new System.EventHandler(this.LocalPathExploreButton_Click);
      // 
      // localPathBrowseButton
      // 
      this.localPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.localPathBrowseButton.Location = new System.Drawing.Point(541, 144);
      this.localPathBrowseButton.Name = "localPathBrowseButton";
      this.localPathBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.localPathBrowseButton.TabIndex = 12;
      this.localPathBrowseButton.Text = "&Browse...";
      this.localPathBrowseButton.UseVisualStyleBackColor = true;
      this.localPathBrowseButton.Click += new System.EventHandler(this.LocalPathBrowseButton_Click);
      // 
      // containerBrowseButton
      // 
      this.containerBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.containerBrowseButton.Enabled = false;
      this.containerBrowseButton.Location = new System.Drawing.Point(571, 113);
      this.containerBrowseButton.Name = "containerBrowseButton";
      this.containerBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.containerBrowseButton.TabIndex = 9;
      this.containerBrowseButton.Text = "B&rowse...";
      this.containerBrowseButton.UseVisualStyleBackColor = true;
      // 
      // localPathTextBox
      // 
      this.localPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.localPathTextBox.Location = new System.Drawing.Point(103, 144);
      this.localPathTextBox.Name = "localPathTextBox";
      this.localPathTextBox.Size = new System.Drawing.Size(432, 20);
      this.localPathTextBox.TabIndex = 11;
      // 
      // containerTextBox
      // 
      this.containerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.containerTextBox.Location = new System.Drawing.Point(103, 114);
      this.containerTextBox.Name = "containerTextBox";
      this.containerTextBox.Size = new System.Drawing.Size(462, 20);
      this.containerTextBox.TabIndex = 8;
      // 
      // accessKeyTextBox
      // 
      this.accessKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.accessKeyTextBox.Location = new System.Drawing.Point(103, 74);
      this.accessKeyTextBox.Name = "accessKeyTextBox";
      this.accessKeyTextBox.Size = new System.Drawing.Size(543, 20);
      this.accessKeyTextBox.TabIndex = 5;
      // 
      // accountNameTextBox
      // 
      this.accountNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.accountNameTextBox.Location = new System.Drawing.Point(103, 45);
      this.accountNameTextBox.Name = "accountNameTextBox";
      this.accountNameTextBox.Size = new System.Drawing.Size(543, 20);
      this.accountNameTextBox.TabIndex = 3;
      // 
      // newFilesOnlyCheckBox
      // 
      this.newFilesOnlyCheckBox.AutoSize = true;
      this.newFilesOnlyCheckBox.Location = new System.Drawing.Point(6, 19);
      this.newFilesOnlyCheckBox.Name = "newFilesOnlyCheckBox";
      this.newFilesOnlyCheckBox.Size = new System.Drawing.Size(187, 17);
      this.newFilesOnlyCheckBox.TabIndex = 0;
      this.newFilesOnlyCheckBox.Text = "Check for &new or missing files only";
      this.newFilesOnlyCheckBox.UseVisualStyleBackColor = true;
      // 
      // allowUploadsCheckBox
      // 
      this.allowUploadsCheckBox.AutoSize = true;
      this.allowUploadsCheckBox.Location = new System.Drawing.Point(6, 19);
      this.allowUploadsCheckBox.Name = "allowUploadsCheckBox";
      this.allowUploadsCheckBox.Size = new System.Drawing.Size(158, 17);
      this.allowUploadsCheckBox.TabIndex = 0;
      this.allowUploadsCheckBox.Text = "Allow &uploading of local files";
      this.allowUploadsCheckBox.UseVisualStyleBackColor = true;
      // 
      // minutesNumericUpDown
      // 
      this.minutesNumericUpDown.Location = new System.Drawing.Point(68, 42);
      this.minutesNumericUpDown.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
      this.minutesNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.minutesNumericUpDown.Name = "minutesNumericUpDown";
      this.minutesNumericUpDown.Size = new System.Drawing.Size(61, 20);
      this.minutesNumericUpDown.TabIndex = 2;
      this.minutesNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(line2);
      this.groupBox1.Controls.Add(this.nameTextBox);
      this.groupBox1.Controls.Add(nameLabel);
      this.groupBox1.Controls.Add(this.enabledCheckBox);
      this.groupBox1.Controls.Add(runEverySuffixLabel);
      this.groupBox1.Controls.Add(this.minutesNumericUpDown);
      this.groupBox1.Controls.Add(runEveryPrefixLabel);
      this.groupBox1.Location = new System.Drawing.Point(12, 344);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(652, 114);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Scheduling";
      // 
      // enabledCheckBox
      // 
      this.enabledCheckBox.AutoSize = true;
      this.enabledCheckBox.Location = new System.Drawing.Point(6, 19);
      this.enabledCheckBox.Name = "enabledCheckBox";
      this.enabledCheckBox.Size = new System.Drawing.Size(95, 17);
      this.enabledCheckBox.TabIndex = 0;
      this.enabledCheckBox.Text = "&Enable this job";
      this.enabledCheckBox.UseVisualStyleBackColor = true;
      // 
      // testConnectionLinkLabel
      // 
      this.testConnectionLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.testConnectionLinkLabel.Location = new System.Drawing.Point(12, 480);
      this.testConnectionLinkLabel.Name = "testConnectionLinkLabel";
      this.testConnectionLinkLabel.Size = new System.Drawing.Size(79, 14);
      this.testConnectionLinkLabel.TabIndex = 4;
      this.testConnectionLinkLabel.Text = "Test Connection";
      this.testConnectionLinkLabel.Click += new System.EventHandler(this.TestConnectionLinkLabel_Click);
      // 
      // downloadsGroupBox
      // 
      this.downloadsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.downloadsGroupBox.Controls.Add(this.deleteAfterDownloadCheckBox);
      this.downloadsGroupBox.Controls.Add(this.newFilesOnlyCheckBox);
      this.downloadsGroupBox.Location = new System.Drawing.Point(12, 196);
      this.downloadsGroupBox.Name = "downloadsGroupBox";
      this.downloadsGroupBox.Size = new System.Drawing.Size(652, 77);
      this.downloadsGroupBox.TabIndex = 1;
      this.downloadsGroupBox.TabStop = false;
      this.downloadsGroupBox.Text = "Downloads";
      // 
      // deleteAfterDownloadCheckBox
      // 
      this.deleteAfterDownloadCheckBox.AutoSize = true;
      this.deleteAfterDownloadCheckBox.Location = new System.Drawing.Point(6, 42);
      this.deleteAfterDownloadCheckBox.Name = "deleteAfterDownloadCheckBox";
      this.deleteAfterDownloadCheckBox.Size = new System.Drawing.Size(195, 17);
      this.deleteAfterDownloadCheckBox.TabIndex = 1;
      this.deleteAfterDownloadCheckBox.Text = "&Delete remote file after downloading";
      this.deleteAfterDownloadCheckBox.UseVisualStyleBackColor = true;
      // 
      // uploadsGroupBox
      // 
      this.uploadsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uploadsGroupBox.Controls.Add(this.allowUploadsCheckBox);
      this.uploadsGroupBox.Location = new System.Drawing.Point(12, 279);
      this.uploadsGroupBox.Name = "uploadsGroupBox";
      this.uploadsGroupBox.Size = new System.Drawing.Size(652, 59);
      this.uploadsGroupBox.TabIndex = 2;
      this.uploadsGroupBox.TabStop = false;
      this.uploadsGroupBox.Text = "Uploads";
      // 
      // line2
      // 
      line2.Location = new System.Drawing.Point(6, 71);
      line2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
      line2.Name = "line2";
      line2.Size = new System.Drawing.Size(637, 2);
      line2.TabIndex = 4;
      line2.Text = "line2";
      // 
      // nameTextBox
      // 
      this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nameTextBox.Location = new System.Drawing.Point(100, 82);
      this.nameTextBox.Name = "nameTextBox";
      this.nameTextBox.Size = new System.Drawing.Size(543, 20);
      this.nameTextBox.TabIndex = 6;
      // 
      // nameLabel
      // 
      nameLabel.AutoSize = true;
      nameLabel.Location = new System.Drawing.Point(3, 85);
      nameLabel.Name = "nameLabel";
      nameLabel.Size = new System.Drawing.Size(63, 13);
      nameLabel.TabIndex = 5;
      nameLabel.Text = "Descr&iption:";
      // 
      // AccountPropertiesDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(676, 511);
      this.Controls.Add(this.uploadsGroupBox);
      this.Controls.Add(this.downloadsGroupBox);
      this.Controls.Add(this.testConnectionLinkLabel);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.settingsGroupBox);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "AccountPropertiesDialog";
      this.Text = "Account Properties";
      this.settingsGroupBox.ResumeLayout(false);
      this.settingsGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.minutesNumericUpDown)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.downloadsGroupBox.ResumeLayout(false);
      this.downloadsGroupBox.PerformLayout();
      this.uploadsGroupBox.ResumeLayout(false);
      this.uploadsGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.GroupBox settingsGroupBox;
    private System.Windows.Forms.Button localPathBrowseButton;
    private System.Windows.Forms.Button containerBrowseButton;
    private System.Windows.Forms.TextBox localPathTextBox;
    private System.Windows.Forms.TextBox containerTextBox;
    private System.Windows.Forms.TextBox accessKeyTextBox;
    private System.Windows.Forms.TextBox accountNameTextBox;
    private System.Windows.Forms.NumericUpDown minutesNumericUpDown;
    private System.Windows.Forms.GroupBox groupBox1;
    private Cyotek.Windows.Forms.LinkLabel testConnectionLinkLabel;
    private System.Windows.Forms.Button localPathExploreButton;
    private System.Windows.Forms.CheckBox allowUploadsCheckBox;
    private System.Windows.Forms.CheckBox newFilesOnlyCheckBox;
    private System.Windows.Forms.GroupBox downloadsGroupBox;
    private System.Windows.Forms.GroupBox uploadsGroupBox;
    private System.Windows.Forms.CheckBox enabledCheckBox;
    private System.Windows.Forms.CheckBox deleteAfterDownloadCheckBox;
    private System.Windows.Forms.TextBox connectionStringTextBox;
    private System.Windows.Forms.TextBox nameTextBox;
  }
}