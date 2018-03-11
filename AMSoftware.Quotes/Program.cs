/*
Quotes Screensaver
Copyright (C) 2018 Arjan Meskers / AMSoftware

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
using System.Drawing;
using System.Windows.Forms;

namespace AMSoftware.Quotes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;

#if DEBUG
            System.Diagnostics.Debugger.Launch();
#endif

            if (args.Length > 0)
            {
                if (args[0].StartsWith("/c", StringComparison.InvariantCultureIgnoreCase)) // show config modal on parent
                {
                    if (args[0].Contains(":"))
                    {
                        ShowConfigModal(args);
                    }
                    else
                    {
                        Application.Run(new ConfigForm());
                    }
                }
                else if (args[0].Equals("/p", StringComparison.InvariantCultureIgnoreCase)) // preview screensaver
                {
                    PaintPreview(args);
                }
                else if (args[0].Equals("/s", StringComparison.InvariantCultureIgnoreCase)) // show screensaver
                {
                    Application.Run(new ScreensaverApplicationContext());
                }
            }
            else // show config modal
            {
                Application.Run(new ConfigForm());
            }
        }

        private static void PaintPreview(string[] args)
        {
            int parentHwndArgument = int.Parse(args[1]);
            using (Graphics g = Graphics.FromHwnd(new IntPtr(parentHwndArgument)))
            {
                GraphicsHelper.DrawQuote(g, QuoteHelper.GetQuote());
            }
        }

        private static void ShowConfigModal(string[] args)
        {
            var splitArgs = args[0].Split(':');
            int parentHwndArgument = int.Parse(splitArgs[1]);

            NativeWindow w = new NativeWindow();
            w.AssignHandle(new IntPtr(parentHwndArgument));

            new ConfigForm().ShowDialog(w);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }
    }
}
