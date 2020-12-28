/*
Quotes Screensaver
Copyright (C) 2020 Arjan Meskers / AMSoftware

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AMSoftware.Screensaver
{
    internal class ScreensaverWindow : NativeWindow, IDisposable
    {
        private readonly IScreensaver _context;
        private readonly bool _isPreview;

        private Graphics _windowGraphics;
        private RectangleF _clipBounds;

        private Point? _lastMousePosition = null;
        private bool disposedValue;

        public ScreensaverWindow(IScreensaver context, bool isPreview) : base()
        {
            _context = context;
            _isPreview = isPreview;
        }

        public override void CreateHandle(CreateParams cp)
        {
            base.CreateHandle(cp);

            InitGraphics();
        }

        protected override void WndProc(ref Message m)
        {
            Debugger.Log(1, "WindowsMessages", m.ToString() + "\n");

            switch (m.Msg)
            {
                case (int)WindowsMessages.WM_CREATE:
                    // Retrieve any initialization data from the Regedit.ini file. Set a window timer for the screen saver window. Perform any other required initialization.
                    _context.Initialize(_isPreview);

                    SetTimer(this.Handle, new IntPtr(1), 500, IntPtr.Zero);

                    m.Result = IntPtr.Zero;
                    break;
                case (int)WindowsMessages.WM_ERASEBKGND:
                    // Erase the screen saver window and prepare for subsequent drawing operations.
                    _windowGraphics.Clear(SystemColors.Desktop);

                    m.Result = IntPtr.Zero;
                    break;
                case (int)WindowsMessages.WM_TIMER:
                    // Perform drawing operations.
                    _context.Render(_windowGraphics, _clipBounds);

                    m.Result = IntPtr.Zero;
                    break;
                case (int)WindowsMessages.WM_DESTROY:
                    // Destroy the timers created when the application processed the WM_CREATE message. Perform any additional required cleanup
                    Dispose(true);

                    m.Result = IntPtr.Zero;
                    break;
                case (int)WindowsMessages.WM_ACTIVATE:
                    // Terminate the screen saver if the wParam parameter is set to FALSE
                    if (!_isPreview)
                    {
                        bool wParamBoolValue = Convert.ToBoolean(m.WParam.ToInt32());
                        if (wParamBoolValue == false)
                        {
                            Application.Exit();
                        }
                        m.Result = IntPtr.Zero;
                    }
                    break;
                case (int)WindowsMessages.WM_SETCURSOR:
                    // Set the cursor to the null cursor, removing it from the screen.
                    SetCursor(IntPtr.Zero);

                    m.Result = IntPtr.Zero;
                    break;
                case (int)WindowsMessages.WM_PAINT:
                    // Paint the screen background.
                    _context.RenderBackground(_windowGraphics, _clipBounds);

                    m.Result = IntPtr.Zero;
                    break;
                case (int)WindowsMessages.WM_MOUSEMOVE:
                    // Terminate the screen saver (if the mouse actually moved)
                    if (!_isPreview)
                    {
                        int lparamValue = m.LParam.ToInt32();
                        int loword = lparamValue & 0x0000FFFF;
                        int hiword = (int)((lparamValue & 0xFFFF0000) >> 16);

                        Point? p = new Point(loword, hiword);
                        if (_lastMousePosition == null)
                        {
                            _lastMousePosition = p;
                        }
                        else if (_lastMousePosition != p)
                        {
                            Application.Exit();
                        }
                        m.Result = IntPtr.Zero;
                    }
                    break;
                case (int)WindowsMessages.WM_LBUTTONDOWN:
                case (int)WindowsMessages.WM_RBUTTONDOWN:
                case (int)WindowsMessages.WM_MBUTTONDOWN:
                case (int)WindowsMessages.WM_KEYDOWN:
                    // Terminate the screen saver.
                    if (!_isPreview)
                    {
                        Application.Exit();
                        m.Result = IntPtr.Zero;
                    }
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }

        private void InitGraphics()
        {
            _windowGraphics = Graphics.FromHwnd(this.Handle);
            if (_isPreview)
            {
                _windowGraphics.ScaleTransform(
                    _windowGraphics.VisibleClipBounds.Width / Screen.PrimaryScreen.Bounds.Width,
                    _windowGraphics.VisibleClipBounds.Height / Screen.PrimaryScreen.Bounds.Height);
            }

            _windowGraphics.SmoothingMode = SmoothingMode.HighQuality;
            _windowGraphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _windowGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            _windowGraphics.CompositingQuality = CompositingQuality.HighQuality;
            _windowGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            _clipBounds = _isPreview ? Screen.PrimaryScreen.Bounds : _windowGraphics.VisibleClipBounds;
        }

        #region Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _windowGraphics.Dispose();
                }

                KillTimer(this.Handle, new IntPtr(1));

                disposedValue = true;
            }
        }

        ~ScreensaverWindow()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        [DllImport("user32.dll")]
        private static extern IntPtr SetCursor(IntPtr handle);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr SetTimer(IntPtr hWnd, IntPtr nIDEvent, uint uElapse, IntPtr lpTimerFunc);

        [DllImport("user32.dll", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool KillTimer(IntPtr hWnd, IntPtr uIDEvent);

        private enum WindowsMessages : uint
        {
            WM_CREATE = 0x0001,
            WM_DESTROY = 0x0002,
            WM_ACTIVATE = 0x0006,
            WM_PAINT = 0x000F,
            WM_ERASEBKGND = 0x0014,
            WM_SETCURSOR = 0x0020,
            WM_NCCREATE = 0x0081,
            WM_KEYDOWN = 0x0100,
            WM_TIMER = 0x0113,
            WM_MOUSEMOVE = 0x0200,
            WM_LBUTTONDOWN = 0x0201,
            WM_RBUTTONDOWN = 0x0204,
            WM_MBUTTONDOWN = 0x0207
        }
    }
}