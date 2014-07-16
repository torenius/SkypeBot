namespace Client.AutomaticReply
{
    partial class AutomaticReplyControl
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
            this.TriggerMessageList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.ReplyBox = new System.Windows.Forms.RichTextBox();
            this.ReplyLabel = new System.Windows.Forms.Label();
            this.TriggerMessageBox = new System.Windows.Forms.TextBox();
            this.TriggerMessageLabel = new System.Windows.Forms.Label();
            this.InfoBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.TriggerMessageList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(587, 315);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 0;
            // 
            // TriggerMessageList
            // 
            this.TriggerMessageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TriggerMessageList.FormattingEnabled = true;
            this.TriggerMessageList.Location = new System.Drawing.Point(0, 0);
            this.TriggerMessageList.Name = "TriggerMessageList";
            this.TriggerMessageList.Size = new System.Drawing.Size(175, 315);
            this.TriggerMessageList.TabIndex = 0;
            this.TriggerMessageList.SelectedIndexChanged += new System.EventHandler(this.TriggerMessageList_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DeleteButton);
            this.splitContainer2.Panel1.Controls.Add(this.UpdateButton);
            this.splitContainer2.Panel1.Controls.Add(this.NewButton);
            this.splitContainer2.Panel1.Controls.Add(this.ReplyBox);
            this.splitContainer2.Panel1.Controls.Add(this.ReplyLabel);
            this.splitContainer2.Panel1.Controls.Add(this.TriggerMessageBox);
            this.splitContainer2.Panel1.Controls.Add(this.TriggerMessageLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.InfoBox);
            this.splitContainer2.Size = new System.Drawing.Size(408, 315);
            this.splitContainer2.SplitterDistance = 248;
            this.splitContainer2.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(167, 196);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(86, 196);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 12;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(5, 196);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 11;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // ReplyBox
            // 
            this.ReplyBox.Location = new System.Drawing.Point(5, 70);
            this.ReplyBox.Name = "ReplyBox";
            this.ReplyBox.Size = new System.Drawing.Size(237, 120);
            this.ReplyBox.TabIndex = 10;
            this.ReplyBox.Text = "";
            // 
            // ReplyLabel
            // 
            this.ReplyLabel.AutoSize = true;
            this.ReplyLabel.Location = new System.Drawing.Point(2, 54);
            this.ReplyLabel.Name = "ReplyLabel";
            this.ReplyLabel.Size = new System.Drawing.Size(37, 13);
            this.ReplyLabel.TabIndex = 9;
            this.ReplyLabel.Text = "Reply:";
            // 
            // TriggerMessageBox
            // 
            this.TriggerMessageBox.Location = new System.Drawing.Point(5, 27);
            this.TriggerMessageBox.Name = "TriggerMessageBox";
            this.TriggerMessageBox.Size = new System.Drawing.Size(237, 20);
            this.TriggerMessageBox.TabIndex = 8;
            // 
            // TriggerMessageLabel
            // 
            this.TriggerMessageLabel.AutoSize = true;
            this.TriggerMessageLabel.Location = new System.Drawing.Point(2, 11);
            this.TriggerMessageLabel.Name = "TriggerMessageLabel";
            this.TriggerMessageLabel.Size = new System.Drawing.Size(88, 13);
            this.TriggerMessageLabel.TabIndex = 7;
            this.TriggerMessageLabel.Text = "Trigger message:";
            // 
            // InfoBox
            // 
            this.InfoBox.BackColor = System.Drawing.SystemColors.Window;
            this.InfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoBox.Location = new System.Drawing.Point(0, 0);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ReadOnly = true;
            this.InfoBox.Size = new System.Drawing.Size(156, 315);
            this.InfoBox.TabIndex = 0;
            this.InfoBox.TabStop = false;
            this.InfoBox.Text = "";
            // 
            // AutomaticReplyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AutomaticReplyControl";
            this.Size = new System.Drawing.Size(587, 315);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox TriggerMessageList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.RichTextBox ReplyBox;
        private System.Windows.Forms.Label ReplyLabel;
        private System.Windows.Forms.TextBox TriggerMessageBox;
        private System.Windows.Forms.Label TriggerMessageLabel;
        private System.Windows.Forms.RichTextBox InfoBox;
    }
}
