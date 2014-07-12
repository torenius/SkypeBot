namespace Client.PeriodicMessage
{
    partial class PeriodicMessageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PeriodicMessageListbox = new System.Windows.Forms.ListBox();
            this.ChatNameBox = new System.Windows.Forms.TextBox();
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.IsActiveBox = new System.Windows.Forms.CheckBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageBox = new System.Windows.Forms.RichTextBox();
            this.PeriodBox = new System.Windows.Forms.TextBox();
            this.PeriodLabel = new System.Windows.Forms.Label();
            this.DueTimeBox = new System.Windows.Forms.TextBox();
            this.DueTimeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PeriodicMessageListbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ChatNameBox);
            this.splitContainer1.Panel2.Controls.Add(this.ChatNameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.IsActiveBox);
            this.splitContainer1.Panel2.Controls.Add(this.DeleteButton);
            this.splitContainer1.Panel2.Controls.Add(this.UpdateButton);
            this.splitContainer1.Panel2.Controls.Add(this.NewButton);
            this.splitContainer1.Panel2.Controls.Add(this.MessageLabel);
            this.splitContainer1.Panel2.Controls.Add(this.MessageBox);
            this.splitContainer1.Panel2.Controls.Add(this.PeriodBox);
            this.splitContainer1.Panel2.Controls.Add(this.PeriodLabel);
            this.splitContainer1.Panel2.Controls.Add(this.DueTimeBox);
            this.splitContainer1.Panel2.Controls.Add(this.DueTimeLabel);
            this.splitContainer1.Panel2.Controls.Add(this.TitleLabel);
            this.splitContainer1.Panel2.Controls.Add(this.TitleBox);
            this.splitContainer1.Size = new System.Drawing.Size(609, 334);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 0;
            // 
            // PeriodicMessageListbox
            // 
            this.PeriodicMessageListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PeriodicMessageListbox.FormattingEnabled = true;
            this.PeriodicMessageListbox.Location = new System.Drawing.Point(0, 0);
            this.PeriodicMessageListbox.Name = "PeriodicMessageListbox";
            this.PeriodicMessageListbox.Size = new System.Drawing.Size(248, 334);
            this.PeriodicMessageListbox.TabIndex = 9;
            this.PeriodicMessageListbox.SelectedIndexChanged += new System.EventHandler(this.PeriodicMessageListbox_SelectedIndexChanged);
            // 
            // ChatNameBox
            // 
            this.ChatNameBox.Location = new System.Drawing.Point(7, 68);
            this.ChatNameBox.Name = "ChatNameBox";
            this.ChatNameBox.Size = new System.Drawing.Size(237, 20);
            this.ChatNameBox.TabIndex = 1;
            // 
            // ChatNameLabel
            // 
            this.ChatNameLabel.AutoSize = true;
            this.ChatNameLabel.Location = new System.Drawing.Point(4, 52);
            this.ChatNameLabel.Name = "ChatNameLabel";
            this.ChatNameLabel.Size = new System.Drawing.Size(60, 13);
            this.ChatNameLabel.TabIndex = 12;
            this.ChatNameLabel.Text = "ChatName:";
            // 
            // IsActiveBox
            // 
            this.IsActiveBox.AutoSize = true;
            this.IsActiveBox.Location = new System.Drawing.Point(7, 282);
            this.IsActiveBox.Name = "IsActiveBox";
            this.IsActiveBox.Size = new System.Drawing.Size(64, 17);
            this.IsActiveBox.TabIndex = 5;
            this.IsActiveBox.Text = "IsActive";
            this.IsActiveBox.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(169, 305);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(88, 305);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(7, 305);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 6;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(4, 133);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(53, 13);
            this.MessageLabel.TabIndex = 7;
            this.MessageLabel.Text = "Message:";
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(7, 149);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(237, 127);
            this.MessageBox.TabIndex = 4;
            this.MessageBox.Text = "";
            // 
            // PeriodBox
            // 
            this.PeriodBox.Location = new System.Drawing.Point(144, 110);
            this.PeriodBox.Name = "PeriodBox";
            this.PeriodBox.Size = new System.Drawing.Size(100, 20);
            this.PeriodBox.TabIndex = 3;
            // 
            // PeriodLabel
            // 
            this.PeriodLabel.AutoSize = true;
            this.PeriodLabel.Location = new System.Drawing.Point(141, 94);
            this.PeriodLabel.Name = "PeriodLabel";
            this.PeriodLabel.Size = new System.Drawing.Size(40, 13);
            this.PeriodLabel.TabIndex = 4;
            this.PeriodLabel.Text = "Period:";
            // 
            // DueTimeBox
            // 
            this.DueTimeBox.Location = new System.Drawing.Point(7, 110);
            this.DueTimeBox.Name = "DueTimeBox";
            this.DueTimeBox.Size = new System.Drawing.Size(100, 20);
            this.DueTimeBox.TabIndex = 2;
            // 
            // DueTimeLabel
            // 
            this.DueTimeLabel.AutoSize = true;
            this.DueTimeLabel.Location = new System.Drawing.Point(4, 94);
            this.DueTimeLabel.Name = "DueTimeLabel";
            this.DueTimeLabel.Size = new System.Drawing.Size(53, 13);
            this.DueTimeLabel.TabIndex = 2;
            this.DueTimeLabel.Text = "DueTime:";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(4, 13);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(30, 13);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title:";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(7, 29);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(237, 20);
            this.TitleBox.TabIndex = 0;
            // 
            // PeriodicMessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PeriodicMessageControl";
            this.Size = new System.Drawing.Size(609, 334);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox PeriodicMessageListbox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.RichTextBox MessageBox;
        private System.Windows.Forms.TextBox PeriodBox;
        private System.Windows.Forms.Label PeriodLabel;
        private System.Windows.Forms.TextBox DueTimeBox;
        private System.Windows.Forms.Label DueTimeLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.CheckBox IsActiveBox;
        private System.Windows.Forms.TextBox ChatNameBox;
        private System.Windows.Forms.Label ChatNameLabel;
    }
}
