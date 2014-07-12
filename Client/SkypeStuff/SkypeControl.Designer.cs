namespace Client.SkypeStuff
{
    partial class SkypeControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ChatListView = new System.Windows.Forms.ListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ChatCountLabel = new System.Windows.Forms.Label();
            this.ChatCodeLabel = new System.Windows.Forms.Label();
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.UserListView = new System.Windows.Forms.ListView();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.CountBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(467, 301);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active chats:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ChatListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(467, 272);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.TabIndex = 0;
            // 
            // ChatListView
            // 
            this.ChatListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatListView.Location = new System.Drawing.Point(0, 0);
            this.ChatListView.MultiSelect = false;
            this.ChatListView.Name = "ChatListView";
            this.ChatListView.Size = new System.Drawing.Size(175, 272);
            this.ChatListView.TabIndex = 0;
            this.ChatListView.UseCompatibleStateImageBehavior = false;
            this.ChatListView.View = System.Windows.Forms.View.Tile;
            this.ChatListView.SelectedIndexChanged += new System.EventHandler(this.ChatListView_SelectedIndexChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.CountBox);
            this.splitContainer3.Panel1.Controls.Add(this.CodeBox);
            this.splitContainer3.Panel1.Controls.Add(this.NameBox);
            this.splitContainer3.Panel1.Controls.Add(this.ChatCountLabel);
            this.splitContainer3.Panel1.Controls.Add(this.ChatCodeLabel);
            this.splitContainer3.Panel1.Controls.Add(this.ChatNameLabel);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.UserListView);
            this.splitContainer3.Size = new System.Drawing.Size(288, 272);
            this.splitContainer3.SplitterDistance = 92;
            this.splitContainer3.TabIndex = 0;
            // 
            // ChatCountLabel
            // 
            this.ChatCountLabel.AutoSize = true;
            this.ChatCountLabel.Location = new System.Drawing.Point(4, 51);
            this.ChatCountLabel.Name = "ChatCountLabel";
            this.ChatCountLabel.Size = new System.Drawing.Size(38, 13);
            this.ChatCountLabel.TabIndex = 2;
            this.ChatCountLabel.Text = "Count:";
            // 
            // ChatCodeLabel
            // 
            this.ChatCodeLabel.AutoSize = true;
            this.ChatCodeLabel.Location = new System.Drawing.Point(4, 28);
            this.ChatCodeLabel.Name = "ChatCodeLabel";
            this.ChatCodeLabel.Size = new System.Drawing.Size(35, 13);
            this.ChatCodeLabel.TabIndex = 1;
            this.ChatCodeLabel.Text = "Code:";
            // 
            // ChatNameLabel
            // 
            this.ChatNameLabel.AutoSize = true;
            this.ChatNameLabel.Location = new System.Drawing.Point(4, 4);
            this.ChatNameLabel.Name = "ChatNameLabel";
            this.ChatNameLabel.Size = new System.Drawing.Size(38, 13);
            this.ChatNameLabel.TabIndex = 0;
            this.ChatNameLabel.Text = "Name:";
            // 
            // UserListView
            // 
            this.UserListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserListView.Location = new System.Drawing.Point(0, 0);
            this.UserListView.Name = "UserListView";
            this.UserListView.Size = new System.Drawing.Size(288, 176);
            this.UserListView.TabIndex = 0;
            this.UserListView.UseCompatibleStateImageBehavior = false;
            this.UserListView.View = System.Windows.Forms.View.Tile;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(40, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(245, 20);
            this.NameBox.TabIndex = 3;
            // 
            // CodeBox
            // 
            this.CodeBox.Location = new System.Drawing.Point(40, 28);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(245, 20);
            this.CodeBox.TabIndex = 4;
            // 
            // CountBox
            // 
            this.CountBox.Location = new System.Drawing.Point(40, 51);
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(245, 20);
            this.CountBox.TabIndex = 5;
            // 
            // SkypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SkypeControl";
            this.Size = new System.Drawing.Size(467, 301);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView ChatListView;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView UserListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ChatCountLabel;
        private System.Windows.Forms.Label ChatCodeLabel;
        private System.Windows.Forms.Label ChatNameLabel;
        private System.Windows.Forms.TextBox CountBox;
        private System.Windows.Forms.TextBox CodeBox;
        private System.Windows.Forms.TextBox NameBox;

    }
}
