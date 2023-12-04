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
using System.Collections;
using System.IO;

namespace AMSoftware.QuotesScreensaver
{
    public partial class ConfigForm : Form
    {
        private readonly Settings _configSettings;

        public ConfigForm()
        {
            InitializeComponent();
            this.Text = $"{Application.ProductName} [{Application.ProductVersion}]";

            _configSettings = Settings.Default;

            // Source
            pathTextBox.Text = _configSettings.SourcePath;
            if (!string.IsNullOrWhiteSpace(_configSettings.SourcePath))
            {
                try
                {
                    QuoteManager manager = QuoteManager.Create(_configSettings.SourcePath);
                    editButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Font
            fontTextBox.Text = $"{_configSettings.TextFont.FontFamily.Name}; {_configSettings.TextFont.Style}";
            textColorTextBox.Text = $"#{_configSettings.TextColor.R:X2}{_configSettings.TextColor.G:X2}{_configSettings.TextColor.B:X2}";

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

            // Background
            backgroundColorTextBox.Text = $"#{_configSettings.BackgroundColor.R:X2}{_configSettings.BackgroundColor.G:X2}{_configSettings.BackgroundColor.B:X2}";
            backgroundImageTextBox.Text = _configSettings.BackgroundImagePath;

            backgroundAlignmentComboBox.DataSource = new ArrayList()
            {
                Tuple.Create<BackgroundAlignment,string>(BackgroundAlignment.Fill, "Fill"),
                Tuple.Create<BackgroundAlignment,string>(BackgroundAlignment.Fit, "Fit"),
                Tuple.Create<BackgroundAlignment,string>(BackgroundAlignment.Stretch, "Stretch"),
                Tuple.Create<BackgroundAlignment, string>(BackgroundAlignment.Tile, "Tile"),
                Tuple.Create<BackgroundAlignment,string>(BackgroundAlignment.Center, "Center")
            };
            backgroundAlignmentComboBox.DisplayMember = "Item2";
            backgroundAlignmentComboBox.ValueMember = "Item1";
            backgroundAlignmentComboBox.SelectedValue = (BackgroundAlignment)_configSettings.BackgroundAlignment;

            backgroundOpacityNumericUpDown.Value = _configSettings.BackgroundOpacity;
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            editButton.Enabled = false;

            openFileDialog.Filter = "Quotes XML|*.xml|Quotes JSON|*.json|All files|*.*";
            openFileDialog.Title = "Select quoute source";

            if (!string.IsNullOrWhiteSpace(_configSettings.SourcePath))
            {
                openFileDialog.FileName = Path.GetFileName(_configSettings.SourcePath);
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_configSettings.SourcePath);
                openFileDialog.DefaultExt = Path.GetExtension(_configSettings.SourcePath);
                if (string.Equals(Path.GetExtension(_configSettings.SourcePath), ".xml", StringComparison.OrdinalIgnoreCase))
                {
                    openFileDialog.FilterIndex = 1;
                }
                else
                {
                    openFileDialog.FilterIndex = 2;
                }
            }
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    try
                    {
                        QuoteManager manager = QuoteManager.Create(openFileDialog.FileName);

                        _configSettings.SourcePath = openFileDialog.FileName;
                        pathTextBox.Text = _configSettings.SourcePath;

                        applyButton.Enabled = true;
                        editButton.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #region Font
        private void FontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Font = _configSettings.TextFont;
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.TextFont = fontDialog.Font;

                fontTextBox.Text = $"{_configSettings.TextFont.FontFamily.Name}; {_configSettings.TextFont.Style}";

                applyButton.Enabled = true;
            }
        }

        private void TextColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _configSettings.TextColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.TextColor = colorDialog.Color;
                textColorTextBox.Text = $"#{_configSettings.TextColor.R:X2}{_configSettings.TextColor.G:X2}{_configSettings.TextColor.B:X2}";

                applyButton.Enabled = true;
            }
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
        #endregion

