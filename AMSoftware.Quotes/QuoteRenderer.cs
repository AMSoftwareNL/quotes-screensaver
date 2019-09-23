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
using System.Drawing.Drawing2D;
using System.Linq;

namespace AMSoftware.Quotes
{
    internal class QuoteRenderer
    {
        private readonly RenderSettings _settings;

        public QuoteRenderer(RenderSettings settings)
        {
            _settings = settings;
        }

        public void Render(Quote q, Graphics g)
        {
            RectangleF clipBounds = g.VisibleClipBounds;

            RenderBackground(g, clipBounds);
            RenderText(q, g, clipBounds);

            g.Flush(FlushIntention.Flush);
        }

        public void Render(Quote q, Graphics g, RectangleF measureBounds)
        {
            g.ScaleTransform(
                g.VisibleClipBounds.Width / measureBounds.Width,
                g.VisibleClipBounds.Height / measureBounds.Height,
                MatrixOrder.Append);

            RenderBackground(g, measureBounds);
            RenderText(q, g, measureBounds);

            g.Flush(FlushIntention.Flush);
        }

        private void RenderText(Quote q, Graphics g, RectangleF displayBounds)
        {
            if (q == null) return;

            // Set a margin of 5%
            float marginLeft = displayBounds.Width * 0.05F;
            float marginTop = displayBounds.Height * 0.05F;
            RectangleF layoutArea = new RectangleF(
                marginLeft,
                marginTop,
                displayBounds.Width - (2.0F * marginLeft),
                displayBounds.Height - (2.0F * marginTop)
            );

            // Print author and year of quote.
            // Textsize is 2.5% of bound height. Independent of selected fontsize.
            Font authorFont = new Font(_settings.TextFont.FontFamily, layoutArea.Height * 0.025F, FontStyle.Italic);
            DrawAuthorText(BuildAuthorText(q), g, authorFont, _settings.TextColor, layoutArea);

            // Check if text fits in layout area with current font settings.
            // Else shrink font to fit to layout area.
            // Use quote as one string, as alignment doesn't matter.
            Font textFont = _settings.TextFont;
            if (_settings.TextShrinkToFit)
            {
                textFont = GetFittedFont(string.Join("\n", q.QuoteText), g, textFont, layoutArea);
            }

            if (_settings.TextAlignment != TextAlignment.Auto)
            {
                DrawAlignedQuoteText(string.Join("\n", q.QuoteText), g, textFont, _settings.TextColor, _settings.TextAlignment, layoutArea);
            }
            else
            {
                if (q.QuoteText.Length == 1)
                {
                    DrawAlignedQuoteText(q.QuoteText[0], g, textFont, _settings.TextColor, TextAlignment.Center, layoutArea);
                }
                else
                {
                    DrawQuoteText(q.QuoteText, g, textFont, _settings.TextColor, layoutArea);
                }
            }
        }

        private void RenderBackground(Graphics g, RectangleF displayBounds)
        {
            g.Clear(_settings.BackgroundColor);

            if (!string.IsNullOrWhiteSpace(_settings.BackgroundImagePath))
            {
                try
                {
                    Image backgroundImage = Image.FromFile(_settings.BackgroundImagePath);

                    switch (_settings.BackgroundAlignment)
                    {
                        case BackgroundAlignment.Fit:
                            DrawBackgroundFitted(g, backgroundImage, displayBounds);
                            break;
                        case BackgroundAlignment.Stretch:
                            DrawBackgroundStretched(g, backgroundImage, displayBounds);
                            break;
                        case BackgroundAlignment.Center:
                            DrawBackgroundCentered(g, backgroundImage, displayBounds);
                            break;
                        case BackgroundAlignment.Tile:
                            DrawBackgroundTiled(g, backgroundImage, displayBounds);
                            break;
                        default:
                            break;
                    }
                }
                catch { }
            }
        }

        private static void DrawBackgroundFitted(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            float ratioScreen = displayBounds.Width / displayBounds.Height;
            float ratioImage = (float)backgroundImage.Width / (float)backgroundImage.Height;

            if (ratioScreen > ratioImage)
            {
                float width = displayBounds.Height * ratioImage;
                RectangleF destRectangle = new RectangleF(
                    (displayBounds.Width - width) / 2, 0,
                    width, displayBounds.Height);

                g.DrawImage(backgroundImage, destRectangle);
            }
            else
            {
                float height = displayBounds.Width * ratioImage;
                RectangleF destRectangle = new RectangleF(
                    0, (displayBounds.Height - height) / 2,
                    displayBounds.Width, height);

                g.DrawImage(backgroundImage, destRectangle);
            }
        }

        private static void DrawBackgroundStretched(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            float ratioScreen = displayBounds.Width / displayBounds.Height;
            float ratioImage = (float)backgroundImage.Width / (float)backgroundImage.Height;

            if (ratioScreen > ratioImage)
            {
                float height = backgroundImage.Width / ratioScreen;
                RectangleF srcRectangle = new RectangleF(
                    0, (backgroundImage.Height - height) / 2,
                    backgroundImage.Width, height);

                g.DrawImage(backgroundImage, displayBounds, srcRectangle, GraphicsUnit.Pixel);
            }
            else
            {
                float width = backgroundImage.Height / ratioScreen;
                RectangleF srcRectangle = new RectangleF(
                    (backgroundImage.Width - width) / 2, 0,
                    width, backgroundImage.Height);

                g.DrawImage(backgroundImage, displayBounds, srcRectangle, GraphicsUnit.Pixel);
            }
        }

