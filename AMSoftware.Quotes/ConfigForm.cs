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

namespace AMSoftware.Quotes
{
    public partial class ConfigForm : Form
    {
        private Settings _configSettings;

        public ConfigForm()
        {
            InitializeComponent();

            _configSettings = Settings.Default;

            fontTextBox.Text = $"{_configSettings.QuotesFont.FontFamily.Name}; {_configSettings.QuotesFont.Style}; {_configSettings.QuotesColor.Name}";
            backgroundTextBox.Text = $"{_configSettings.QuotesBackgroundColor.Name}";
            pathTextBox.Text = _configSettings.QuotesPath;
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Color = _configSettings.QuotesColor;
            fontDialog.Font = _configSettings.QuotesFont;

            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.QuotesFont = fontDialog.Font;
                _configSettings.QuotesColor = fontDialog.Color;

                fontTextBox.Text = $"{_configSettings.QuotesFont.FontFamily.Name}; {_configSettings.QuotesFont.Style}; {_configSettings.QuotesColor.Name}";

                previewPanel.Refresh();

                applyButton.Enabled = true;
            }
        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _configSettings.QuotesBackgroundColor;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.QuotesBackgroundColor = colorDialog.Color;

                backgroundTextBox.Text = $"{_configSettings.QuotesBackgroundColor.Name}";

                previewPanel.Refresh();

                applyButton.Enabled = true;
            }
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            pathDialog.SelectedPath = _configSettings.QuotesPath;

            if (pathDialog.ShowDialog(this) == DialogResult.OK)
            {
                _configSettings.QuotesPath = pathDialog.SelectedPath;

                pathTextBox.Text = _configSettings.QuotesPath;

                applyButton.Enabled = true;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            _configSettings.Save();
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
            using (Graphics g = previewPanel.CreateGraphics())
            {
                Quote q = QuoteHelper.GetQuote();

                GraphicsHelper.DrawQuote(g, q, _configSettings);
            }
        }
    }
}
