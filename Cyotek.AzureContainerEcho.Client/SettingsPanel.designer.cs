
namespace Cyotek.AzureContainerEcho.Client
{
  partial class SettingsPanel
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
      System.Windows.Forms.GroupBox startupGroupBox;
      System.Windows.Forms.GroupBox loggingGroupBox;
      this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
      this.logDatesAsUtcCheckBox = new System.Windows.Forms.CheckBox();
      startupGroupBox = new System.Windows.Forms.GroupBox();
      loggingGroupBox = new System.Windows.Forms.GroupBox();
      startupGroupBox.SuspendLayout();
      loggingGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // startupGroupBox
      // 
      startupGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      startupGroupBox.Controls.Add(this.startWithWindowsCheckBox);
      startupGroupBox.Location = new System.Drawing.Point(0, 59);
      startupGroupBox.Name = "startupGroupBox";
      startupGroupBox.Size = new System.Drawing.Size(662, 53);
      startupGroupBox.TabIndex = 1;
      startupGroupBox.TabStop = false;
      startupGroupBox.Text = "Startup";
      // 
      // startWithWindowsCheckBox
      // 
      this.startWithWindowsCheckBox.AutoSize = true;
      this.startWithWindowsCheckBox.Location = new System.Drawing.Point(6, 19);
      this.startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
      this.startWithWindowsCheckBox.Size = new System.Drawing.Size(117, 17);
      this.startWithWindowsCheckBox.TabIndex = 0;
      this.startWithWindowsCheckBox.Text = "Start &with Windows";
      this.startWithWindowsCheckBox.UseVisualStyleBackColor = true;
      // 
      // loggingGroupBox
      // 
      loggingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      loggingGroupBox.Controls.Add(this.logDatesAsUtcCheckBox);
      loggingGroupBox.Location = new System.Drawing.Point(0, 0);
      loggingGroupBox.Name = "loggingGroupBox";
      loggingGroupBox.Size = new System.Drawing.Size(662, 53);
      loggingGroupBox.TabIndex = 0;
      loggingGroupBox.TabStop = false;
      loggingGroupBox.Text = "Logging";
      // 
      // logDatesAsUtcCheckBox
      // 
      this.logDatesAsUtcCheckBox.AutoSize = true;
      this.logDatesAsUtcCheckBox.Location = new System.Drawing.Point(6, 19);
      this.logDatesAsUtcCheckBox.Name = "logDatesAsUtcCheckBox";
      this.logDatesAsUtcCheckBox.Size = new System.Drawing.Size(112, 17);
      this.logDatesAsUtcCheckBox.TabIndex = 0;
      this.logDatesAsUtcCheckBox.Text = "Log dates as &UTC";
      this.logDatesAsUtcCheckBox.UseVisualStyleBackColor = true;
      // 
      // SettingsPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(loggingGroupBox);
      this.Controls.Add(startupGroupBox);
      this.Name = "SettingsPanel";
      this.Size = new System.Drawing.Size(662, 540);
      startupGroupBox.ResumeLayout(false);
      startupGroupBox.PerformLayout();
      loggingGroupBox.ResumeLayout(false);
      loggingGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.CheckBox startWithWindowsCheckBox;
    private System.Windows.Forms.CheckBox logDatesAsUtcCheckBox;
  }
}