        private static void DrawBackgroundTiled(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            Rectangle srcRectangle = new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height);

            int tileCountWidth = (int)Math.Ceiling(displayBounds.Width / srcRectangle.Width);
            int tileCountHeight = (int)Math.Ceiling(displayBounds.Height / srcRectangle.Height);

            int offsetX = (int)Math.Round(((tileCountWidth * srcRectangle.Width) - displayBounds.Width) / 2);
            int offsetY = (int)Math.Round(((tileCountHeight * srcRectangle.Height) - displayBounds.Height) / 2); ;

            for (int y = 0; y < tileCountHeight; y++)
            {
                for (int x = 0; x < tileCountWidth; x++)
                {
                    Rectangle destRectangle = new Rectangle((x * srcRectangle.Width) - offsetX, (y * srcRectangle.Height) - offsetY, srcRectangle.Width, srcRectangle.Height);
                    g.DrawImageUnscaledAndClipped(backgroundImage, destRectangle);
                }
            }
        }

        private static void DrawBackgroundCentered(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            Rectangle destRectangle = new Rectangle()
            {
                Width = backgroundImage.Width,
                Height = backgroundImage.Height,
                X = (int)Math.Round((displayBounds.Width - backgroundImage.Width) / 2),
                Y = (int)Math.Round((displayBounds.Height - backgroundImage.Height) / 2)
            };

            g.DrawImageUnscaledAndClipped(backgroundImage, destRectangle);
        }

        private static Font GetFittedFont(string text, Graphics g, Font textFont, RectangleF area)
        {
            SizeF textSize = g.MeasureString(text, textFont);
            if (textSize.Width > area.Width || textSize.Height > area.Height)
            {
                // Text to large determine shrink factor
                float shrinkFactorHeight = area.Height / textSize.Height;
                float shrinkFactorWidth = area.Width / textSize.Width;

                if (shrinkFactorHeight < shrinkFactorWidth)
                {
                    return new Font(textFont.FontFamily, textFont.Size * shrinkFactorHeight, textFont.Style);
                }
                else
                {
                    return new Font(textFont.FontFamily, textFont.Size * shrinkFactorWidth, textFont.Style);
                }

            }
            else
            {
                return textFont;
            }
        }

        private static void DrawAuthorText(string text, Graphics g, Font textFont, Color textColor, RectangleF layoutArea)
        {
            g.DrawString(text, textFont, new SolidBrush(textColor), layoutArea, new StringFormat()
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Far
            });
        }

        private static void DrawAlignedQuoteText(string text, Graphics g, Font font, Color textColor, TextAlignment alignment, RectangleF layoutArea)
        {
            StringFormat format = new StringFormat()
            {
                LineAlignment = StringAlignment.Center
            };

            switch (alignment)
            {
                case TextAlignment.Auto:
                    format.Alignment = StringAlignment.Center;
                    break;
                case TextAlignment.Left:
                    format.Alignment = StringAlignment.Near;
                    break;
                case TextAlignment.Center:
                    format.Alignment = StringAlignment.Center;
                    break;
                case TextAlignment.Right:
                    format.Alignment = StringAlignment.Far;
                    break;
                default:
                    break;
            }

            g.DrawString(text, font, new SolidBrush(textColor), layoutArea, format);
        }

        private static void DrawQuoteText(string[] lines, Graphics g, Font font, Color textColor, RectangleF layoutArea)
        {
            // Align text left and right for even and uneven lines.
            // If text is wider than half a screen align with ayout area.
            // If text is less wide than half a screen, align width center screen
            // Height is always centered

            float textHeight = lines.Sum(l => g.MeasureString(l, font, layoutArea.Size).Height);
            float nextOffset = ((layoutArea.Height - textHeight) / 2) + layoutArea.Y;

            bool alignLeft = true;
            RectangleF printArea = new RectangleF();
            StringFormat printFormat = new StringFormat();

            foreach (string line in lines)
            {
                SizeF textSize = g.MeasureString(line, font, layoutArea.Size);

                if (textSize.Width < layoutArea.Width / 2)
                {
                    printFormat.Alignment = alignLeft ? StringAlignment.Far : StringAlignment.Near;
                    if (alignLeft)
                        printArea = new RectangleF(layoutArea.X, nextOffset, layoutArea.Width / 2, textSize.Height);
                    else
                        printArea = new RectangleF((layoutArea.Width / 2) + layoutArea.X, nextOffset, layoutArea.Width / 2, textSize.Height);
                }
                else
                {
                    printFormat.Alignment = alignLeft ? StringAlignment.Near : StringAlignment.Far;
                    printArea = new RectangleF(layoutArea.X, nextOffset, layoutArea.Width, textSize.Height);
                }

                g.DrawString(line, font, new SolidBrush(textColor), printArea, printFormat);
                nextOffset += textSize.Height;
                alignLeft = !alignLeft;
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
}
