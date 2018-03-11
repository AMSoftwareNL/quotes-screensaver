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
    public class ScreensaverApplicationContext : ApplicationContext
    {
        internal event EventHandler<QuoteEventArgs> QuoteChanged;

        private Point? _previousMouseLocation = null;

        public ScreensaverApplicationContext() : base()
        {
            foreach (Screen item in Screen.AllScreens)
            {
                MainForm screenForm = new MainForm
                {
                    Bounds = item.Bounds,
                    StartPosition = FormStartPosition.Manual
                };

                this.QuoteChanged += screenForm.MainForm_QuoteChanged;

                screenForm.KeyDown += RegisteredForm_KeyDown;
                screenForm.KeyUp += RegisteredForm_KeyUp;
                screenForm.MouseDown += RegisteredForm_MouseDown;
                screenForm.MouseMove += RegisteredForm_MouseMove;

                screenForm.Show();
            }

            OnQuoteChanged(new QuoteEventArgs()
            {
                NewQuote = QuoteHelper.GetQuote()
            });
        }

        private void RegisteredForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_previousMouseLocation == null)
            {
                _previousMouseLocation = e.Location;
            } else if (e.Location != _previousMouseLocation.Value)
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
                OnQuoteChanged(new QuoteEventArgs()
                {
                    NewQuote = QuoteHelper.GetQuote()
                });
            }
        }

        protected virtual void OnQuoteChanged(QuoteEventArgs e)
        {
            QuoteChanged?.Invoke(this, e);
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
