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
using AMSoftware.QuotesScreensaver.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using AMSoftware.Screensaver;

namespace AMSoftware.QuotesScreensaver
{
    internal class QuotesScreensaver : IScreensaver
    {
        private Quote _quote = null;
        private QuoteRenderer _renderer = null;

        private bool _isInitialized = false;

        public Form ConfigurationDialog
        {
            get
            {
                return new ConfigForm();
            }
        }

        public void Initialize(bool isPreview)
        {
            if (_isInitialized) return;

            _isInitialized = true;

            _renderer = new QuoteRenderer(new RenderSettings()
            {
                BackgroundAlignment = (BackgroundAlignment)Settings.Default.BackgroundAlignment,
                BackgroundColor = Settings.Default.BackgroundColor,
                BackgroundImagePath = Settings.Default.BackgroundImagePath,
                BackgroundOpacity = Settings.Default.BackgroundOpacity,
                TextAlignment = (TextAlignment)Settings.Default.TextAlignment,
                TextColor = Settings.Default.TextColor,
                TextFont = Settings.Default.TextFont
            });
 
            QuoteManager manager = QuoteManager.Create(Settings.Default.SourcePath);
            if (manager != null)
            {
                _quote = manager.ReadRandom();
            } else
            {
                _quote = QuoteManager.Default;
            }
        }

        public void Render(Graphics g, RectangleF bounds)
        {
                _renderer.RenderText(_quote, g, bounds);
        }

        public void RenderBackground(Graphics g, RectangleF bounds)
        {
            BufferedGraphicsContext bufferedGraphicsContext = BufferedGraphicsManager.Current;
            using (BufferedGraphics bufferedGraphics = bufferedGraphicsContext.Allocate(g, Rectangle.Round(bounds)))
            {
                _renderer.RenderBackground(bufferedGraphics.Graphics, bounds);

                bufferedGraphics.Render(g);
            }
        }
    }
}
