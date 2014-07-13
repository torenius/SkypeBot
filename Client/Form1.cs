using Client.PeriodicMessage;
using Client.SkypeStuff;
using SkypeBot.WCF;
using System.Windows.Forms;
using System;

namespace Client
{
    public partial class Form1 : Form
    {
        private SkypeControl sc;
        private PeriodicMessageControl pm;
        private ConnectToServer _cts;

        public Form1()
        {
            InitializeComponent();
            
            tabControl1.TabPages[0].Text = "SkypeInfo";
            sc = (SkypeControl)tabControl1.TabPages[0].Controls["skypeControl1"];
            
            tabControl1.TabPages[1].Text = "PeriodicMessage";
            pm = (PeriodicMessageControl)tabControl1.TabPages[1].Controls["periodicMessageControl1"];

            tabControl1.Selected += tabControl1_Selected;

            _cts = new ConnectToServer();
            _cts.ConnectCompleted += _cts_ConnectCompleted;
            _cts.StartConnect();

            MessageBox.Show(Application.LocalUserAppDataPath);
        }

        /// <summary>
        /// När aktuell flik ändras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            // När användare klickar på SkypeInfo fliken
            if (e.TabPageIndex == 0)
            {
                sc.PopulateChatListView();
            }
            // När användare klickar på PeriodicMessage fliken
            else if (e.TabPageIndex == 1)
            {
                pm.PopulatePeriodicMessageListbox();
            }

            Refresh();
        }

        /// <summary>
        /// Event när anslutning antigen har lyckats eller misslyckats.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _cts_ConnectCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                MessageBox.Show("Could not connect to server!\nClosing application.");
                if (e.Error != null)
                {
                    Console.WriteLine("Connect to server error: " + e.Error.Message);
                }
                this.Close();
                return;
            }

            ISkypeBot sb = e.Result as ISkypeBot;

            if (sb != null)
            {
                sc.SetSkypeHandler(sb);
                pm.SetPeriodicMessage(sb);
            }
        }
    }
}
