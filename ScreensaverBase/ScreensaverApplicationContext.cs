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
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AMSoftware.Screensaver
{
    internal class ScreensaverApplicationContext : ApplicationContext
    {
        #region Win32 API Declarations
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        #endregion

        private readonly IScreensaver _screensaver;

        public ScreensaverApplicationContext(IScreensaver screensaver)
        {
            _screensaver = screensaver;
        }

        internal void Start()
        {
            // Parse the arguments:
            //   -s         (Run the screensaver)
            //   -p <hwnd>  (Preview)
            //   -c <hwnd>  (Configure)

            IntPtr parentHwnd = IntPtr.Zero;

            string executable = Environment.GetCommandLineArgs()[0];
            string commandLine = Environment.CommandLine.Replace(executable, string.Empty);

            string[] commandLineArgs = commandLine.Split(new char[] { ' ', '-', '/', ':' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < commandLineArgs.Length; i++)
            {
                string commandLineArg = commandLineArgs[i];
                string commandLineParameter = i + 1 < commandLineArgs.Length ? commandLineArgs[i + 1] : null;

                switch (commandLineArg)
                {
                    case "s":
                    case "S":
                        LaunchScreenSaver(parentHwnd);
                        return;
                    case "p":
                    case "P":
                        if (int.TryParse(commandLineParameter, out int previewParentHwnd))
                            parentHwnd = new IntPtr(previewParentHwnd);

                        if (parentHwnd != IntPtr.Zero && IsWindow(parentHwnd))
                            LaunchScreenSaver(parentHwnd);
                        else
                            throw new ArgumentException($"Unsupported parent window handle [{commandLineParameter}].");

                        return;
                    case "c":
                    case "C":
                        if (int.TryParse(commandLineParameter, out int configParentHwnd))
                            parentHwnd = new IntPtr(configParentHwnd);
                        else
                            parentHwnd = GetForegroundWindow();

                        if (parentHwnd != IntPtr.Zero && IsWindow(parentHwnd))
                            LaunchConfig(parentHwnd);

                        return;
                    default:
                        break;
                }
            }

            //LaunchConfig(parentHwnd);
        }

        private void LaunchScreenSaver(IntPtr parentHwnd)
        {
            if (parentHwnd == IntPtr.Zero)
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    CreateParams windowParams = new CreateParams()
                    {
                        ExStyle = unchecked((int)(WindowStylesEx.WS_EX_TOOLWINDOW | WindowStylesEx.WS_EX_TOPMOST)),
                        Caption = "Screensaver",
                        Style = unchecked((int)(WindowStyles.WS_POPUP | WindowStyles.WS_VISIBLE | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_CLIPCHILDREN)),
                        X = screen.Bounds.X,
                        Y = screen.Bounds.Y,
                        Width = screen.Bounds.Width,
                        Height = screen.Bounds.Height,
                        Parent = IntPtr.Zero,
                        ClassStyle = unchecked((int)(ClassStyles.VerticalRedraw | ClassStyles.HorizontalRedraw | ClassStyles.DoubleClicks | ClassStyles.SaveBits | ClassStyles.ParentDC)),
                        Param = null
                    };

                    ScreensaverWindow window = new ScreensaverWindow(_screensaver, false);
                    window.CreateHandle(windowParams);
                }
            } else
            {
                //Preview
                GetClientRect(parentHwnd, out RECT rct);

                CreateParams windowParams = new CreateParams()
                {
                    ExStyle = unchecked(0),
                    Caption = "Preview",
                    Style = unchecked((int)(WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_CLIPCHILDREN)),
                    X = rct.Left,
                    Y = rct.Top,
                    Width = rct.Right - rct.Left,
                    Height = rct.Bottom - rct.Top,
                    Parent = parentHwnd,
                    ClassStyle = unchecked((int)(ClassStyles.VerticalRedraw | ClassStyles.HorizontalRedraw | ClassStyles.DoubleClicks | ClassStyles.SaveBits | ClassStyles.ParentDC)),
                    Param = null
                };
                ScreensaverWindow window = new ScreensaverWindow(_screensaver, true);
                window.CreateHandle(windowParams);
            }

            Application.Run(this);
        }

        private void LaunchConfig(IntPtr parentHwnd)
        {
            Form configForm = _screensaver.ConfigurationDialog;
            if (configForm != null)
            {
                if (parentHwnd != IntPtr.Zero)
                {
                    NativeWindow parentWindow = new NativeWindow();
                    parentWindow.AssignHandle(parentHwnd);

                    configForm.Show(parentWindow);
                }
                else
                {
                    configForm.Show();
                }

                Application.Run(configForm);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        ~ScreensaverApplicationContext()
        {
            Dispose(false);
        }

        #region Win32 API Declarations
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(SystemMetric smIndex);
        #endregion

        #region Win32 API Enums and Structs
        [Flags]
        private enum WindowStyles : uint
        {
            WS_BORDER = 0x800000,
            WS_CAPTION = 0xc00000,
            WS_CHILD = 0x40000000,
            WS_CLIPCHILDREN = 0x2000000,
            WS_CLIPSIBLINGS = 0x4000000,
            WS_DISABLED = 0x8000000,
            WS_DLGFRAME = 0x400000,
            WS_GROUP = 0x20000,
            WS_HSCROLL = 0x100000,
            WS_MAXIMIZE = 0x1000000,
            WS_MAXIMIZEBOX = 0x10000,
            WS_MINIMIZE = 0x20000000,
            WS_MINIMIZEBOX = 0x20000,
            WS_OVERLAPPED = 0x0,
            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
            WS_POPUP = 0x80000000,
            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
            WS_SIZEFRAME = 0x40000,
            WS_SYSMENU = 0x80000,
            WS_TABSTOP = 0x10000,
            WS_VISIBLE = 0x10000000,
            WS_VSCROLL = 0x200000
        }

        [Flags]
        private enum WindowStylesEx : uint
        {
            WS_EX_ACCEPTFILES = 0x10,
            WS_EX_APPWINDOW = 0x40000,
            WS_EX_CLIENTEDGE = 0x200,
            WS_EX_COMPOSITED = 0x2000000,
            WS_EX_CONTEXTHELP = 0x400,
            WS_EX_CONTROLPARENT = 0x10000,
            WS_EX_DLGMODALFRAME = 0x1,
            WS_EX_LAYERED = 0x80000,
            WS_EX_LAYOUTRTL = 0x400000,
            WS_EX_LEFT = 0x0,
            WS_EX_LEFTSCROLLBAR = 0x4000,
            WS_EX_LTRREADING = 0x0,
            WS_EX_MDICHILD = 0x40,
            WS_EX_NOACTIVATE = 0x8000000,
            WS_EX_NOINHERITLAYOUT = 0x100000,
            WS_EX_NOPARENTNOTIFY = 0x4,
            WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
            WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
            WS_EX_RIGHT = 0x1000,
            WS_EX_RIGHTSCROLLBAR = 0x0,
            WS_EX_RTLREADING = 0x2000,
            WS_EX_STATICEDGE = 0x20000,
            WS_EX_TOOLWINDOW = 0x80,
            WS_EX_TOPMOST = 0x8,
            WS_EX_TRANSPARENT = 0x20,
            WS_EX_WINDOWEDGE = 0x100
        }

        [Flags]
        private enum ClassStyles : uint
        {
            ByteAlignClient = 0x1000,
            ByteAlignWindow = 0x2000,
            ClassDC = 0x40,
            DoubleClicks = 0x8,
            DropShadow = 0x20000,
            GlobalClass = 0x4000,
            HorizontalRedraw = 0x2,
            NoClose = 0x200,
            OwnDC = 0x20,
            ParentDC = 0x80,
            SaveBits = 0x800,
            VerticalRedraw = 0x1
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public static implicit operator System.Drawing.Rectangle(RECT r)
            {
                return new System.Drawing.Rectangle(r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top);
            }

            public static implicit operator RECT(System.Drawing.Rectangle r)
            {
                return new RECT(r);
            }
        }

        private enum SystemMetric : uint
        {
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CYCAPTION = 4,  // 0x04
            SM_CXBORDER = 5,  // 0x05
            SM_CYBORDER = 6,  // 0x06
            SM_CXDLGFRAME = 7,  // 0x07
            SM_CXFIXEDFRAME = 7,  // 0x07
            SM_CYDLGFRAME = 8,  // 0x08
            SM_CYFIXEDFRAME = 8,  // 0x08
            SM_CYVTHUMB = 9,  // 0x09
            SM_CXHTHUMB = 10, // 0x0A
            SM_CXICON = 11, // 0x0B
            SM_CYICON = 12, // 0x0C
            SM_CXCURSOR = 13, // 0x0D
            SM_CYCURSOR = 14, // 0x0E
            SM_CYMENU = 15, // 0x0F
            SM_CXFULLSCREEN = 16, // 0x10
            SM_CYFULLSCREEN = 17, // 0x11
            SM_CYKANJIWINDOW = 18, // 0x12
            SM_MOUSEPRESENT = 19, // 0x13
            SM_CYVSCROLL = 20, // 0x14
            SM_CXHSCROLL = 21, // 0x15
            SM_DEBUG = 22, // 0x16
            SM_SWAPBUTTON = 23, // 0x17
            SM_CXMIN = 28, // 0x1C
            SM_CYMIN = 29, // 0x1D
            SM_CXSIZE = 30, // 0x1E
            SM_CYSIZE = 31, // 0x1F
            SM_CXSIZEFRAME = 32, // 0x20
            SM_CXFRAME = 32, // 0x20
            SM_CYSIZEFRAME = 33, // 0x21
            SM_CYFRAME = 33, // 0x21
            SM_CXMINTRACK = 34, // 0x22
            SM_CYMINTRACK = 35, // 0x23
            SM_CXDOUBLECLK = 36, // 0x24
            SM_CYDOUBLECLK = 37, // 0x25
            SM_CXICONSPACING = 38, // 0x26
            SM_CYICONSPACING = 39, // 0x27
            SM_MENUDROPALIGNMENT = 40, // 0x28
            SM_PENWINDOWS = 41, // 0x29
            SM_DBCSENABLED = 42, // 0x2A
            SM_CMOUSEBUTTONS = 43, // 0x2B
            SM_SECURE = 44, // 0x2C
            SM_CXEDGE = 45, // 0x2D
            SM_CYEDGE = 46, // 0x2E
            SM_CXMINSPACING = 47, // 0x2F
            SM_CYMINSPACING = 48, // 0x30
            SM_CXSMICON = 49, // 0x31
            SM_CYSMICON = 50, // 0x32
            SM_CYSMCAPTION = 51, // 0x33
            SM_CXSMSIZE = 52, // 0x34
            SM_CYSMSIZE = 53, // 0x35
            SM_CXMENUSIZE = 54, // 0x36
            SM_CYMENUSIZE = 55, // 0x37
            SM_ARRANGE = 56, // 0x38
            SM_CXMINIMIZED = 57, // 0x39
            SM_CYMINIMIZED = 58, // 0x3A
            SM_CXMAXTRACK = 59, // 0x3B
            SM_CYMAXTRACK = 60, // 0x3C
            SM_CXMAXIMIZED = 61, // 0x3D
            SM_CYMAXIMIZED = 62, // 0x3E
            SM_NETWORK = 63, // 0x3F
            SM_CLEANBOOT = 67, // 0x43
            SM_CXDRAG = 68, // 0x44
            SM_CYDRAG = 69, // 0x45
            SM_SHOWSOUNDS = 70, // 0x46
            SM_CXMENUCHECK = 71, // 0x47
            SM_CYMENUCHECK = 72, // 0x48
            SM_SLOWMACHINE = 73, // 0x49
            SM_MIDEASTENABLED = 74, // 0x4A
            SM_MOUSEWHEELPRESENT = 75, // 0x4B
            SM_XVIRTUALSCREEN = 76, // 0x4C
            SM_YVIRTUALSCREEN = 77, // 0x4D
            SM_CXVIRTUALSCREEN = 78, // 0x4E
            SM_CYVIRTUALSCREEN = 79, // 0x4F
            SM_CMONITORS = 80, // 0x50
            SM_SAMEDISPLAYFORMAT = 81, // 0x51
            SM_IMMENABLED = 82, // 0x52
            SM_CXFOCUSBORDER = 83, // 0x53
            SM_CYFOCUSBORDER = 84, // 0x54
            SM_TABLETPC = 86, // 0x56
            SM_MEDIACENTER = 87, // 0x57
            SM_STARTER = 88, // 0x58
            SM_SERVERR2 = 89, // 0x59
            SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
            SM_CXPADDEDBORDER = 92, // 0x5C
            SM_DIGITIZER = 94, // 0x5E
            SM_MAXIMUMTOUCHES = 95, // 0x5F

            SM_REMOTESESSION = 0x1000, // 0x1000
            SM_SHUTTINGDOWN = 0x2000, // 0x2000
            SM_REMOTECONTROL = 0x2001, // 0x2001


            SM_CONVERTIBLESLATEMODE = 0x2003,
            SM_SYSTEMDOCKED = 0x2004,
        }
        #endregion
    }
}
