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
using System.Windows.Forms;
using System.Collections;

namespace AMSoftware.Quotes
{
    public partial class ConfigForm : Form
    {
        private readonly Settings _configSettings;

        public ConfigForm()
        {
            InitializeComponent();
            this.Text = $"{Application.ProductName} [{Application.ProductVersion}]";

            _configSettings = Settings.Default;

            pathTextBox.Text = _configSettings.SourcePath;

            fontTextBox.Text = $"{_configSettings.TextFont.FontFamily.Name}; {_configSettings.TextFont.Style}; {_configSettings.TextColor.Name}";
            shrinkToFitCheckBox.Checked = _configSettings.TextShrinkToFit;

            alignmentComboBox.DataSource = new ArrayList()
            {
                Tuple.Create<TextAlignment,string>(TextAlignment.Auto, "Auto"),
                Tuple.Create<TextAlignment,string>(TextAlignment.Left, "Left"),
                Tuple.Create<TextAlignment, string>(TextAlignment.Center, "Center"),
                Tuple.Create<TextAlignment, string>(TextAlignment.Right, "Right")
            };
            alignmentComboBox.DisplayMember = "Item2";
            alignmentComboBox.ValueMember = "Item1";
            alignmentComboBox.SelectedValue = (TextAlignment)_configSettings.TextAlignment;

            backgroundColorTextBox.Text = $"{_configSettings.BackgroundColor.Name}";
            backgroundImageTextBox.Text = _configSettings.BackgroundImagePath;

            backgroundAlignmentComboBox.DataSource = new ArrayList()
            {
                Tuple.Create<BackgroundAlignment,string>(BackgroundAlignment.Fit, "Fit"),
                Tuple.Create<BackgroundAlignment,string>(BackgroundAlignment.Stretch, "Stretch"),
                Tuple.Create<BackgroundAlignment,string>(BackgroundAlignment.Center, "Center"),
                Tuple.Create<BackgroundAlignment, string>(BackgroundAlignment.Tile, "Tile"),
            };
            backgroundAlignmentComboBox.DisplayMember = "Item2";
            backgroundAlignmentComboBox.ValueMember = "Item1";
            backgroundAlignmentComboBox.SelectedValue = (BackgroundAlignment)_configSettings.BackgroundAlignment;
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Color = _configSettings.TextColor;
            fontDialog.Font = _configSettings.TextFont;

            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.TextFont = fontDialog.Font;
                _configSettings.TextColor = fontDialog.Color;

                fontTextBox.Text = $"{_configSettings.TextFont.FontFamily.Name}; {_configSettings.TextFont.Style}; {_configSettings.TextColor.Name}";

                applyButton.Enabled = true;
            }
        }

        private void ShrinkToFitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _configSettings.TextShrinkToFit = shrinkToFitCheckBox.Checked;

            applyButton.Enabled = true;
        }

        private void AlignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (alignmentComboBox.SelectedValue != null)
            {
                if (alignmentComboBox.SelectedValue is TextAlignment)
                {
                    _configSettings.TextAlignment = (int)alignmentComboBox.SelectedValue;
                    applyButton.Enabled = true;
                }
            }
        }

        private void BackgroundAlignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (backgroundAlignmentComboBox.SelectedValue != null)
            {
                if (backgroundAlignmentComboBox.SelectedValue is BackgroundAlignment)
                {
                    _configSettings.BackgroundAlignment = (int)backgroundAlignmentComboBox.SelectedValue;
                    applyButton.Enabled = true;
                }
            }
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Quotes XML|*.xml|All files|*.*";
            openFileDialog.Title = "Select quoute source";

            openFileDialog.FileName = _configSettings.SourcePath;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.SourcePath = openFileDialog.FileName;
                pathTextBox.Text = _configSettings.SourcePath;

                applyButton.Enabled = true;
            }
        }

        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _configSettings.BackgroundColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.BackgroundColor = colorDialog.Color;
                backgroundColorTextBox.Text = $"{_configSettings.BackgroundColor.Name}";

                applyButton.Enabled = true;
            }
        }

        private void BackgroundImageButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Picture Files|*.bmp;*.dib;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.png|Bitmap files|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|GIF|*.gif|PNG|*.png|All files|*.*";
            openFileDialog.Title = "Select background image";

            openFileDialog.FileName = _configSettings.BackgroundImagePath;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.BackgroundImagePath = openFileDialog.FileName;
                backgroundImageTextBox.Text = _configSettings.BackgroundImagePath;

                applyButton.Enabled = true;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            _configSettings.Save();

            applyButton.Enabled = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _configSettings.Save();

            this.Close();
        }

        private void PreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            Quote q = null;
            if (string.IsNullOrWhiteSpace(_configSettings.SourcePath))
            {
                q = QuoteReader.Default;
            }
            else
            {
                QuoteReader reader = QuoteReader.Create(_configSettings.SourcePath);
                q = reader?.Read() ?? QuoteReader.Default;
            }

            if (!string.IsNullOrWhiteSpace(previewQuoteTextBox.Text))
            {
                q = new Quote()
                {
                    QuoteText = previewQuoteTextBox.Lines,
                    Author = previewAuthorTextBox.Text,
                    Year = previewYearTextBox.Text
                };
            }

            using (Graphics g = previewPanel.CreateGraphics())
            {
                QuoteRenderer renderer = new QuoteRenderer(new RenderSettings()
                {
                    TextFont = _configSettings.TextFont,
                    TextColor = _configSettings.TextColor,
                    TextAlignment = (TextAlignment)_configSettings.TextAlignment,
                    TextShrinkToFit = true,
                    BackgroundColor = _configSettings.BackgroundColor,
                    BackgroundImagePath = _configSettings.BackgroundImagePath,
                    BackgroundAlignment = (BackgroundAlignment)_configSettings.BackgroundAlignment,
                });
                renderer.Render(q, g, Screen.FromControl(this).Bounds);
            }
        }

        private void ConfigurationTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configurationTabControl.SelectedTab.Name == "previewTabPage")
            {
                previewPanel.Refresh();
            }
        }

        private void PreviewTextBox_Leave(object sender, EventArgs e)
        {
            previewPanel.Refresh();
        }
    }
}
