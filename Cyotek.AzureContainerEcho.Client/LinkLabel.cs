using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

// Based on LinkLabel2: http://wyday.com/linklabel2/

// Licensed under the BSD License. See LICENSE.txt for the full text.

namespace Cyotek.Windows.Forms
{
  internal class LinkLabel : Control, IButtonControl
  {
    #region Private Fields

    private const TextFormatFlags _flags = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix | TextFormatFlags.ExpandTabs | TextFormatFlags.EndEllipsis;

    private static readonly object _eventTextAlignChanged = new object();

    private DialogResult _dialogResult;

    private Color _hoverColor;

    private Font _hoverFont;

    private bool _hoverUnderline;

    private Image _image;

    private int _imageRightPad = 8;

    private bool _isHovered;

    private bool _keyAlreadyProcessed;

    private Color _regularColor;

    private HorizontalAlignment _textAlign;

    private Rectangle _textBounds;

    private bool _useSystemColor;

    #endregion Private Fields

    #region Public Constructors

    public LinkLabel()
    {
      this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
      if (!this.DesignMode)
      {
        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      }
      this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
      base.DoubleBuffered = true;

      _hoverFont = this.CreateHoverFont();

      base.AutoSize = true;
      base.ForeColor = SystemColors.HotTrack;
      _useSystemColor = true;
      _hoverUnderline = true;
      _hoverColor = SystemColors.HotTrack;
      _regularColor = SystemColors.HotTrack;
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler TextAlignChanged
    {
      add { this.Events.AddHandler(_eventTextAlignChanged, value); }
      remove { this.Events.RemoveHandler(_eventTextAlignChanged, value); }
    }

    #endregion Public Events

    #region Public Properties

    [DefaultValue(true)]
    [Browsable(true)]
    public override bool AutoSize
    {
      get { return base.AutoSize; }
      set { base.AutoSize = value; }
    }

    [DefaultValue(typeof(DialogResult), "None")]
    public DialogResult DialogResult
    {
      get { return _dialogResult; }
      set { _dialogResult = value; }
    }

    [DefaultValue(typeof(Color), "HotTrack")]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
      set { base.ForeColor = value; }
    }

    [DefaultValue(typeof(Color), "HotTrack")]
    [Category("Appearance")]
    public Color HoverColor
    {
      get { return _hoverColor; }
      set { _hoverColor = value; }
    }

    [DefaultValue(true)]
    [Category("Appearance")]
    public bool HoverUnderline
    {
      get { return _hoverUnderline; }
      set { _hoverUnderline = value; }
    }

    [DefaultValue(null)]
    [Category("Appearance")]
    public Image Image
    {
      get { return _image; }
      set
      {
        _image = value;

        this.RefreshTextRect();
        this.Invalidate();
      }
    }

    [DefaultValue(8)]
    [Category("Appearance")]
    public int ImageRightPad
    {
      get { return _imageRightPad; }
      set
      {
        _imageRightPad = value;

        this.RefreshTextRect();
        this.Invalidate();
      }
    }

    [DefaultValue(typeof(Color), "HotTrack")]
    [Category("Appearance")]
    public Color RegularColor
    {
      get { return _regularColor; }
      set { _regularColor = value; }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(HorizontalAlignment), "Left")]
    public virtual HorizontalAlignment TextAlign
    {
      get { return _textAlign; }
      set
      {
        if (_textAlign != value)
        {
          _textAlign = value;

          this.OnTextAlignChanged(EventArgs.Empty);
        }
      }
    }

    [DefaultValue(true)]
    [Category("Appearance")]
    public bool UseSystemColor
    {
      get { return _useSystemColor; }
      set { _useSystemColor = value; }
    }

    #endregion Public Properties

    #region Public Methods

    public void PerformClick()
    {
      this.OnClick(EventArgs.Empty);
    }

    void IButtonControl.NotifyDefault(bool value)
    {
      // no-op
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      _hoverFont?.Dispose();

      base.Dispose(disposing);
    }

    protected override bool IsInputKey(Keys keyData)
    {
      return base.IsInputKey(keyData) || keyData == Keys.Enter || keyData == Keys.Space;
    }

    protected override void OnAutoSizeChanged(EventArgs e)
    {
      base.OnAutoSizeChanged(e);

      this.RefreshTextRect();
    }

