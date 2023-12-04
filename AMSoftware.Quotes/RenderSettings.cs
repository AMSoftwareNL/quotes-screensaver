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
using System.Drawing;

namespace AMSoftware.QuotesScreensaver
{
    internal class RenderSettings
    {
        public Font TextFont { get; set; }
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public string BackgroundImagePath { get; set; }
        public BackgroundAlignment BackgroundAlignment { get; internal set; }
        public decimal BackgroundOpacity { get; internal set; }
    }

    internal enum TextAlignment
    {
        Auto = 0,
        Left,
        Center,
        Right
    }

    internal enum BackgroundAlignment
    {
        Fill = 0,
        Fit,
        Stretch,
        Tile,
        Center
    }
}