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
                DeleteButton.Enabled = false;

                return;
            }

            DeleteButton.Enabled = true;

            TriggerMessageBox.Text = ars.TriggerMessage;
            ReplyBox.Text = ars.ReplyMessage;
        }

        /// <summary>
        /// Skapar ny eller uppdaterar befintlig
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewUpdateButton_Click(object sender, EventArgs e)
        {
            // Hämtar den valda, ifall ingen är vald så skapas en tom.
            AutomaticReplySetting ars = TriggerMessageList.SelectedItem as AutomaticReplySetting ?? new AutomaticReplySetting();

            // Hämtar det som finns i inställningsdelen.
            AutomaticReplySetting arsEdited = new AutomaticReplySetting();

            if (!UpdateValuesFromFields(arsEdited))
            {
                // Ifall det failade valideringen så returnera.
                return;
            }

            // Om den finns är i större än -1
            int i = _arsList.IndexOf(ars);
            int k = _arsList.IndexOf(arsEdited);

            // Om samma så blir det en update
            if (ars.Equals(arsEdited))
            {
                UpdateValuesFromFields(ars);
                if (_reply.InsertUpdateAutomaticReply(ars) != null)
                {
                    _arsList.ResetItem(i);
                }
            }
            // Det finns redan en med det namnet
            else if (i >= 0 && k >= 0 && i != k)
            {
                if (_reply.InsertUpdateAutomaticReply(arsEdited) != null)
                {
                    _arsList[k] = arsEdited;
                    _arsList.ResetItem(k);
                    TriggerMessageList.SelectedIndex = k;
                }
            }
            // Skapa en ny post
            else
            {
                arsEdited = _reply.InsertUpdateAutomaticReply(arsEdited);

                if (arsEdited != null)
                {
                    _arsList.Add(arsEdited);
                    TriggerMessageList.SelectedIndex = _arsList.IndexOf(arsEdited);
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
