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
using System.Drawing;
using System.Windows.Forms;

namespace AMSoftware.Quotes
{
    internal class ScreensaverApplicationContext : ApplicationContext
    {
        private Point? _previousMouseLocation = null;
        private Quote _quote = null;
        private readonly Form[] _forms = null;
        private readonly QuoteRenderer _renderer;
        private readonly QuoteReader _reader;

        public ScreensaverApplicationContext(QuoteReader reader, RenderSettings settings) : base()
        {
            _renderer = new QuoteRenderer(settings);
            _reader = reader;

            SetQuote();

            _forms = new Form[Screen.AllScreens.Length];
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                _forms[i] = InitScreen(Screen.AllScreens[i], settings);
                _forms[i].Show();
            }
        }

        private Form InitScreen(Screen screen, RenderSettings settings)
        {
#if DEBUG
            Form f = new Form()
            {
                AutoScaleMode = AutoScaleMode.Font,
                BackColor = settings.BackgroundColor,
                Cursor = Cursors.No,
                ForeColor = settings.TextColor,
                FormBorderStyle = FormBorderStyle.Sizable,
                Name = "MainForm",
                ShowIcon = false,
                ShowInTaskbar = false,
                WindowState = FormWindowState.Normal,
                Bounds = screen.Bounds,
                StartPosition = FormStartPosition.Manual,
                Size = new Size(screen.Bounds.Width, screen.Bounds.Height),
                Location = new Point(0, 0),
            };
#else
            Form f = new Form()
            {
                AutoScaleMode = AutoScaleMode.Font,
                BackColor = settings.BackgroundColor,
                Cursor = Cursors.No,
                ForeColor = settings.TextColor,
                FormBorderStyle = FormBorderStyle.None,
                Name = "MainForm",
                ShowIcon = false,
                ShowInTaskbar = false,
                WindowState = FormWindowState.Normal,
                Bounds = screen.Bounds,
                StartPosition = FormStartPosition.Manual,
                Size = new Size(screen.Bounds.Width, screen.Bounds.Height),
                Location = new Point(0, 0),
                TopLevel = true,
                TopMost = true
            };

            f.MouseDown += RegisteredForm_MouseDown;
            f.MouseMove += RegisteredForm_MouseMove;
#endif
            f.Paint += RegisteredForm_Paint;
            f.KeyUp += RegisteredForm_KeyUp;
            f.KeyDown += RegisteredForm_KeyDown;

            return f;
        }

        private void SetQuote()
        {
            _quote = _reader?.Read() ?? QuoteReader.Default;

            if (_forms != null)
            {
                foreach (Form item in _forms)
                {
                    item.Refresh();
                }
            }
        }

        private void RegisteredForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_previousMouseLocation == null)
            {
                _previousMouseLocation = e.Location;
            }
            else if (e.Location != _previousMouseLocation.Value)
            {
                ExitThread();
            }
        }

        private void RegisteredForm_MouseDown(object sender, MouseEventArgs e)
        {
            ExitThread();
        }

        private void RegisteredForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space)
            {
                e.SuppressKeyPress = true;
                ExitThread();
            }
        }

        private void RegisteredForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                SetQuote();
            }
        }

        private void RegisteredForm_Paint(object sender, PaintEventArgs e)
        {
            _renderer.Render(_quote, e.Graphics);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        ~ScreensaverApplicationContext()
        {
            Dispose(false);
        }
    }
}
