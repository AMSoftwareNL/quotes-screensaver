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
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace AMSoftware.Quotes
{
    internal static class GraphicsHelper
    {
        public static void DrawQuote(Graphics g, Quote q, Settings s = null)
        {
            if (s == null) s = Settings.Default;

            g.Clear(s.QuotesBackgroundColor);

            if (q == null)
            {
                g.Flush(FlushIntention.Flush);
                return;
            }

            float marginLeft = g.VisibleClipBounds.Width * 0.05F;
            float marginTop = g.VisibleClipBounds.Height * 0.05F;

            SizeF layoutArea = new SizeF(
                g.VisibleClipBounds.Width - (2.0F * marginLeft),
                g.VisibleClipBounds.Height - (2.0F * marginTop)
            );

            PointF layoutOffset = new PointF(marginLeft, marginTop);

            DrawQuoteText(q.QuoteText, g, s.QuotesFont, s.QuotesColor, layoutArea, layoutOffset);
            DrawAuthorText(BuildAuthorText(q), g, s.QuotesFont, s.QuotesColor, layoutArea, layoutOffset);

            g.Flush(FlushIntention.Flush);
        }

        private static void DrawAuthorText(string author, Graphics g, Font textFont, Color textColor, SizeF layoutArea, PointF layoutOffset)
        {
            Font authorFont = new Font(textFont.FontFamily, g.VisibleClipBounds.Height * 0.025F, FontStyle.Italic, GraphicsUnit.Pixel);

            SizeF authorTextSize = g.MeasureString(author, authorFont, layoutArea);
            PointF authorTextOffset = new PointF(
                (g.VisibleClipBounds.Right - layoutOffset.X - authorTextSize.Width),
                (g.VisibleClipBounds.Bottom - layoutOffset.Y - authorTextSize.Height)
            );
            RectangleF printArea = new RectangleF(authorTextOffset, authorTextSize);

            g.DrawString(author, authorFont, new SolidBrush(textColor), printArea);
        }

        private static void DrawQuoteText(string[] lines, Graphics g, Font textFont, Color textColor, SizeF layoutArea, PointF layoutOffset)
        {
            Font quoteFont = new Font(textFont.FontFamily, g.VisibleClipBounds.Height * 0.075F, textFont.Style, GraphicsUnit.Pixel);

            switch (lines.Length)
            {
                case 1:
                    DrawOnelineQuoteText(lines[0], g, quoteFont, textColor, layoutArea, layoutOffset);
                    break;
                case 2:
                    DrawTwolineQuoteText(lines[0], lines[1], g, quoteFont, textColor, layoutArea, layoutOffset);
                    break;
                default:
                    DrawMultilineQuoteText(lines, g, quoteFont, textColor, layoutArea, layoutOffset);
                    break;
            }
        }

        private static void DrawOnelineQuoteText(string text, Graphics g, Font font, Color textColor, SizeF layoutArea, PointF layoutOffset)
        {
            SizeF textSize = g.MeasureString(text, font, layoutArea);
            PointF textOffset = new PointF(
                ((layoutArea.Width - textSize.Width) / 2.0F) + layoutOffset.X,
                ((layoutArea.Height - textSize.Height) / 2.0F) + layoutOffset.Y
            );

            g.DrawString(text, font, new SolidBrush(textColor), new RectangleF(textOffset, layoutArea));
        }

        private static void DrawTwolineQuoteText(string line1, string line2, Graphics g, Font font, Color textColor, SizeF layoutArea, PointF layoutOffset)
        {
            SizeF textSize1 = g.MeasureString(line1, font, layoutArea);
            SizeF textSize2 = g.MeasureString(line2, font, layoutArea);

            float textWidth = Math.Min(Math.Max(textSize1.Width, textSize2.Width) * 1.50F, layoutArea.Width);
            float textHeight = textSize1.Height + textSize2.Height;

            PointF textOffset1 = new PointF(
                ((layoutArea.Width - textWidth) / 2.0F) + layoutOffset.X,
                ((layoutArea.Height - textHeight) / 2.0F) + layoutOffset.Y
            );
            g.DrawString(line1, font, new SolidBrush(textColor), new RectangleF(textOffset1, layoutArea));

            PointF textOffset2 = new PointF(
                ((layoutArea.Width - textWidth) / 2.0F) + layoutOffset.X + textWidth - textSize2.Width,
                ((layoutArea.Height - textHeight) / 2.0F) + layoutOffset.Y + textHeight - textSize2.Height
            );
            g.DrawString(line2, font, new SolidBrush(textColor), new RectangleF(textOffset2, layoutArea));
        }

        private static void DrawMultilineQuoteText(string[] lines, Graphics g, Font font, Color textColor, SizeF layoutArea, PointF layoutOffset)
        {
            float textHeight = lines.Sum(l => g.MeasureString(l, font, layoutArea).Height);

            float nextOffset = 0;
            foreach (string line in lines)
            {
                SizeF textSize = g.MeasureString(line, font, layoutArea);
                PointF textOffset = new PointF(
                    ((layoutArea.Width - textSize.Width) / 2.0F) + layoutOffset.X,
                    ((layoutArea.Height - textHeight) / 2.0F) + layoutOffset.Y + nextOffset
                );
                nextOffset += textSize.Height;

                g.DrawString(line, font, new SolidBrush(textColor), new RectangleF(textOffset, layoutArea));
            }
        }

        private static string BuildAuthorText(Quote quote)
        {
            string authorText = string.Empty;
            if (!string.IsNullOrWhiteSpace(quote.Author))
            {
                authorText = quote.Author;
            }
            if (!string.IsNullOrWhiteSpace(quote.Year))
            {
                if (string.IsNullOrWhiteSpace(authorText))
                {
                    authorText = quote.Year;
                }
                else
                {
                    authorText = string.Format("{0} - {1}", authorText, quote.Year);
                }
            }

            return authorText;
        }
    }

    internal static class QuoteHelper
    {
        public static Quote GetQuote()
        {
            string filePath = Path.Combine(Settings.Default.QuotesPath, "quotes.xml");
            if (!string.IsNullOrWhiteSpace(Settings.Default.QuotesPath) && Directory.Exists(Settings.Default.QuotesPath) && !File.Exists(filePath))
            {
                using (Stream s = File.OpenWrite(filePath)) {
                    XmlSerializer serializer = new XmlSerializer(typeof(Quotes));
                    serializer.Serialize(s, new Quotes());
                }
            }

            if (File.Exists(filePath))
            {
                using (Stream s = File.OpenRead(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Quotes));
                    Quotes quotes = serializer.Deserialize(s) as Quotes;
                    if (quotes.Count == 0) return null;

                    Random r = new Random();
                    return quotes[r.Next(0, quotes.Count - 1)];
                }
            }

            return new Quote()
            {
                Author = "Quotes Screensaver",
                Year = "2018",
                QuoteText = new string[] { "Lorem ipsum dolor sit amet,", "consectetuer adipiscing elit" }
            };
        }
    }
}
