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

namespace AMSoftware.Quotes
{
    internal class RenderSettings
    {
        public Font TextFont { get; set; }
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public bool TextShrinkToFit { get; set; }
        public string BackgroundImagePath { get; set; }
        public BackgroundAlignment BackgroundAlignment { get; internal set; }
        public decimal BackgroundOpacity { get; internal set; }
    }
}