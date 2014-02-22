using System;
using System.Diagnostics;
using System.Windows.Forms;

// ReSharper disable CheckNamespace

namespace Cyotek // ReSharper restore CheckNamespace
{
  public abstract class TrayIconApplicationContext : ApplicationContext
  {
    #region Instance Fields

    private readonly ContextMenuStrip _contextMenu;

    private readonly NotifyIcon _notifyIcon;

    #endregion

    #region Protected Constructors

    protected TrayIconApplicationContext()
    {
      _contextMenu = new ContextMenuStrip();

      Application.ApplicationExit += this.ApplicationExitHandler;

      _notifyIcon = new NotifyIcon
                    {
                      ContextMenuStrip = _contextMenu,
                      Text = Application.ProductName,
                      Visible = true
                    };
      this.TrayIcon.MouseDoubleClick += this.TrayIconDoubleClickHandler;
      this.TrayIcon.MouseClick += this.TrayIconClickHandler;
    }

    #endregion

    #region Protected Properties

    protected ContextMenuStrip ContextMenu
    {
      get { return _contextMenu; }
    }

    protected NotifyIcon TrayIcon
    {
      get { return _notifyIcon; }
    }

    #endregion

    #region Protected Members

    protected virtual void OnApplicationExit(EventArgs e)
    {
      if (_contextMenu != null)
      {
        _contextMenu.Dispose();
      }

      if (_notifyIcon != null)
      {
        _notifyIcon.Visible = false;
        _notifyIcon.Dispose();
      }
    }

    protected virtual void OnTrayIconClick(MouseEventArgs e)
    { }

    protected virtual void OnTrayIconDoubleClick(MouseEventArgs e)
    { }

    #endregion

    #region Event Handlers

    private void ApplicationExitHandler(object sender, EventArgs e)
    {
      this.OnApplicationExit(e);
    }

    private void TrayIconClickHandler(object sender, MouseEventArgs e)
    {
      Debug.Print("Icon click with {0} button", e.Button);

      this.OnTrayIconClick(e);
    }

    private void TrayIconDoubleClickHandler(object sender, MouseEventArgs e)
    {
      Debug.Print("Icon double click with {0} button", e.Button);

      this.OnTrayIconDoubleClick(e);
    }

    #endregion
  }
}
