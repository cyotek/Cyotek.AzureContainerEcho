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
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.settingsGroupBox = new Cyotek.Windows.Forms.GroupBox();
      this.localPathExploreButton = new System.Windows.Forms.Button();
      this.localPathBrowseButton = new System.Windows.Forms.Button();
      this.containerBrowseButton = new System.Windows.Forms.Button();
      this.localPathTextBox = new System.Windows.Forms.TextBox();
      this.localPathLabel = new System.Windows.Forms.Label();
      this.containerTextBox = new System.Windows.Forms.TextBox();
      this.containerLabel = new System.Windows.Forms.Label();
      this.accessKeyTextBox = new System.Windows.Forms.TextBox();
      this.accessKeyLabel = new System.Windows.Forms.Label();
      this.accountNameTextBox = new System.Windows.Forms.TextBox();
      this.accountNameLabel = new System.Windows.Forms.Label();
      this.newFilesOnlyCheckBox = new System.Windows.Forms.CheckBox();
      this.allowUploadsCheckBox = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.minutesNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.groupBox1 = new Cyotek.Windows.Forms.GroupBox();
      this.enabledCheckBox = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.testConnectionLinkLabel = new System.Windows.Forms.LinkLabel();
      this.downloadsGroupBox = new Cyotek.Windows.Forms.GroupBox();
      this.uploadsGroupBox = new Cyotek.Windows.Forms.GroupBox();
      this.settingsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.minutesNumericUpDown)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.downloadsGroupBox.SuspendLayout();
      this.uploadsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(469, 380);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 6;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(388, 380);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 5;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // settingsGroupBox
      // 
      this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.settingsGroupBox.Controls.Add(this.localPathExploreButton);
      this.settingsGroupBox.Controls.Add(this.localPathBrowseButton);
      this.settingsGroupBox.Controls.Add(this.containerBrowseButton);
      this.settingsGroupBox.Controls.Add(this.localPathTextBox);
      this.settingsGroupBox.Controls.Add(this.localPathLabel);
      this.settingsGroupBox.Controls.Add(this.containerTextBox);
      this.settingsGroupBox.Controls.Add(this.containerLabel);
      this.settingsGroupBox.Controls.Add(this.accessKeyTextBox);
      this.settingsGroupBox.Controls.Add(this.accessKeyLabel);
      this.settingsGroupBox.Controls.Add(this.accountNameTextBox);
      this.settingsGroupBox.Controls.Add(this.accountNameLabel);
      this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
      this.settingsGroupBox.Name = "settingsGroupBox";
      this.settingsGroupBox.Size = new System.Drawing.Size(532, 147);
      this.settingsGroupBox.TabIndex = 0;
      this.settingsGroupBox.TabStop = false;
      this.settingsGroupBox.Text = "Account Settings";
      // 
      // localPathExploreButton
      // 
      this.localPathExploreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.localPathExploreButton.Image = global::Cyotek.AzureContainerEcho.Client.Properties.Resources.GoToFolder;
      this.localPathExploreButton.Location = new System.Drawing.Point(502, 110);
      this.localPathExploreButton.Name = "localPathExploreButton";
      this.localPathExploreButton.Size = new System.Drawing.Size(24, 23);
      this.localPathExploreButton.TabIndex = 10;
      this.localPathExploreButton.UseVisualStyleBackColor = true;
      this.localPathExploreButton.Click += new System.EventHandler(this.localPathExploreButton_Click);
      // 
      // localPathBrowseButton
      // 
      this.localPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.localPathBrowseButton.Location = new System.Drawing.Point(421, 111);
      this.localPathBrowseButton.Name = "localPathBrowseButton";
      this.localPathBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.localPathBrowseButton.TabIndex = 9;
      this.localPathBrowseButton.Text = "&Browse...";
      this.localPathBrowseButton.UseVisualStyleBackColor = true;
      this.localPathBrowseButton.Click += new System.EventHandler(this.localPathBrowseButton_Click);
      // 
      // containerBrowseButton
      // 
      this.containerBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.containerBrowseButton.Enabled = false;
      this.containerBrowseButton.Location = new System.Drawing.Point(451, 80);
      this.containerBrowseButton.Name = "containerBrowseButton";
      this.containerBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.containerBrowseButton.TabIndex = 6;
      this.containerBrowseButton.Text = "B&rowse...";
      this.containerBrowseButton.UseVisualStyleBackColor = true;
      // 
      // localPathTextBox
      // 
      this.localPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.localPathTextBox.Location = new System.Drawing.Point(103, 111);
      this.localPathTextBox.Name = "localPathTextBox";
      this.localPathTextBox.Size = new System.Drawing.Size(312, 23);
      this.localPathTextBox.TabIndex = 8;
      // 
      // localPathLabel
      // 
      this.localPathLabel.AutoSize = true;
      this.localPathLabel.Location = new System.Drawing.Point(6, 114);
      this.localPathLabel.Name = "localPathLabel";
      this.localPathLabel.Size = new System.Drawing.Size(65, 15);
      this.localPathLabel.TabIndex = 7;
      this.localPathLabel.Text = "Local &path:";
      // 
      // containerTextBox
      // 
      this.containerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.containerTextBox.Location = new System.Drawing.Point(103, 81);
      this.containerTextBox.Name = "containerTextBox";
      this.containerTextBox.Size = new System.Drawing.Size(342, 23);
      this.containerTextBox.TabIndex = 5;
      // 
      // containerLabel
      // 
      this.containerLabel.AutoSize = true;
      this.containerLabel.Location = new System.Drawing.Point(6, 84);
      this.containerLabel.Name = "containerLabel";
      this.containerLabel.Size = new System.Drawing.Size(62, 15);
      this.containerLabel.TabIndex = 4;
      this.containerLabel.Text = "&Container:";
      // 
      // accessKeyTextBox
      // 
      this.accessKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.accessKeyTextBox.Location = new System.Drawing.Point(103, 51);
      this.accessKeyTextBox.Name = "accessKeyTextBox";
      this.accessKeyTextBox.Size = new System.Drawing.Size(423, 23);
      this.accessKeyTextBox.TabIndex = 3;
      // 
      // accessKeyLabel
      // 
      this.accessKeyLabel.AutoSize = true;
      this.accessKeyLabel.Location = new System.Drawing.Point(6, 54);
      this.accessKeyLabel.Name = "accessKeyLabel";
      this.accessKeyLabel.Size = new System.Drawing.Size(67, 15);
      this.accessKeyLabel.TabIndex = 2;
      this.accessKeyLabel.Text = "Access &key:";
      // 
      // accountNameTextBox
      // 
      this.accountNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.accountNameTextBox.Location = new System.Drawing.Point(103, 22);
      this.accountNameTextBox.Name = "accountNameTextBox";
      this.accountNameTextBox.Size = new System.Drawing.Size(423, 23);
      this.accountNameTextBox.TabIndex = 1;
      // 
      // accountNameLabel
      // 
      this.accountNameLabel.AutoSize = true;
      this.accountNameLabel.Location = new System.Drawing.Point(6, 25);
      this.accountNameLabel.Name = "accountNameLabel";
      this.accountNameLabel.Size = new System.Drawing.Size(88, 15);
      this.accountNameLabel.TabIndex = 0;
      this.accountNameLabel.Text = "Account &name:";
      // 
      // newFilesOnlyCheckBox
      // 
      this.newFilesOnlyCheckBox.AutoSize = true;
      this.newFilesOnlyCheckBox.Location = new System.Drawing.Point(6, 22);
      this.newFilesOnlyCheckBox.Name = "newFilesOnlyCheckBox";
      this.newFilesOnlyCheckBox.Size = new System.Drawing.Size(210, 19);
      this.newFilesOnlyCheckBox.TabIndex = 0;
      this.newFilesOnlyCheckBox.Text = "Check for &new or missing files only";
      this.newFilesOnlyCheckBox.UseVisualStyleBackColor = true;
      // 
      // allowUploadsCheckBox
      // 
      this.allowUploadsCheckBox.AutoSize = true;
      this.allowUploadsCheckBox.Location = new System.Drawing.Point(6, 22);
      this.allowUploadsCheckBox.Name = "allowUploadsCheckBox";
      this.allowUploadsCheckBox.Size = new System.Drawing.Size(179, 19);
      this.allowUploadsCheckBox.TabIndex = 0;
      this.allowUploadsCheckBox.Text = "Allow &uploading of local files";
      this.allowUploadsCheckBox.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 49);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 15);
      this.label1.TabIndex = 1;
      this.label1.Text = "Run &every";
      // 
      // minutesNumericUpDown
      // 
      this.minutesNumericUpDown.Location = new System.Drawing.Point(70, 47);
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
      this.minutesNumericUpDown.Size = new System.Drawing.Size(61, 23);
      this.minutesNumericUpDown.TabIndex = 2;
      this.minutesNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.enabledCheckBox);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.minutesNumericUpDown);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(12, 292);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(532, 82);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Scheduling";
      // 
      // enabledCheckBox
      // 
      this.enabledCheckBox.AutoSize = true;
      this.enabledCheckBox.Location = new System.Drawing.Point(6, 22);
      this.enabledCheckBox.Name = "enabledCheckBox";
      this.enabledCheckBox.Size = new System.Drawing.Size(103, 19);
      this.enabledCheckBox.TabIndex = 0;
      this.enabledCheckBox.Text = "&Enable this job";
      this.enabledCheckBox.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(137, 49);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "minutes";
      // 
      // testConnectionLinkLabel
      // 
      this.testConnectionLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.testConnectionLinkLabel.AutoSize = true;
      this.testConnectionLinkLabel.Location = new System.Drawing.Point(12, 384);
      this.testConnectionLinkLabel.Name = "testConnectionLinkLabel";
      this.testConnectionLinkLabel.Size = new System.Drawing.Size(94, 15);
      this.testConnectionLinkLabel.TabIndex = 4;
      this.testConnectionLinkLabel.TabStop = true;
      this.testConnectionLinkLabel.Text = "Test Connection";
      this.testConnectionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.testConnectionLinkLabel_LinkClicked);
      // 
      // downloadsGroupBox
      // 
      this.downloadsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.downloadsGroupBox.Controls.Add(this.newFilesOnlyCheckBox);
      this.downloadsGroupBox.Location = new System.Drawing.Point(12, 165);
      this.downloadsGroupBox.Name = "downloadsGroupBox";
      this.downloadsGroupBox.Size = new System.Drawing.Size(532, 56);
      this.downloadsGroupBox.TabIndex = 1;
      this.downloadsGroupBox.TabStop = false;
      this.downloadsGroupBox.Text = "Downloads";
      // 
      // uploadsGroupBox
      // 
      this.uploadsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uploadsGroupBox.Controls.Add(this.allowUploadsCheckBox);
      this.uploadsGroupBox.Location = new System.Drawing.Point(12, 227);
      this.uploadsGroupBox.Name = "uploadsGroupBox";
      this.uploadsGroupBox.Size = new System.Drawing.Size(532, 59);
      this.uploadsGroupBox.TabIndex = 2;
      this.uploadsGroupBox.TabStop = false;
      this.uploadsGroupBox.Text = "Uploads";
      // 
      // AccountPropertiesDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(556, 415);
      this.Controls.Add(this.uploadsGroupBox);
      this.Controls.Add(this.downloadsGroupBox);
      this.Controls.Add(this.testConnectionLinkLabel);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.settingsGroupBox);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "AccountPropertiesDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
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
    private Windows.Forms.GroupBox settingsGroupBox;
    private System.Windows.Forms.Button localPathBrowseButton;
    private System.Windows.Forms.Button containerBrowseButton;
    private System.Windows.Forms.TextBox localPathTextBox;
    private System.Windows.Forms.Label localPathLabel;
    private System.Windows.Forms.TextBox containerTextBox;
    private System.Windows.Forms.Label containerLabel;
    private System.Windows.Forms.TextBox accessKeyTextBox;
    private System.Windows.Forms.Label accessKeyLabel;
    private System.Windows.Forms.TextBox accountNameTextBox;
    private System.Windows.Forms.Label accountNameLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown minutesNumericUpDown;
    private Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.LinkLabel testConnectionLinkLabel;
    private System.Windows.Forms.Button localPathExploreButton;
    private System.Windows.Forms.CheckBox allowUploadsCheckBox;
    private System.Windows.Forms.CheckBox newFilesOnlyCheckBox;
    private Windows.Forms.GroupBox downloadsGroupBox;
    private Windows.Forms.GroupBox uploadsGroupBox;
    private System.Windows.Forms.CheckBox enabledCheckBox;
  }
}