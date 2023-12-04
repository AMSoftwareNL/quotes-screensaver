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
using AMSoftware.Screensaver;

namespace AMSoftware.QuotesScreensaver
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            System.Diagnostics.Debugger.Launch();
#else
            Application.ThreadException += Application_ThreadException;
#endif
            ScreensaverApplicationContext context = new ScreensaverApplicationContext(new QuotesScreensaver());
            context.Start();
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
