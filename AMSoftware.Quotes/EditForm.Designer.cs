namespace AMSoftware.QuotesScreensaver
{
    partial class EditForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.quoteTextBox = new System.Windows.Forms.TextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.quoteTextLabel = new System.Windows.Forms.Label();
            this.quotesListView = new System.Windows.Forms.ListView();
            this.quoteColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.authorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sourceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yearColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonPanel.SuspendLayout();
            this.detailsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(527, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(8, 534);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(630, 34);
            this.buttonPanel.TabIndex = 1;
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.sourceTextBox);
            this.detailsGroupBox.Controls.Add(this.sourceLabel);
            this.detailsGroupBox.Controls.Add(this.updateButton);
            this.detailsGroupBox.Controls.Add(this.yearTextBox);
            this.detailsGroupBox.Controls.Add(this.authorTextBox);
            this.detailsGroupBox.Controls.Add(this.quoteTextBox);
            this.detailsGroupBox.Controls.Add(this.yearLabel);
            this.detailsGroupBox.Controls.Add(this.authorLabel);
            this.detailsGroupBox.Controls.Add(this.quoteTextLabel);
            this.detailsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.detailsGroupBox.Location = new System.Drawing.Point(8, 309);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(630, 225);
            this.detailsGroupBox.TabIndex = 2;
            this.detailsGroupBox.TabStop = false;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceTextBox.Enabled = false;
            this.sourceTextBox.Location = new System.Drawing.Point(100, 139);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(524, 20);
            this.sourceTextBox.TabIndex = 5;
            // 
            // sourceLabel
            // 
            this.sourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(6, 142);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(46, 15);
            this.sourceLabel.TabIndex = 6;
            this.sourceLabel.Text = "Source";
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(524, 191);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 28);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // yearTextBox
            // 
            this.yearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearTextBox.Enabled = false;
            this.yearTextBox.Location = new System.Drawing.Point(100, 165);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(524, 20);
            this.yearTextBox.TabIndex = 6;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorTextBox.Enabled = false;
            this.authorTextBox.Location = new System.Drawing.Point(100, 113);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(524, 20);
            this.authorTextBox.TabIndex = 4;
            // 
            // quoteTextBox
            // 
            this.quoteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quoteTextBox.Enabled = false;
            this.quoteTextBox.Location = new System.Drawing.Point(100, 13);
            this.quoteTextBox.Multiline = true;
            this.quoteTextBox.Name = "quoteTextBox";
            this.quoteTextBox.Size = new System.Drawing.Size(524, 94);
            this.quoteTextBox.TabIndex = 3;
            // 
            // yearLabel
            // 
            this.yearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(6, 168);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(32, 15);
            this.yearLabel.TabIndex = 2;
            this.yearLabel.Text = "Year";
            // 
            // authorLabel
            // 
            this.authorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(6, 116);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(42, 15);
            this.authorLabel.TabIndex = 1;
            this.authorLabel.Text = "Author";
            // 
            // quoteTextLabel
            // 
            this.quoteTextLabel.AutoSize = true;
            this.quoteTextLabel.Location = new System.Drawing.Point(6, 16);
            this.quoteTextLabel.Name = "quoteTextLabel";
            this.quoteTextLabel.Size = new System.Drawing.Size(40, 15);
            this.quoteTextLabel.TabIndex = 0;
            this.quoteTextLabel.Text = "Quote";
            // 
            // quotesListView
            // 
            this.quotesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.quotesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.quoteColumnHeader,
            this.authorColumnHeader,
            this.sourceColumnHeader,
            this.yearColumnHeader});
            this.quotesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quotesListView.FullRowSelect = true;
            this.quotesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.quotesListView.HideSelection = false;
            this.quotesListView.Location = new System.Drawing.Point(8, 8);
            this.quotesListView.Name = "quotesListView";
            this.quotesListView.Size = new System.Drawing.Size(630, 301);
            this.quotesListView.TabIndex = 1;
            this.quotesListView.UseCompatibleStateImageBehavior = false;
            this.quotesListView.View = System.Windows.Forms.View.Details;
            this.quotesListView.SelectedIndexChanged += new System.EventHandler(this.QuotesListView_SelectedIndexChanged);
            // 
            // quoteColumnHeader
            // 
            this.quoteColumnHeader.Text = "Quote";
            this.quoteColumnHeader.Width = 360;
            // 
            // authorColumnHeader
            // 
            this.authorColumnHeader.Text = "Author";
            this.authorColumnHeader.Width = 180;
            // 
            // sourceColumnHeader
            // 
            this.sourceColumnHeader.Text = "Source";
            // 
            // yearColumnHeader
            // 
            this.yearColumnHeader.Text = "Year";
            // 
            // EditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 576);
            this.Controls.Add(this.quotesListView);
            this.Controls.Add(this.detailsGroupBox);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "EditForm";
            this.Shown += new System.EventHandler(this.EditForm_Shown);
            this.Resize += new System.EventHandler(this.EditForm_Resize);
            this.buttonPanel.ResumeLayout(false);
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.ListView quotesListView;
        private System.Windows.Forms.ColumnHeader quoteColumnHeader;
        private System.Windows.Forms.ColumnHeader authorColumnHeader;
        private System.Windows.Forms.ColumnHeader yearColumnHeader;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.TextBox quoteTextBox;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label quoteTextLabel;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.ColumnHeader sourceColumnHeader;
    }
}