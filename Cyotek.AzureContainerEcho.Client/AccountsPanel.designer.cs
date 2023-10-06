
namespace Cyotek.AzureContainerEcho.Client
{
  partial class AccountsPanel
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
      this.accountCollectionEditor = new Cyotek.AzureContainerEcho.Client.AccountCollectionEditor();
      this.SuspendLayout();
      // 
      // accountCollectionEditor
      // 
      this.accountCollectionEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.accountCollectionEditor.Location = new System.Drawing.Point(0, 0);
      this.accountCollectionEditor.Name = "accountCollectionEditor";
      this.accountCollectionEditor.Size = new System.Drawing.Size(662, 540);
      this.accountCollectionEditor.TabIndex = 0;
      // 
      // AccountsPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.accountCollectionEditor);
      this.Name = "AccountsPanel";
      this.Size = new System.Drawing.Size(662, 540);
      this.ResumeLayout(false);

    }

    #endregion

    private AccountCollectionEditor accountCollectionEditor;
  }
}
