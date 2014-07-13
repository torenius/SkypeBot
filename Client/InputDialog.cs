﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();
            // Ifall användaren trycker på kryset så har vi rätt status.
            this.DialogResult = DialogResult.Cancel;
        }

        public InputDialog(string message)
            : this()
        {
            MessageLabel.Text = message;
        }

        public InputDialog(string message, string input)
            : this(message)
        {
            InputBox.Text = input;            
        }

        public InputDialog(string message, string input, string title, string okButton, string cancelButton)
            : this(message, input)
        {
            this.Text = title;
            OkButton.Text = okButton;
            CancelButton.Text = cancelButton;
        }

        /// <summary>
        /// Meddelandet som användaren skrev in.
        /// </summary>
        public string InputMessage
        {
            get
            {
                return InputBox.Text;
            }
        }

        /// <summary>
        /// Tryckte på Ok knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Tryckte på cancel knappen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Motsvarar att användaren trycker på Ok.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
