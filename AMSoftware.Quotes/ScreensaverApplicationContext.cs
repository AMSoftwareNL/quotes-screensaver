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
        private readonly QuoteManager _manager;

        public ScreensaverApplicationContext(QuoteManager manager, RenderSettings settings) : base()
        {
            _renderer = new QuoteRenderer(settings);
            _manager = manager;

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
            PictureBox pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Paint += PictureBox_Paint;

            Form f = new Form();
            f.AutoScaleMode = AutoScaleMode.Font;
            f.BackColor = settings.BackgroundColor;
            f.Cursor = Cursors.No;
            f.ForeColor = settings.TextColor;
            f.FormBorderStyle = FormBorderStyle.Sizable;
            f.Name = "MainForm";
            f.ShowIcon = false;
            f.ShowInTaskbar = false;
            f.WindowState = FormWindowState.Normal;
            f.Bounds = screen.Bounds;
            f.StartPosition = FormStartPosition.Manual;
            f.Size = new Size(screen.Bounds.Width, screen.Bounds.Height);
            f.Location = new Point(0, 0);
            f.Controls.Add(pictureBox1);
#if !DEBUG
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = true;
            f.TopMost = true;

            f.MouseDown += RegisteredForm_MouseDown;
            f.MouseMove += RegisteredForm_MouseMove;
            
#endif
            f.KeyUp += RegisteredForm_KeyUp;
            f.KeyDown += RegisteredForm_KeyDown; 
            f.Paint += RegisteredForm_Paint;

            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();

            return f;
        }

        private void SetQuote()
        {
            _quote = _manager?.ReadRandom() ?? QuoteManager.Default;

            if (_forms != null)
            {
                foreach (Form item in _forms)
                {
                    item.Controls[0].Invalidate();
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
            _renderer.RenderBackground(e.Graphics, (sender as Form).ClientRectangle);
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            _renderer.RenderText(_quote, e.Graphics, (sender as PictureBox).ClientRectangle);
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
