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
            this.previewButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.backgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.backgroundOpacityLabel = new System.Windows.Forms.Label();
            this.backgroundOpacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.backgroundAlignmentComboBox = new System.Windows.Forms.ComboBox();
            this.backgroundAlignmentLabel = new System.Windows.Forms.Label();
            this.backgroundImageLabel = new System.Windows.Forms.Label();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.backgroundImageButton = new System.Windows.Forms.Button();
            this.backgroundImageTextBox = new System.Windows.Forms.TextBox();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.backgroundColorTextBox = new System.Windows.Forms.TextBox();
            this.textGroupBox = new System.Windows.Forms.GroupBox();
            this.textColorLabel = new System.Windows.Forms.Label();
            this.textColorButton = new System.Windows.Forms.Button();
            this.textColorTextBox = new System.Windows.Forms.TextBox();
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
            this.applyButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.generalTabPage.SuspendLayout();
            this.backgroundGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundOpacityNumericUpDown)).BeginInit();
            this.textGroupBox.SuspendLayout();
            this.sourceLocationGroupBox.SuspendLayout();
            this.configurationTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(265, 551);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(157, 551);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.previewButton);
            this.generalTabPage.Controls.Add(this.editButton);
            this.generalTabPage.Controls.Add(this.backgroundGroupBox);
            this.generalTabPage.Controls.Add(this.textGroupBox);
            this.generalTabPage.Controls.Add(this.sourceLocationGroupBox);
            this.generalTabPage.Location = new System.Drawing.Point(4, 25);
            this.generalTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.generalTabPage.Size = new System.Drawing.Size(457, 505);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(235, 464);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(100, 28);
            this.previewButton.TabIndex = 14;
            this.previewButton.Text = "&Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(341, 464);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(100, 28);
            this.editButton.TabIndex = 13;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // backgroundGroupBox
            // 
            this.backgroundGroupBox.Controls.Add(this.backgroundOpacityLabel);
            this.backgroundGroupBox.Controls.Add(this.backgroundOpacityNumericUpDown);
            this.backgroundGroupBox.Controls.Add(this.backgroundAlignmentComboBox);
            this.backgroundGroupBox.Controls.Add(this.backgroundAlignmentLabel);
            this.backgroundGroupBox.Controls.Add(this.backgroundImageLabel);
            this.backgroundGroupBox.Controls.Add(this.backgroundColorLabel);
            this.backgroundGroupBox.Controls.Add(this.backgroundImageButton);
            this.backgroundGroupBox.Controls.Add(this.backgroundImageTextBox);
            this.backgroundGroupBox.Controls.Add(this.backgroundColorButton);
            this.backgroundGroupBox.Controls.Add(this.backgroundColorTextBox);
            this.backgroundGroupBox.Location = new System.Drawing.Point(13, 265);
            this.backgroundGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundGroupBox.Name = "backgroundGroupBox";
            this.backgroundGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.backgroundGroupBox.Size = new System.Drawing.Size(427, 165);
            this.backgroundGroupBox.TabIndex = 12;
            this.backgroundGroupBox.TabStop = false;
            this.backgroundGroupBox.Text = "Background";
            // 
            // backgroundOpacityLabel
            // 
            this.backgroundOpacityLabel.AutoSize = true;
            this.backgroundOpacityLabel.Location = new System.Drawing.Point(8, 130);
            this.backgroundOpacityLabel.Name = "backgroundOpacityLabel";
            this.backgroundOpacityLabel.Size = new System.Drawing.Size(47, 15);
            this.backgroundOpacityLabel.TabIndex = 24;
            this.backgroundOpacityLabel.Text = "Opacity";
            // 
            // backgroundOpacityNumericUpDown
            // 
            this.backgroundOpacityNumericUpDown.DecimalPlaces = 2;
            this.backgroundOpacityNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.backgroundOpacityNumericUpDown.Location = new System.Drawing.Point(103, 128);
            this.backgroundOpacityNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.backgroundOpacityNumericUpDown.Name = "backgroundOpacityNumericUpDown";
            this.backgroundOpacityNumericUpDown.Size = new System.Drawing.Size(316, 20);
            this.backgroundOpacityNumericUpDown.TabIndex = 15;
            this.backgroundOpacityNumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.backgroundOpacityNumericUpDown.ValueChanged += new System.EventHandler(this.BackgroundOpacityNumericUpDown_ValueChanged);
            // 
            // backgroundAlignmentComboBox
            // 
            this.backgroundAlignmentComboBox.FormattingEnabled = true;
            this.backgroundAlignmentComboBox.Items.AddRange(new object[] {
            "Auto",
            "Left",
            "Center",
            "Right"});
            this.backgroundAlignmentComboBox.Location = new System.Drawing.Point(103, 90);
            this.backgroundAlignmentComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backgroundAlignmentComboBox.Name = "backgroundAlignmentComboBox";
            this.backgroundAlignmentComboBox.Size = new System.Drawing.Size(316, 24);
            this.backgroundAlignmentComboBox.TabIndex = 14;
            this.backgroundAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundAlignmentComboBox_SelectedIndexChanged);
            // 
            // backgroundAlignmentLabel
            // 
            this.backgroundAlignmentLabel.AutoSize = true;
            this.backgroundAlignmentLabel.Location = new System.Drawing.Point(8, 94);
            this.backgroundAlignmentLabel.Name = "backgroundAlignmentLabel";
            this.backgroundAlignmentLabel.Size = new System.Drawing.Size(62, 15);
            this.backgroundAlignmentLabel.TabIndex = 23;
            this.backgroundAlignmentLabel.Text = "Alignment";
            // 
            // backgroundImageLabel
            // 
            this.backgroundImageLabel.AutoSize = true;
            this.backgroundImageLabel.Location = new System.Drawing.Point(8, 62);
            this.backgroundImageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.backgroundImageLabel.Name = "backgroundImageLabel";
            this.backgroundImageLabel.Size = new System.Drawing.Size(42, 15);
            this.backgroundImageLabel.TabIndex = 22;
            this.backgroundImageLabel.Text = "Image";
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Location = new System.Drawing.Point(8, 27);
            this.backgroundColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(36, 15);
            this.backgroundColorLabel.TabIndex = 21;
            this.backgroundColorLabel.Text = "Color";
            // 
            // backgroundImageButton
            // 
            this.backgroundImageButton.Location = new System.Drawing.Point(391, 55);
            this.backgroundImageButton.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundImageButton.Name = "backgroundImageButton";
            this.backgroundImageButton.Size = new System.Drawing.Size(31, 28);
            this.backgroundImageButton.TabIndex = 13;
            this.backgroundImageButton.Text = "...";
            this.backgroundImageButton.UseVisualStyleBackColor = true;
            this.backgroundImageButton.Click += new System.EventHandler(this.BackgroundImageButton_Click);
            // 
            // backgroundImageTextBox
            // 
            this.backgroundImageTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backgroundImageTextBox.Location = new System.Drawing.Point(103, 58);
            this.backgroundImageTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundImageTextBox.Name = "backgroundImageTextBox";
            this.backgroundImageTextBox.ReadOnly = true;
            this.backgroundImageTextBox.Size = new System.Drawing.Size(279, 20);
            this.backgroundImageTextBox.TabIndex = 13;
            this.backgroundImageTextBox.TabStop = false;
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Location = new System.Drawing.Point(391, 21);
            this.backgroundColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(31, 28);
            this.backgroundColorButton.TabIndex = 12;
            this.backgroundColorButton.Text = "...";
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.BackgroundColorButton_Click);
            // 
            // backgroundColorTextBox
            // 
            this.backgroundColorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backgroundColorTextBox.Location = new System.Drawing.Point(103, 23);
            this.backgroundColorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundColorTextBox.Name = "backgroundColorTextBox";
            this.backgroundColorTextBox.ReadOnly = true;
            this.backgroundColorTextBox.Size = new System.Drawing.Size(279, 20);
            this.backgroundColorTextBox.TabIndex = 11;
            this.backgroundColorTextBox.TabStop = false;
            // 
            // textGroupBox
            // 
            this.textGroupBox.Controls.Add(this.textColorLabel);
            this.textGroupBox.Controls.Add(this.textColorButton);
            this.textGroupBox.Controls.Add(this.textColorTextBox);
            this.textGroupBox.Controls.Add(this.shrinkToFitCheckBox);
            this.textGroupBox.Controls.Add(this.alignmentComboBox);
            this.textGroupBox.Controls.Add(this.alignmentLabel);
            this.textGroupBox.Controls.Add(this.fontTextBox);
            this.textGroupBox.Controls.Add(this.fontLabel);
            this.textGroupBox.Controls.Add(this.fontButton);
            this.textGroupBox.Location = new System.Drawing.Point(13, 95);
            this.textGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textGroupBox.Name = "textGroupBox";
            this.textGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textGroupBox.Size = new System.Drawing.Size(428, 151);
            this.textGroupBox.TabIndex = 11;
            this.textGroupBox.TabStop = false;
            this.textGroupBox.Text = "Text";
            // 
            // textColorLabel
            // 
            this.textColorLabel.AutoSize = true;
            this.textColorLabel.Location = new System.Drawing.Point(8, 62);
            this.textColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textColorLabel.Name = "textColorLabel";
            this.textColorLabel.Size = new System.Drawing.Size(36, 15);
            this.textColorLabel.TabIndex = 24;
            this.textColorLabel.Text = "Color";
            // 
            // textColorButton
            // 
            this.textColorButton.Location = new System.Drawing.Point(391, 55);
            this.textColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.textColorButton.Name = "textColorButton";
            this.textColorButton.Size = new System.Drawing.Size(31, 28);
            this.textColorButton.TabIndex = 9;
            this.textColorButton.Text = "...";
            this.textColorButton.UseVisualStyleBackColor = true;
            this.textColorButton.Click += new System.EventHandler(this.TextColorButton_Click);
            // 
            // textColorTextBox
            // 
            this.textColorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textColorTextBox.Location = new System.Drawing.Point(103, 58);
            this.textColorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.textColorTextBox.Name = "textColorTextBox";
            this.textColorTextBox.ReadOnly = true;
            this.textColorTextBox.Size = new System.Drawing.Size(279, 20);
            this.textColorTextBox.TabIndex = 22;
            this.textColorTextBox.TabStop = false;
            // 
            // shrinkToFitCheckBox
            // 
            this.shrinkToFitCheckBox.AutoSize = true;
            this.shrinkToFitCheckBox.Location = new System.Drawing.Point(103, 119);
            this.shrinkToFitCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.shrinkToFitCheckBox.Name = "shrinkToFitCheckBox";
            this.shrinkToFitCheckBox.Size = new System.Drawing.Size(129, 19);
            this.shrinkToFitCheckBox.TabIndex = 11;
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
            this.alignmentComboBox.Location = new System.Drawing.Point(103, 89);
            this.alignmentComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.alignmentComboBox.Name = "alignmentComboBox";
            this.alignmentComboBox.Size = new System.Drawing.Size(316, 24);
            this.alignmentComboBox.TabIndex = 10;
            this.alignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.AlignmentComboBox_SelectedIndexChanged);
            // 
            // alignmentLabel
            // 
            this.alignmentLabel.AutoSize = true;
            this.alignmentLabel.Location = new System.Drawing.Point(8, 93);
            this.alignmentLabel.Name = "alignmentLabel";
            this.alignmentLabel.Size = new System.Drawing.Size(62, 15);
            this.alignmentLabel.TabIndex = 8;
            this.alignmentLabel.Text = "Alignment";
            // 
            // fontTextBox
            // 
            this.fontTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fontTextBox.Location = new System.Drawing.Point(103, 23);
            this.fontTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fontTextBox.Name = "fontTextBox";
            this.fontTextBox.ReadOnly = true;
            this.fontTextBox.Size = new System.Drawing.Size(279, 20);
            this.fontTextBox.TabIndex = 7;
            this.fontTextBox.TabStop = false;
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(8, 27);
            this.fontLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(31, 15);
            this.fontLabel.TabIndex = 3;
            this.fontLabel.Text = "Font";
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(391, 21);
            this.fontButton.Margin = new System.Windows.Forms.Padding(4);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(31, 28);
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
            this.sourceLocationGroupBox.Location = new System.Drawing.Point(13, 12);
            this.sourceLocationGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sourceLocationGroupBox.Name = "sourceLocationGroupBox";
            this.sourceLocationGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sourceLocationGroupBox.Size = new System.Drawing.Size(428, 65);
            this.sourceLocationGroupBox.TabIndex = 8;
            this.sourceLocationGroupBox.TabStop = false;
            this.sourceLocationGroupBox.Text = "Source";
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pathTextBox.Location = new System.Drawing.Point(103, 23);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(279, 20);
            this.pathTextBox.TabIndex = 5;
            this.pathTextBox.TabStop = false;
            this.pathTextBox.Text = global::AMSoftware.Quotes.Properties.Settings.Default.SourcePath;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(8, 27);
            this.pathLabel.Margin = new System.Windows.Forms.Padding(4);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(32, 15);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Path";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(391, 21);
            this.pathButton.Margin = new System.Windows.Forms.Padding(4);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(31, 28);
            this.pathButton.TabIndex = 6;
            this.pathButton.Text = "...";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // configurationTabControl
            // 
            this.configurationTabControl.Controls.Add(this.generalTabPage);
            this.configurationTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.configurationTabControl.Location = new System.Drawing.Point(8, 7);
            this.configurationTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.configurationTabControl.Name = "configurationTabControl";
            this.configurationTabControl.Padding = new System.Drawing.Point(0, 0);
            this.configurationTabControl.SelectedIndex = 0;
            this.configurationTabControl.Size = new System.Drawing.Size(465, 534);
            this.configurationTabControl.TabIndex = 1;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(373, 551);
            this.applyButton.Margin = new System.Windows.Forms.Padding(4);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(100, 28);
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
            this.colorDialog.FullOpen = true;
            // 
            // fontDialog
            // 
            this.fontDialog.AllowScriptChange = false;
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.Color = System.Drawing.Color.WhiteSmoke;
            this.fontDialog.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ScriptsOnly = true;
            this.fontDialog.ShowEffects = false;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(481, 587);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.configurationTabControl);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Quotes Screensaver";
            this.generalTabPage.ResumeLayout(false);
            this.backgroundGroupBox.ResumeLayout(false);
            this.backgroundGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundOpacityNumericUpDown)).EndInit();
            this.textGroupBox.ResumeLayout(false);
            this.textGroupBox.PerformLayout();
            this.sourceLocationGroupBox.ResumeLayout(false);
            this.sourceLocationGroupBox.PerformLayout();
            this.configurationTabControl.ResumeLayout(false);
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
        private System.Windows.Forms.Label textColorLabel;
        private System.Windows.Forms.Button textColorButton;
        private System.Windows.Forms.TextBox textColorTextBox;
        private System.Windows.Forms.Label backgroundOpacityLabel;
        private System.Windows.Forms.NumericUpDown backgroundOpacityNumericUpDown;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button editButton;
    }
}