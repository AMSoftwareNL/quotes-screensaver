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
namespace AMSoftware.Quotes
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.configurationTabPage = new System.Windows.Forms.TabPage();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.backgroundTextBox = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.fontButton = new System.Windows.Forms.Button();
            this.fontTextBox = new System.Windows.Forms.TextBox();
            this.fontLabel = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pathButton = new System.Windows.Forms.Button();
            this.configurationTabControl = new System.Windows.Forms.TabControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.pathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.applyButton = new System.Windows.Forms.Button();
            this.configurationTabPage.SuspendLayout();
            this.configurationTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(228, 392);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(147, 392);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // configurationTabPage
            // 
            this.configurationTabPage.Controls.Add(this.previewPanel);
            this.configurationTabPage.Controls.Add(this.backgroundButton);
            this.configurationTabPage.Controls.Add(this.backgroundTextBox);
            this.configurationTabPage.Controls.Add(this.colorLabel);
            this.configurationTabPage.Controls.Add(this.fontButton);
            this.configurationTabPage.Controls.Add(this.fontTextBox);
            this.configurationTabPage.Controls.Add(this.fontLabel);
            this.configurationTabPage.Controls.Add(this.pathTextBox);
            this.configurationTabPage.Controls.Add(this.pathLabel);
            this.configurationTabPage.Controls.Add(this.pathButton);
            this.configurationTabPage.Location = new System.Drawing.Point(4, 22);
            this.configurationTabPage.Name = "configurationTabPage";
            this.configurationTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.configurationTabPage.Size = new System.Drawing.Size(368, 354);
            this.configurationTabPage.TabIndex = 0;
            this.configurationTabPage.Text = "Configuration";
            this.configurationTabPage.UseVisualStyleBackColor = true;
            // 
            // previewPanel
            // 
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Location = new System.Drawing.Point(24, 101);
            this.previewPanel.Margin = new System.Windows.Forms.Padding(16);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(320, 229);
            this.previewPanel.TabIndex = 9;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PreviewPanel_Paint);
            // 
            // backgroundButton
            // 
            this.backgroundButton.Location = new System.Drawing.Point(336, 60);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(23, 23);
            this.backgroundButton.TabIndex = 4;
            this.backgroundButton.Text = "...";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.BackgroundButton_Click);
            // 
            // backgroundTextBox
            // 
            this.backgroundTextBox.Location = new System.Drawing.Point(136, 62);
            this.backgroundTextBox.Name = "backgroundTextBox";
            this.backgroundTextBox.ReadOnly = true;
            this.backgroundTextBox.Size = new System.Drawing.Size(194, 20);
            this.backgroundTextBox.TabIndex = 7;
            this.backgroundTextBox.TabStop = false;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(11, 65);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(68, 13);
            this.colorLabel.TabIndex = 6;
            this.colorLabel.Text = "Background:";
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(336, 34);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(23, 23);
            this.fontButton.TabIndex = 3;
            this.fontButton.Text = "...";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // fontTextBox
            // 
            this.fontTextBox.Location = new System.Drawing.Point(136, 36);
            this.fontTextBox.Name = "fontTextBox";
            this.fontTextBox.ReadOnly = true;
            this.fontTextBox.Size = new System.Drawing.Size(194, 20);
            this.fontTextBox.TabIndex = 4;
            this.fontTextBox.TabStop = false;
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(11, 39);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(31, 13);
            this.fontLabel.TabIndex = 3;
            this.fontLabel.Text = "Font:";
            // 
            // pathTextBox
            // 
            this.pathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AMSoftware.Quotes.Properties.Settings.Default, "quotesPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pathTextBox.Location = new System.Drawing.Point(136, 10);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(194, 20);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.TabStop = false;
            this.pathTextBox.Text = global::AMSoftware.Quotes.Properties.Settings.Default.QuotesPath;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(11, 13);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(32, 13);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Path:";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(336, 8);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(23, 23);
            this.pathButton.TabIndex = 2;
            this.pathButton.Text = "...";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // configurationTabControl
            // 
            this.configurationTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configurationTabControl.Controls.Add(this.configurationTabPage);
            this.configurationTabControl.Location = new System.Drawing.Point(8, 8);
            this.configurationTabControl.Name = "configurationTabControl";
            this.configurationTabControl.SelectedIndex = 0;
            this.configurationTabControl.Size = new System.Drawing.Size(376, 380);
            this.configurationTabControl.TabIndex = 1;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.Color = global::AMSoftware.Quotes.Properties.Settings.Default.QuotesBackgroundColor;
            this.colorDialog.SolidColorOnly = true;
            // 
            // fontDialog
            // 
            this.fontDialog.AllowScriptChange = false;
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.Color = global::AMSoftware.Quotes.Properties.Settings.Default.QuotesColor;
            this.fontDialog.Font = global::AMSoftware.Quotes.Properties.Settings.Default.QuotesFont;
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ScriptsOnly = true;
            this.fontDialog.ShowColor = true;
            // 
            // pathDialog
            // 
            this.pathDialog.SelectedPath = global::AMSoftware.Quotes.Properties.Settings.Default.QuotesPath;
            this.pathDialog.ShowNewFolderButton = false;
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(309, 392);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "&Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(390, 422);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.configurationTabControl);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowInTaskbar = false;
            this.Text = "Quotes Screensaver";
            this.TopMost = true;
            this.configurationTabPage.ResumeLayout(false);
            this.configurationTabPage.PerformLayout();
            this.configurationTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabPage configurationTabPage;
        private System.Windows.Forms.TabControl configurationTabControl;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.TextBox backgroundTextBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.TextBox fontTextBox;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.FolderBrowserDialog pathDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button applyButton;
    }
}