        #region Background
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

        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _configSettings.BackgroundColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.BackgroundColor = colorDialog.Color;
                backgroundColorTextBox.Text = $"#{_configSettings.BackgroundColor.R:X2}{_configSettings.BackgroundColor.G:X2}{_configSettings.BackgroundColor.B:X2}";

                applyButton.Enabled = true;
            }
        }

        private void BackgroundImageButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Picture Files|*.bmp;*.dib;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.png|Bitmap files|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|GIF|*.gif|PNG|*.png|All files|*.*";
            openFileDialog.Title = "Select background image";

            if (!string.IsNullOrWhiteSpace(_configSettings.BackgroundImagePath))
            {
                openFileDialog.FileName = Path.GetFileName(_configSettings.BackgroundImagePath);
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_configSettings.BackgroundImagePath);
                openFileDialog.DefaultExt = Path.GetExtension(_configSettings.BackgroundImagePath);
                openFileDialog.FilterIndex = 1;
            }
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.BackgroundImagePath = openFileDialog.FileName;
                backgroundImageTextBox.Text = _configSettings.BackgroundImagePath;

                applyButton.Enabled = true;
            }
        }

        private void BackgroundOpacityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _configSettings.BackgroundOpacity = backgroundOpacityNumericUpDown.Value;

            applyButton.Enabled = true;
        }
        #endregion

        #region Form
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm()
            {
                Manager = QuoteManager.Create(_configSettings.SourcePath)
            };

            form.ShowDialog(this);
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Paint += new PaintEventHandler(this.PictureBox_Paint);

            Form previewForm = new Form();
            previewForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            previewForm.StartPosition = FormStartPosition.CenterScreen;
            previewForm.WindowState = FormWindowState.Maximized;
            previewForm.ShowInTaskbar = false;
            //previewForm.TopMost = true,
            previewForm.Text = $"{this.Text} Preview";
            previewForm.Controls.Add(pictureBox1);
            previewForm.Paint += new PaintEventHandler(this.PreviewForm_Paint);

            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();

            previewForm.ShowDialog(this);
        }

        private void PreviewForm_Paint(object sender, PaintEventArgs e)
        {
            QuoteRenderer renderer = new QuoteRenderer(new RenderSettings()
            {
                TextFont = _configSettings.TextFont,
                TextColor = _configSettings.TextColor,
                TextAlignment = (TextAlignment)_configSettings.TextAlignment,
                BackgroundColor = _configSettings.BackgroundColor,
                BackgroundImagePath = _configSettings.BackgroundImagePath,
                BackgroundAlignment = (BackgroundAlignment)_configSettings.BackgroundAlignment,
                BackgroundOpacity = _configSettings.BackgroundOpacity
            });
            renderer.RenderBackground(e.Graphics, (sender as Form).ClientRectangle);
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Quote q;
            if (string.IsNullOrWhiteSpace(_configSettings.SourcePath))
            {
                q = QuoteManager.Default;
            }
            else
            {
                QuoteManager manager = QuoteManager.Create(_configSettings.SourcePath);
                q = manager?.ReadRandom() ?? QuoteManager.Default;
            }

            QuoteRenderer renderer = new QuoteRenderer(new RenderSettings()
            {
                TextFont = _configSettings.TextFont,
                TextColor = _configSettings.TextColor,
                TextAlignment = (TextAlignment)_configSettings.TextAlignment,
                BackgroundColor = _configSettings.BackgroundColor,
                BackgroundImagePath = _configSettings.BackgroundImagePath,
                BackgroundAlignment = (BackgroundAlignment)_configSettings.BackgroundAlignment,
                BackgroundOpacity = _configSettings.BackgroundOpacity
            });
            renderer.RenderText(q, e.Graphics, (sender as PictureBox).ClientRectangle);
        }
        #endregion
    }
}
