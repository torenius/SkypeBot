using Client.PeriodicMessage;
using Client.SkypeStuff;
using SkypeBot.WCF;
using System.ServiceModel;
using System.Windows.Forms;
using System;

namespace Client
{
    public partial class Form1 : Form
    {
        private SkypeControl sc;
        private PeriodicMessageControl pm;

        public Form1()
        {
            InitializeComponent();
            
            tabControl1.TabPages[0].Text = "SkypeInfo";
            sc = (SkypeControl)tabControl1.TabPages[0].Controls["skypeControl1"];
            
            tabControl1.TabPages[1].Text = "PeriodicMessage";
            pm = (PeriodicMessageControl)tabControl1.TabPages[1].Controls["periodicMessageControl1"];

            tabControl1.Selected += tabControl1_Selected;
            //ConnectToServer();
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

        private ISkypeBot StartWCFClient(string ip, string port)
        {
            ISkypeBot sb = null;
            try
            {
                ChannelFactory<ISkypeBot> tcpFactory =
                    new ChannelFactory<ISkypeBot>(
                        new NetTcpBinding(SecurityMode.None),
                        new EndpointAddress("net.tcp://" + ip + ":" + port + "/SkypeBot"));

                sb = tcpFactory.CreateChannel();
                
                // Kontrollerar att det finns en anslutning
                sb.ping();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return sb;
        }

        private void ConnectToServer()
        {
            ISkypeBot sb = StartWCFClient("localhost", "14445");
            //ISkypeBot sb = StartWCFClient("haj", "14445");
            //if (sb == null)
            //{
            //    ShowInputDialog();
            //    sb = StartWCFClient("localhost", "14445");
            //}

            sc.SetSkypeHandler(sb);
            pm.SetPeriodicMessage(sb);
        }

        private void ShowInputDialog()
        {
            using (InputDialog d = new InputDialog())
            {
                if (d.ShowDialog(this) == DialogResult.OK)
                {
                    Console.WriteLine("OK");
                }
            }
            //Output parameterar med ip och port. Returnerar true om man ska försöka igen, false om programet ska stängas ner.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() => { ConnectToServer(); }));
        }

    }
}
