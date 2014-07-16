using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkypeBot.AutomaticReply;

namespace Client.AutomaticReply
{
    public partial class AutomaticReplyControl : UserControl
    {
        private IAutomaticReply _reply;
        private BindingList<AutomaticReplySetting> _arsList;

        public AutomaticReplyControl()
        {
            InitializeComponent();

            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            TriggerMessageBox.Focus();

            _arsList = new BindingList<AutomaticReplySetting>();
            TriggerMessageList.DataSource = _arsList;
        }

        public void SetAutomaticReply(IAutomaticReply automaticReply)
        {
            _reply = automaticReply;

            PopulateTriggerMessageList();
            UpdateInfoList();
        }

        /// <summary>
        /// Fyller TriggerMessageList med värden.
        /// </summary>
        public void PopulateTriggerMessageList()
        {
            if (_reply == null) return;

            _arsList = new BindingList<AutomaticReplySetting>(_reply.GetAllAutomaticReply());
            _arsList.AllowEdit = true;
            _arsList.AllowNew = true;
            _arsList.AllowRemove = true;

            TriggerMessageList.DataSource = _arsList;
            TriggerMessageList.Refresh();
        }

        /// <summary>
        /// Uppdaterar värdena i infolistan.
        /// Vad kan man skriva för att ersätta saker.
        /// </summary>
        public void UpdateInfoList()
        {
            if (_reply == null) return;

            InfoBox.Text = _reply.GetInfoList();
        }

        /// <summary>
        /// Event som triggar när man väljer nytt förempl i listan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TriggerMessageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutomaticReplySetting ars = TriggerMessageList.SelectedItem as AutomaticReplySetting;

            if (ars == null)
            {
                UpdateButton.Enabled = false;
                DeleteButton.Enabled = false;

                return;
            }

            UpdateButton.Enabled = true;
            DeleteButton.Enabled = true;

            TriggerMessageBox.Text = ars.TriggerMessage;
            ReplyBox.Text = ars.ReplyMessage;
        }

        /// <summary>
        /// Skapar en ny.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewButton_Click(object sender, EventArgs e)
        {
            AutomaticReplySetting ars = new AutomaticReplySetting();

            if (UpdateValuesFromFields(ars))
            {
                ars = _reply.InsertUpdateAutomaticReply(ars);

                if (ars != null)
                {
                    if (!_arsList.Contains(ars))
                    {
                        _arsList.Add(ars);
                    }
                }
            }
        }

        /// <summary>
        /// Uppdatera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            AutomaticReplySetting ars = TriggerMessageList.SelectedItem as AutomaticReplySetting;

            if (ars == null) return;

            if (UpdateValuesFromFields(ars))
            {
                if (_reply.InsertUpdateAutomaticReply(ars) != null)
                {
                    int i = _arsList.IndexOf(ars);
                    _arsList.ResetItem(i);
                }
            }
        }

        /// <summary>
        /// Ta bort.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            AutomaticReplySetting ars = TriggerMessageList.SelectedItem as AutomaticReplySetting;

            if (ars == null) return;

            if (DialogResult.Yes == System.Windows.Forms.MessageBox.Show("Are you sure you like to delete '" + ars.TriggerMessage + "'?", "Delete?", MessageBoxButtons.YesNo))
            {
                _arsList.Remove(ars);
                _reply.DeleteAutomaticReply(ars);
                UpdateButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        /// <summary>
        /// Hjälpmetod för att inte behöva göra samma sak på flera ställen.
        /// </summary>
        /// <param name="ars">Objektet som ska uppdateras.</param>
        /// <returns>True om allt gick bra, False om något failade</returns>
        private bool UpdateValuesFromFields(AutomaticReplySetting ars)
        {
            string errorMessage = string.Empty;

            if (TriggerMessageBox.Text.Equals(string.Empty))
            {
                errorMessage += "\nTrigger message";
            }
            else
            {
                ars.TriggerMessage = TriggerMessageBox.Text;
            }

            if (ReplyBox.Text.Equals(string.Empty))
            {
                errorMessage += "\nReply";
            }
            else
            {
                ars.ReplyMessage = ReplyBox.Text;
            }

            if (!errorMessage.Equals(string.Empty))
            {
                System.Windows.Forms.MessageBox.Show("The following field(s) need a value: " + errorMessage);

                return false;
            }

            return true;
        }
    }
}
