using SkypeBot.PeriodicMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Client.PeriodicMessage
{
    public partial class PeriodicMessageControl : UserControl
    {
        private IPeriodicMessage _pm;
        private BindingList<PeriodicMessageSetting> _pmsList;

        public PeriodicMessageControl()
        {
            InitializeComponent();

            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            TitleBox.Focus();

            _pmsList = new BindingList<PeriodicMessageSetting>();
            PeriodicMessageListbox.DataSource = _pmsList;
        }

        public void SetPeriodicMessage(IPeriodicMessage periodicMessage)
        {
            _pm = periodicMessage;

            PopulatePeriodicMessageListbox();
        }

        /// <summary>
        /// Fyller PeriodicMessageListan med värden.
        /// </summary>
        public void PopulatePeriodicMessageListbox()
        {
            if (_pm == null) return;

            Console.WriteLine("Populate PeriodicMessage");

            _pmsList = new BindingList<PeriodicMessageSetting>(_pm.GetAllPeriodicMessages());
            _pmsList.AllowEdit = true;
            _pmsList.AllowNew = true;
            _pmsList.AllowRemove = true;

            PeriodicMessageListbox.DataSource = _pmsList;
            PeriodicMessageListbox.Refresh();
        }

        private void PeriodicMessageListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodicMessageSetting pm = PeriodicMessageListbox.SelectedItem as PeriodicMessageSetting;

            if (pm == null)
            {
                UpdateButton.Enabled = false;
                DeleteButton.Enabled = false;

                return;
            }
            
            UpdateButton.Enabled = true;
            DeleteButton.Enabled = true;

            TitleBox.Text = pm.Title;
            ChatNameBox.Text = pm.ChatName;
            DueTimeBox.Text = "" + pm.DueTime;
            PeriodBox.Text = "" + pm.Period;
            MessageBox.Text = pm.Message;
            IsActiveBox.Checked = pm.IsActive;
        }

        /// <summary>
        /// Skapar en ny.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewButton_Click(object sender, EventArgs e)
        {
            PeriodicMessageSetting pms = new PeriodicMessageSetting();

            if (UpdateValuesFromFields(pms))
            {
                pms = _pm.InsertUpdatePeriodMessage(pms);

                if (pms != null)
                {
                    //PeriodicMessageListbox.Items.Add(pms);
                    _pmsList.Add(pms);
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
            PeriodicMessageSetting pms = PeriodicMessageListbox.SelectedItem as PeriodicMessageSetting;
            
            
            if (pms == null) return;

            if (UpdateValuesFromFields(pms))
            {
                PeriodicMessageSetting pmsUpdated = _pm.InsertUpdatePeriodMessage(pms);

                if (pmsUpdated != null)
                {
                    int i = _pmsList.IndexOf(pms);
                    _pmsList.ResetItem(i);
                    //_pmsList.Remove(pms);
                    //_pmsList.Add(pmsUpdated);
                    //PeriodicMessageListbox.Refresh();
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
            PeriodicMessageSetting pms = PeriodicMessageListbox.SelectedItem as PeriodicMessageSetting;

            if (pms == null) return;

            if(DialogResult.Yes == System.Windows.Forms.MessageBox.Show("Are you sure you like to delete '" + pms.Title + "'?", "Delete?", MessageBoxButtons.YesNo))
            {
                //PeriodicMessageListbox.Items.Remove(pms);
                _pmsList.Remove(pms);
                _pm.DeletePeriodicMessage(pms);
                UpdateButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        /// <summary>
        /// Hjälpmetod för att inte behöva göra samma sak på flera ställen.
        /// </summary>
        /// <param name="pm">Objekt som ska uppdatreras.</param>
        /// <returns>True om allt gick bra, False om något failade</returns>
        private bool UpdateValuesFromFields(PeriodicMessageSetting pm)
        {
            string errorMessage = string.Empty;

            pm.Title = TitleBox.Text;
            pm.ChatName = ChatNameBox.Text;
            pm.Message = MessageBox.Text;
            pm.IsActive = IsActiveBox.Checked;

            // Försöker parsa DueTime, om det misslyckas så sätts den till att skicka på direkten.
            int i;
            if (!int.TryParse(DueTimeBox.Text, out i))
            {
                i = 0;
            }
            pm.DueTime = i;

            // Försöker paras Period, om det misslyckas så sätts den till att bara skicka 1 gång.
            if (!int.TryParse(PeriodBox.Text, out i))
            {
                i = -1;
            }
            pm.Period = i;

            if (pm.Title.Equals(string.Empty))
            {
                errorMessage += "\nTitle";
            }

            if (pm.ChatName.Equals(string.Empty))
            {
                errorMessage += "\nChatName";
            }

            if (pm.Message.Equals(string.Empty))
            {
                errorMessage += "\nMessage";
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
