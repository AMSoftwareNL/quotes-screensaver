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
using System.Drawing;
using System.Linq;

namespace AMSoftware.QuotesScreensaver
{
    internal class QuoteRenderer
    {
        private readonly RenderSettings _settings;

        public QuoteRenderer(RenderSettings settings)
        {
            _settings = settings;
        }

        public void RenderText(Quote q, Graphics g, RectangleF bounds)
        {
            if (q == null) return;

            // Set a margin of 5%
            float marginLeft = bounds.Width * 0.05F;
            float marginTop = bounds.Height * 0.05F;
            RectangleF layoutArea = new RectangleF(
                marginLeft,
                marginTop,
                bounds.Width - (2.0F * marginLeft),
                bounds.Height - (2.0F * marginTop)
            );

            // Print author and year of quote.
            DrawAuthorText(BuildAuthorText(q), g, _settings.TextFont, _settings.TextColor, layoutArea);

            // Size font to fit the screen. Selected size for font is ignored
            // Use quote as one string, as alignment doesn't matter.
            Font textFont = GetFittedFont(string.Join("\n", q.QuoteText), g, _settings.TextFont, layoutArea);
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

        public void RenderBackground(Graphics g, RectangleF bounds)
        {
            g.Clear(_settings.BackgroundColor);

            if (!string.IsNullOrWhiteSpace(_settings.BackgroundImagePath))
            {
                try
                {
                    Image backgroundImage = Image.FromFile(_settings.BackgroundImagePath);
                    NormalizeOrientation(ref backgroundImage);

                    switch (_settings.BackgroundAlignment)
                    {
                        case BackgroundAlignment.Fill:
                            DrawBackgroundFilled(g, backgroundImage, bounds);
                            break;
                        case BackgroundAlignment.Fit:
                            DrawBackgroundFitted(g, backgroundImage, bounds);
                            break;
                        case BackgroundAlignment.Stretch:
                            DrawBackgroundStretched(g, backgroundImage, bounds);
                            break;
                        case BackgroundAlignment.Center:
                            DrawBackgroundCentered(g, backgroundImage, bounds);
                            break;
                        case BackgroundAlignment.Tile:
                            DrawBackgroundTiled(g, backgroundImage, bounds);
                            break;
                        default:
                            break;
                    }
                }
                catch { }
            }

            if (_settings.BackgroundOpacity != 1.00M)
            {
                // Alpha ranges from 0 to 255
                int backgroundAlpha = (int)Math.Round(255M - (255M * _settings.BackgroundOpacity));
                Color opacityColor = Color.FromArgb(backgroundAlpha, _settings.BackgroundColor);
                SolidBrush opacityBrush = new SolidBrush(opacityColor);

                g.FillRectangle(opacityBrush, bounds);
            }
        }

        /// <summary>
        /// Image is scaled to fill the screen. What doesn't fit is cropped. Image is centered
        /// </summary>
        /// <param name="g"></param>
        /// <param name="backgroundImage"></param>
        /// <param name="displayBounds"></param>
        private static void DrawBackgroundFilled(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            float widthRatio = displayBounds.Width / backgroundImage.Width;
            float heightRatio = displayBounds.Height / backgroundImage.Height;
            float appliedRatio = Math.Max(widthRatio, heightRatio);

            float width = backgroundImage.Width * appliedRatio;
            float height = backgroundImage.Height * appliedRatio;

            RectangleF destRectangle = new RectangleF(
                (displayBounds.Width - width) / 2,
                (displayBounds.Height - height) / 2,
                width, height);

            g.DrawImage(backgroundImage, destRectangle);
        }

        /// <summary>
        /// Image is centered on the screen. Image is scaled to be shown complete. Nothing is cropped.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="backgroundImage"></param>
        /// <param name="displayBounds"></param>
        private static void DrawBackgroundFitted(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            float widthRatio = displayBounds.Width / backgroundImage.Width;
            float heightRatio = displayBounds.Height / backgroundImage.Height;
            float appliedRatio = Math.Min(widthRatio, heightRatio);

            float width = backgroundImage.Width * appliedRatio;
            float height = backgroundImage.Height * appliedRatio;

            RectangleF destRectangle = new RectangleF(
                (displayBounds.Width - width) / 2,
                (displayBounds.Height - height) / 2,
                width, height);

            g.DrawImage(backgroundImage, destRectangle);
        }

        /// <summary>
        /// Image is scaled both horizontal and vertical without keeping aspect ratio to fill the entire screen.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="backgroundImage"></param>
        /// <param name="displayBounds"></param>
        private static void DrawBackgroundStretched(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            g.DrawImage(backgroundImage, displayBounds);
        }

        /// <summary>
        /// Image is NOT scaled. Draw image from left upper corner, and repeat until screen (vertical and horizontal) is filled.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="backgroundImage"></param>
        /// <param name="displayBounds"></param>
        private static void DrawBackgroundTiled(Graphics g, Image backgroundImage, RectangleF displayBounds)
        {
            Rectangle srcRectangle = new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height);

            int tileCountWidth = (int)Math.Ceiling(displayBounds.Width / srcRectangle.Width);
            int tileCountHeight = (int)Math.Ceiling(displayBounds.Height / srcRectangle.Height);

            for (int y = 0; y < tileCountHeight; y++)
            {
                for (int x = 0; x < tileCountWidth; x++)
                {
                    Rectangle destRectangle = new Rectangle(x * srcRectangle.Width, y * srcRectangle.Height, srcRectangle.Width, srcRectangle.Height);
                    g.DrawImageUnscaledAndClipped(backgroundImage, destRectangle);
                }
            }
        }

        /// <summary>
        /// Image is NOT scaled. True size is used. Center of image is on center of screen.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="backgroundImage"></param>
        /// <param name="displayBounds"></param>
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

        private static void NormalizeOrientation(ref Image image)
        {
            const int ExifOrientationTagId = 0x0112;

            if (Array.IndexOf(image.PropertyIdList, ExifOrientationTagId) > -1)
            {
                int orientation = image.GetPropertyItem(ExifOrientationTagId).Value[0];

                switch (orientation)
                {
                    case 2:
                        image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3:
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4:
                        image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        break;
                    case 5:
                        image.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6:
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7:
                        image.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8:
                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }

                image.RemovePropertyItem(ExifOrientationTagId);
            }
        }

        private static Font GetFittedFont(string text, Graphics g, Font textFont, RectangleF area)
        {
            SizeF textSize = g.MeasureString(text, textFont);
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

        private static void DrawAuthorText(string text, Graphics g, Font textFont, Color textColor, RectangleF layoutArea)
        {
            // Textsize is 2.5% of bound height. Independent of selected fontsize.
            Font authorFont = new Font(textFont.FontFamily, layoutArea.Height * 0.025F, FontStyle.Italic);
            g.DrawString(text, authorFont, new SolidBrush(textColor), layoutArea, new StringFormat()
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
            if (!string.IsNullOrWhiteSpace(quote.Source))
            {
                if (string.IsNullOrWhiteSpace(authorText))
                {
                    authorText = $"{quote.Source}";
                }
                else
                {
                    authorText += $" ({quote.Source})";
                }
            }
            if (!string.IsNullOrWhiteSpace(quote.Year))
            {
                if (string.IsNullOrWhiteSpace(authorText))
                {
                    authorText = quote.Year;
                }
                else
                {
                    authorText += $" - {quote.Year}";
                }
            }

            return authorText;
        }
    }
}
