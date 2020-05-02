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
using AMSoftware.Quotes.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AMSoftware.Quotes
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            System.Diagnostics.Debugger.Launch();
#else
            Application.ThreadException += Application_ThreadException;
#endif

            if (args.Length > 0)
            {
                var splitArgs = args[0].Split(':');
                string commandArgument = splitArgs[0];
                int parentHwndArgument = 0;

                if (commandArgument.Equals("/c", StringComparison.InvariantCultureIgnoreCase)) // show config modal
                {
                    if (splitArgs.Length == 2)
                    {
                        int.TryParse(splitArgs[1], out parentHwndArgument);
                    }
                    RunConfiguration(parentHwndArgument);
                }
                else if (commandArgument.Equals("/p", StringComparison.InvariantCultureIgnoreCase)) // preview screensaver
                {
                    if (args.Length >= 2 && int.TryParse(args[1], out parentHwndArgument))
                    {
                        RunPreview(parentHwndArgument);
                    }
                    else
                    {
                        throw new ArgumentException("Missing or invalid parent window handle.");
                    }
                }
                else if (commandArgument.Equals("/s", StringComparison.InvariantCultureIgnoreCase)) // show screensaver
                {
                    QuoteManager manager = InitManager();
                    RenderSettings renderSettings = InitRenderSettings();
                    Application.Run(new ScreensaverApplicationContext(manager, renderSettings));
                }
            }
            else // show config non-modal
            {
                Application.Run(new ConfigForm());
            }
        }

        private static void RunPreview(int parentHwndArgument)
        {
            QuoteManager manager = InitManager();
            RenderSettings renderSettings = InitRenderSettings();
            QuoteRenderer renderer = new QuoteRenderer(renderSettings);

            Quote quote = manager?.ReadRandom() ?? QuoteManager.Default;
            using (Graphics g = Graphics.FromHwnd(new IntPtr(parentHwndArgument)))
            {
                renderer.RenderBackground(g, Screen.PrimaryScreen.Bounds);
                renderer.RenderText(quote, g, Screen.PrimaryScreen.Bounds);
            }
        }

        private static void RunConfiguration(int parentHwndArgument)
        {
            NativeWindow parentWindow = new NativeWindow();
            if (parentHwndArgument != 0)
            {
                parentWindow.AssignHandle(new IntPtr(parentHwndArgument));
            }

            ConfigForm form = new ConfigForm();
            form.ShowDialog(parentWindow);
        }

        private static RenderSettings InitRenderSettings()
        {
            return new RenderSettings()
            {
                TextFont = Settings.Default.TextFont,
                TextColor = Settings.Default.TextColor,
                TextAlignment = (TextAlignment)Settings.Default.TextAlignment,
                TextShrinkToFit = Settings.Default.TextShrinkToFit,
                BackgroundColor = Settings.Default.BackgroundColor,
                BackgroundImagePath = Settings.Default.BackgroundImagePath,
                BackgroundAlignment = (BackgroundAlignment)Settings.Default.BackgroundAlignment,
                BackgroundOpacity = Settings.Default.BackgroundOpacity
            };
        }

        private static QuoteManager InitManager()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Settings.Default.SourcePath))
                {
                    return null;
                }

                return QuoteManager.Create(Settings.Default.SourcePath);
            }
            catch
            {
                return null;
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