    protected override void OnFontChanged(EventArgs e)
    {
      _hoverFont?.Dispose();

      _hoverFont = this.CreateHoverFont();

      this.RefreshTextRect();
      this.Invalidate();

      base.OnFontChanged(e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
      this.Invalidate();

      base.OnGotFocus(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (!_keyAlreadyProcessed && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space))
      {
        e.Handled = true;
        _keyAlreadyProcessed = true;
        this.PerformClick();
      }

      base.OnKeyDown(e);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
      _keyAlreadyProcessed = false;

      base.OnKeyUp(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
      _keyAlreadyProcessed = false;

      this.Invalidate();

      base.OnLostFocus(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.Focus();
      }

      base.OnMouseDown(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      _isHovered = true;
      this.Invalidate();

      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      _isHovered = false;
      this.Invalidate();

      base.OnMouseLeave(e);
    }

    protected override void OnMouseMove(MouseEventArgs mevent)
    {
      base.OnMouseMove(mevent);

      if (mevent.Button != MouseButtons.None)
      {
        if (!this.ClientRectangle.Contains(mevent.Location))
        {
          if (_isHovered)
          {
            _isHovered = false;
            this.Invalidate();
          }
        }
        else if (!_isHovered)
        {
          _isHovered = true;
          this.Invalidate();
        }
      }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (_isHovered && e.Clicks == 1 && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle))
      {
        this.PerformClick();
      }

      base.OnMouseUp(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      // image
      if (_image != null)
      {
        e.Graphics.DrawImageUnscaled(_image, Point.Empty);
      }

      //text
      TextRenderer.DrawText(e.Graphics, this.Text, _isHovered && _hoverUnderline ? _hoverFont : this.Font, _textBounds, this.Enabled ? _useSystemColor ? this.ForeColor : (_isHovered ? _hoverColor : _regularColor) : SystemColors.GrayText, _flags);

      // draw the focus rectangle.
      if (this.Focused && this.ShowFocusCues)
      {
        ControlPaint.DrawFocusRectangle(e.Graphics, this.ClientRectangle);
      }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.RefreshTextRect();
    }

    /// <summary>
    /// Raises the <see cref="TextAlignChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTextAlignChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventTextAlignChanged];

      handler?.Invoke(this, e);
    }

    protected override void OnTextChanged(EventArgs e)
    {
      this.RefreshTextRect();
      this.Invalidate();

      base.OnTextChanged(e);
    }

    [DebuggerStepThrough]
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == NativeMethods.WM_SETCURSOR)
      {
        Forms.NativeMethods.SetCursor(Forms.NativeMethods.LoadCursor(0, NativeMethods.IDC_HAND));
        m.Result = IntPtr.Zero;
      }
      else
      {
        base.WndProc(ref m);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private Font CreateHoverFont()
    {
      return new Font(this.Font, this.Font.Style | FontStyle.Underline);
    }

    private void RefreshTextRect()
    {
      string text;

      text = this.Text;

      if (!string.IsNullOrEmpty(text))
      {
        using (Graphics g = this.CreateGraphics())
        {
          _textBounds = new Rectangle(Point.Empty, TextRenderer.MeasureText(g, text, this.Font, this.AutoSize ? new Size(int.MaxValue, int.MaxValue) : this.ClientSize, _flags));
        }

        if (!_textBounds.IsEmpty)
        {
          int width;
          int height;

          width = _textBounds.Width + 1;
          height = _textBounds.Height + 1;

          if (_image != null)
          {
            width = _textBounds.Width + 1 + _image.Width + _imageRightPad;

            //adjust the x position of the text
            _textBounds.X += _image.Width + _imageRightPad;

            if (_image.Height > _textBounds.Height)
            {
              height = _image.Height + 1;

              // adjust the y-position of the text
              _textBounds.Y += (_image.Height - _textBounds.Height) / 2;
            }
          }

          switch (_textAlign)
          {
            case HorizontalAlignment.Center:
              _textBounds.X = (this.ClientSize.Width - _textBounds.Width) / 2;
              break;

            case HorizontalAlignment.Right:
              _textBounds.X = this.ClientSize.Width - (_textBounds.Width + this.Padding.Right);
              break;
          }

          if (this.AutoSize)
          {
            this.Size = new Size(width, height);
          }
        }
      }
    }

    #endregion Private Methods
  }
}