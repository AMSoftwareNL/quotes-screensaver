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
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.backgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.backgroundAlignmentComboBox = new System.Windows.Forms.ComboBox();
            this.backgroundAlignmentLabel = new System.Windows.Forms.Label();
            this.backgroundImageLabel = new System.Windows.Forms.Label();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.backgroundImageButton = new System.Windows.Forms.Button();
            this.backgroundImageTextBox = new System.Windows.Forms.TextBox();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.backgroundColorTextBox = new System.Windows.Forms.TextBox();
            this.textGroupBox = new System.Windows.Forms.GroupBox();
            this.shrinkToFitCheckBox = new System.Windows.Forms.CheckBox();
            this.alignmentComboBox = new System.Windows.Forms.ComboBox();
            this.alignmentLabel = new System.Windows.Forms.Label();
            this.fontTextBox = new System.Windows.Forms.TextBox();
            this.fontLabel = new System.Windows.Forms.Label();
            this.fontButton = new System.Windows.Forms.Button();
            this.sourceLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pathButton = new System.Windows.Forms.Button();
            this.configurationTabControl = new System.Windows.Forms.TabControl();
            this.previewTabPage = new System.Windows.Forms.TabPage();
            this.previewYearTextBox = new System.Windows.Forms.TextBox();
            this.previewAuthorTextBox = new System.Windows.Forms.TextBox();
            this.previewQuoteTextBox = new System.Windows.Forms.TextBox();
            this.previewAuthorLabel = new System.Windows.Forms.Label();
            this.previewYearLabel = new System.Windows.Forms.Label();
            this.previewQuoteLabel = new System.Windows.Forms.Label();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.applyButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.generalTabPage.SuspendLayout();
            this.backgroundGroupBox.SuspendLayout();
            this.textGroupBox.SuspendLayout();
            this.sourceLocationGroupBox.SuspendLayout();
            this.configurationTabControl.SuspendLayout();
            this.previewTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(199, 448);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(118, 448);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.backgroundGroupBox);
            this.generalTabPage.Controls.Add(this.textGroupBox);
            this.generalTabPage.Controls.Add(this.sourceLocationGroupBox);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.generalTabPage.Size = new System.Drawing.Size(341, 408);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // backgroundGroupBox
            // 
            this.backgroundGroupBox.Controls.Add(this.backgroundAlignmentComboBox);
            this.backgroundGroupBox.Controls.Add(this.backgroundAlignmentLabel);
            this.backgroundGroupBox.Controls.Add(this.backgroundImageLabel);
            this.backgroundGroupBox.Controls.Add(this.backgroundColorLabel);
            this.backgroundGroupBox.Controls.Add(this.backgroundImageButton);
            this.backgroundGroupBox.Controls.Add(this.backgroundImageTextBox);
            this.backgroundGroupBox.Controls.Add(this.backgroundColorButton);
            this.backgroundGroupBox.Controls.Add(this.backgroundColorTextBox);
            this.backgroundGroupBox.Location = new System.Drawing.Point(10, 196);
            this.backgroundGroupBox.Name = "backgroundGroupBox";
            this.backgroundGroupBox.Size = new System.Drawing.Size(320, 105);
            this.backgroundGroupBox.TabIndex = 12;
            this.backgroundGroupBox.TabStop = false;
            this.backgroundGroupBox.Text = "Background";
            // 
            // backgroundAlignmentComboBox
            // 
            this.backgroundAlignmentComboBox.FormattingEnabled = true;
            this.backgroundAlignmentComboBox.Items.AddRange(new object[] {
            "Auto",
            "Left",
            "Center",
            "Right"});
            this.backgroundAlignmentComboBox.Location = new System.Drawing.Point(77, 73);
            this.backgroundAlignmentComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.backgroundAlignmentComboBox.Name = "backgroundAlignmentComboBox";
            this.backgroundAlignmentComboBox.Size = new System.Drawing.Size(238, 21);
            this.backgroundAlignmentComboBox.TabIndex = 24;
            this.backgroundAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundAlignmentComboBox_SelectedIndexChanged);
            // 
            // backgroundAlignmentLabel
            // 
            this.backgroundAlignmentLabel.AutoSize = true;
            this.backgroundAlignmentLabel.Location = new System.Drawing.Point(6, 76);
            this.backgroundAlignmentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.backgroundAlignmentLabel.Name = "backgroundAlignmentLabel";
            this.backgroundAlignmentLabel.Size = new System.Drawing.Size(53, 13);
            this.backgroundAlignmentLabel.TabIndex = 23;
            this.backgroundAlignmentLabel.Text = "Alignment";
            // 
            // backgroundImageLabel
            // 
            this.backgroundImageLabel.AutoSize = true;
            this.backgroundImageLabel.Location = new System.Drawing.Point(6, 50);
            this.backgroundImageLabel.Name = "backgroundImageLabel";
            this.backgroundImageLabel.Size = new System.Drawing.Size(36, 13);
            this.backgroundImageLabel.TabIndex = 22;
            this.backgroundImageLabel.Text = "Image";
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Location = new System.Drawing.Point(6, 22);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(31, 13);
            this.backgroundColorLabel.TabIndex = 21;
            this.backgroundColorLabel.Text = "Color";
            // 
            // backgroundImageButton
            // 
            this.backgroundImageButton.Location = new System.Drawing.Point(293, 45);
            this.backgroundImageButton.Name = "backgroundImageButton";
            this.backgroundImageButton.Size = new System.Drawing.Size(23, 23);
            this.backgroundImageButton.TabIndex = 14;
            this.backgroundImageButton.Text = "...";
            this.backgroundImageButton.UseVisualStyleBackColor = true;
            this.backgroundImageButton.Click += new System.EventHandler(this.BackgroundImageButton_Click);
            // 
            // backgroundImageTextBox
            // 
            this.backgroundImageTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backgroundImageTextBox.Location = new System.Drawing.Point(77, 47);
            this.backgroundImageTextBox.Name = "backgroundImageTextBox";
            this.backgroundImageTextBox.ReadOnly = true;
            this.backgroundImageTextBox.Size = new System.Drawing.Size(210, 20);
            this.backgroundImageTextBox.TabIndex = 13;
            this.backgroundImageTextBox.TabStop = false;
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Location = new System.Drawing.Point(293, 17);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(23, 23);
            this.backgroundColorButton.TabIndex = 12;
            this.backgroundColorButton.Text = "...";
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.BackgroundColorButton_Click);
            // 
            // backgroundColorTextBox
            // 
            this.backgroundColorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backgroundColorTextBox.Location = new System.Drawing.Point(77, 19);
            this.backgroundColorTextBox.Name = "backgroundColorTextBox";
            this.backgroundColorTextBox.ReadOnly = true;
            this.backgroundColorTextBox.Size = new System.Drawing.Size(210, 20);
            this.backgroundColorTextBox.TabIndex = 11;
            this.backgroundColorTextBox.TabStop = false;
            // 
            // textGroupBox
            // 
            this.textGroupBox.Controls.Add(this.shrinkToFitCheckBox);
            this.textGroupBox.Controls.Add(this.alignmentComboBox);
            this.textGroupBox.Controls.Add(this.alignmentLabel);
            this.textGroupBox.Controls.Add(this.fontTextBox);
            this.textGroupBox.Controls.Add(this.fontLabel);
            this.textGroupBox.Controls.Add(this.fontButton);
            this.textGroupBox.Location = new System.Drawing.Point(10, 77);
            this.textGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.textGroupBox.Name = "textGroupBox";
            this.textGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.textGroupBox.Size = new System.Drawing.Size(321, 105);
            this.textGroupBox.TabIndex = 11;
            this.textGroupBox.TabStop = false;
            this.textGroupBox.Text = "Text";
            // 
            // shrinkToFitCheckBox
            // 
            this.shrinkToFitCheckBox.AutoSize = true;
            this.shrinkToFitCheckBox.Location = new System.Drawing.Point(77, 45);
            this.shrinkToFitCheckBox.Name = "shrinkToFitCheckBox";
            this.shrinkToFitCheckBox.Size = new System.Drawing.Size(114, 17);
            this.shrinkToFitCheckBox.TabIndex = 9;
            this.shrinkToFitCheckBox.Text = "Shrink to fit screen";
            this.shrinkToFitCheckBox.UseVisualStyleBackColor = true;
            this.shrinkToFitCheckBox.CheckedChanged += new System.EventHandler(this.ShrinkToFitCheckBox_CheckedChanged);
            // 
            // alignmentComboBox
            // 
            this.alignmentComboBox.FormattingEnabled = true;
            this.alignmentComboBox.Items.AddRange(new object[] {
            "Auto",
            "Left",
            "Center",
            "Right"});
            this.alignmentComboBox.Location = new System.Drawing.Point(77, 69);
            this.alignmentComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.alignmentComboBox.Name = "alignmentComboBox";
            this.alignmentComboBox.Size = new System.Drawing.Size(238, 21);
            this.alignmentComboBox.TabIndex = 10;
            this.alignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.AlignmentComboBox_SelectedIndexChanged);
            // 
            // alignmentLabel
            // 
            this.alignmentLabel.AutoSize = true;
            this.alignmentLabel.Location = new System.Drawing.Point(6, 72);
            this.alignmentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.alignmentLabel.Name = "alignmentLabel";
            this.alignmentLabel.Size = new System.Drawing.Size(53, 13);
            this.alignmentLabel.TabIndex = 8;
            this.alignmentLabel.Text = "Alignment";
            // 
            // fontTextBox
            // 
            this.fontTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fontTextBox.Location = new System.Drawing.Point(77, 19);
            this.fontTextBox.Name = "fontTextBox";
            this.fontTextBox.ReadOnly = true;
            this.fontTextBox.Size = new System.Drawing.Size(210, 20);
            this.fontTextBox.TabIndex = 7;
            this.fontTextBox.TabStop = false;
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(6, 22);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(28, 13);
            this.fontLabel.TabIndex = 3;
            this.fontLabel.Text = "Font";
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(293, 17);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(23, 23);
            this.fontButton.TabIndex = 8;
            this.fontButton.Text = "...";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // sourceLocationGroupBox
            // 
            this.sourceLocationGroupBox.Controls.Add(this.pathTextBox);
            this.sourceLocationGroupBox.Controls.Add(this.pathLabel);
            this.sourceLocationGroupBox.Controls.Add(this.pathButton);
            this.sourceLocationGroupBox.Location = new System.Drawing.Point(10, 10);
            this.sourceLocationGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.sourceLocationGroupBox.Name = "sourceLocationGroupBox";
            this.sourceLocationGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.sourceLocationGroupBox.Size = new System.Drawing.Size(321, 53);
            this.sourceLocationGroupBox.TabIndex = 8;
            this.sourceLocationGroupBox.TabStop = false;
            this.sourceLocationGroupBox.Text = "Source";
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pathTextBox.Location = new System.Drawing.Point(77, 19);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(210, 20);
            this.pathTextBox.TabIndex = 5;
            this.pathTextBox.TabStop = false;
            this.pathTextBox.Text = global::AMSoftware.Quotes.Properties.Settings.Default.SourcePath;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(6, 22);
            this.pathLabel.Margin = new System.Windows.Forms.Padding(3);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(29, 13);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Path";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(293, 17);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(23, 23);
            this.pathButton.TabIndex = 6;
            this.pathButton.Text = "...";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // configurationTabControl
            // 
            this.configurationTabControl.Controls.Add(this.generalTabPage);
            this.configurationTabControl.Controls.Add(this.previewTabPage);
            this.configurationTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.configurationTabControl.Location = new System.Drawing.Point(6, 6);
            this.configurationTabControl.Name = "configurationTabControl";
            this.configurationTabControl.Padding = new System.Drawing.Point(0, 0);
            this.configurationTabControl.SelectedIndex = 0;
            this.configurationTabControl.Size = new System.Drawing.Size(349, 434);
            this.configurationTabControl.TabIndex = 1;
            this.configurationTabControl.SelectedIndexChanged += new System.EventHandler(this.ConfigurationTabControl_SelectedIndexChanged);
            // 
            // previewTabPage
            // 
            this.previewTabPage.Controls.Add(this.previewYearTextBox);
            this.previewTabPage.Controls.Add(this.previewAuthorTextBox);
            this.previewTabPage.Controls.Add(this.previewQuoteTextBox);
            this.previewTabPage.Controls.Add(this.previewAuthorLabel);
            this.previewTabPage.Controls.Add(this.previewYearLabel);
            this.previewTabPage.Controls.Add(this.previewQuoteLabel);
            this.previewTabPage.Controls.Add(this.previewPanel);
            this.previewTabPage.Location = new System.Drawing.Point(4, 22);
            this.previewTabPage.Margin = new System.Windows.Forms.Padding(2);
            this.previewTabPage.Name = "previewTabPage";
            this.previewTabPage.Padding = new System.Windows.Forms.Padding(2);
            this.previewTabPage.Size = new System.Drawing.Size(341, 408);
            this.previewTabPage.TabIndex = 1;
            this.previewTabPage.Text = "Preview";
            this.previewTabPage.UseVisualStyleBackColor = true;
            // 
            // previewYearTextBox
            // 
            this.previewYearTextBox.Location = new System.Drawing.Point(77, 335);
            this.previewYearTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.previewYearTextBox.Name = "previewYearTextBox";
            this.previewYearTextBox.Size = new System.Drawing.Size(252, 20);
            this.previewYearTextBox.TabIndex = 16;
            this.previewYearTextBox.Leave += new System.EventHandler(this.PreviewTextBox_Leave);
            // 
            // previewAuthorTextBox
            // 
            this.previewAuthorTextBox.Location = new System.Drawing.Point(77, 311);
            this.previewAuthorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.previewAuthorTextBox.Name = "previewAuthorTextBox";
            this.previewAuthorTextBox.Size = new System.Drawing.Size(252, 20);
            this.previewAuthorTextBox.TabIndex = 15;
            this.previewAuthorTextBox.Leave += new System.EventHandler(this.PreviewTextBox_Leave);
            // 
            // previewQuoteTextBox
            // 
            this.previewQuoteTextBox.Location = new System.Drawing.Point(77, 246);
            this.previewQuoteTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.previewQuoteTextBox.Multiline = true;
            this.previewQuoteTextBox.Name = "previewQuoteTextBox";
            this.previewQuoteTextBox.Size = new System.Drawing.Size(252, 61);
            this.previewQuoteTextBox.TabIndex = 14;
            this.previewQuoteTextBox.Leave += new System.EventHandler(this.PreviewTextBox_Leave);
            // 
            // previewAuthorLabel
            // 
            this.previewAuthorLabel.AutoSize = true;
            this.previewAuthorLabel.Location = new System.Drawing.Point(9, 314);
            this.previewAuthorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.previewAuthorLabel.Name = "previewAuthorLabel";
            this.previewAuthorLabel.Size = new System.Drawing.Size(38, 13);
            this.previewAuthorLabel.TabIndex = 13;
            this.previewAuthorLabel.Text = "Author";
            // 
            // previewYearLabel
            // 
            this.previewYearLabel.AutoSize = true;
            this.previewYearLabel.Location = new System.Drawing.Point(9, 334);
            this.previewYearLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.previewYearLabel.Name = "previewYearLabel";
            this.previewYearLabel.Size = new System.Drawing.Size(29, 13);
            this.previewYearLabel.TabIndex = 12;
            this.previewYearLabel.Text = "Year";
            // 
            // previewQuoteLabel
            // 
            this.previewQuoteLabel.AutoSize = true;
            this.previewQuoteLabel.Location = new System.Drawing.Point(11, 246);
            this.previewQuoteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.previewQuoteLabel.Name = "previewQuoteLabel";
            this.previewQuoteLabel.Size = new System.Drawing.Size(36, 13);
            this.previewQuoteLabel.TabIndex = 11;
            this.previewQuoteLabel.Text = "Quote";
            // 
            // previewPanel
            // 
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Location = new System.Drawing.Point(11, 16);
            this.previewPanel.Margin = new System.Windows.Forms.Padding(16);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(318, 211);
            this.previewPanel.TabIndex = 10;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PreviewPanel_Paint);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(280, 448);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 17;
            this.applyButton.Text = "&Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // fontDialog
            // 
            this.fontDialog.AllowScriptChange = false;
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.Color = global::AMSoftware.Quotes.Properties.Settings.Default.TextColor;
            this.fontDialog.Font = global::AMSoftware.Quotes.Properties.Settings.Default.TextFont;
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ScriptsOnly = true;
            this.fontDialog.ShowColor = true;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(361, 477);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.configurationTabControl);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Quotes Screensaver";
            this.generalTabPage.ResumeLayout(false);
            this.backgroundGroupBox.ResumeLayout(false);
            this.backgroundGroupBox.PerformLayout();
            this.textGroupBox.ResumeLayout(false);
            this.textGroupBox.PerformLayout();
            this.sourceLocationGroupBox.ResumeLayout(false);
            this.sourceLocationGroupBox.PerformLayout();
            this.configurationTabControl.ResumeLayout(false);
            this.previewTabPage.ResumeLayout(false);
            this.previewTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabControl configurationTabControl;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TabPage previewTabPage;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.TextBox previewYearTextBox;
        private System.Windows.Forms.TextBox previewAuthorTextBox;
        private System.Windows.Forms.TextBox previewQuoteTextBox;
        private System.Windows.Forms.Label previewAuthorLabel;
        private System.Windows.Forms.Label previewYearLabel;
        private System.Windows.Forms.Label previewQuoteLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox sourceLocationGroupBox;
        private System.Windows.Forms.GroupBox backgroundGroupBox;
        private System.Windows.Forms.Label backgroundImageLabel;
        private System.Windows.Forms.Label backgroundColorLabel;
        private System.Windows.Forms.Button backgroundImageButton;
        private System.Windows.Forms.TextBox backgroundImageTextBox;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.TextBox backgroundColorTextBox;
        private System.Windows.Forms.GroupBox textGroupBox;
        private System.Windows.Forms.CheckBox shrinkToFitCheckBox;
        private System.Windows.Forms.ComboBox alignmentComboBox;
        private System.Windows.Forms.Label alignmentLabel;
        private System.Windows.Forms.TextBox fontTextBox;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.ComboBox backgroundAlignmentComboBox;
        private System.Windows.Forms.Label backgroundAlignmentLabel;
    }
}