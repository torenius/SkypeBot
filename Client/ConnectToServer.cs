﻿using SkypeBot.WCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class ConnectToServer
    {
        private BackgroundWorker _bw;

        /// <summary>
        /// Försöker ansluta till servern.
        /// </summary>
        public ConnectToServer()
        {
            _bw = new BackgroundWorker();

            _bw.DoWork += _bw_DoWork;
            _bw.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Om man vill avbryta anslutningsförsöken.
        /// </summary>
        public void CancelConnect()
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
            }
        }

        /// <summary>
        /// Starta anslutningsförsök.
        /// </summary>
        public void StartConnect()
        {
            if (!_bw.IsBusy)
            {
                _bw.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gör allt jobb. Försöker ansluta.
        /// Fortsätter att försöka till en av tre saker händer.
        /// 1. Anslutning lyckas
        /// 2. Användaren väljer att avbryta i InputDialog
        /// 3. Programer har sagt åt backgroundworkern att avsluta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ISkypeBot sb = null;
            bool cancel;
            string connectionString = Properties.Settings.Default.WCFConnectionString;

            do{
                cancel = false;

                Console.WriteLine("Try to connect to: " + connectionString);
                sb = StartWCFClient(connectionString);

                if (sb == null)
                {
                    cancel = !ShowInputDialog(ref connectionString);
                }

            }while(sb == null && !cancel && !_bw.CancellationPending);

            e.Cancel = _bw.CancellationPending || cancel;
            e.Result = sb;

            if (sb != null)
            {
                Properties.Settings.Default.WCFConnectionString = connectionString;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Visar en ruta där användaren kan skriva in ip:port
        /// </summary>
        /// <param name="connectionString">In = värde som visas som senast försöket. Ut = värde användaren skrev i rutan.</param>
        /// <returns>True om användaren trycke på Retry, annars False.</returns>
        private bool ShowInputDialog(ref string connectionString)
        {
            using (InputDialog d = new InputDialog(
                "Could not connect to server! Specify IP:Port",
                connectionString, 
                "Connect to server",
                "Retry", 
                "Abort"))
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    connectionString = d.InputMessage;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Försöker ansluta till server.
        /// </summary>
        /// <param name="connectionString">localhost:14445</param>
        /// <returns>Null om fail annars ISkypeBot</returns>
        private ISkypeBot StartWCFClient(string connectionString)
        {
            ISkypeBot sb = null;
            try
            {
                ChannelFactory<ISkypeBot> tcpFactory =
                    new ChannelFactory<ISkypeBot>(
                        new NetTcpBinding(SecurityMode.None),
                        new EndpointAddress("net.tcp://" + connectionString + "/SkypeBot"));

                sb = tcpFactory.CreateChannel();

                // Kontrollerar att det finns en anslutning
                sb.ping();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return sb;
        }

        /// <summary>
        /// Forwardar eventet om att allt är klart.
        /// </summary>
        public event RunWorkerCompletedEventHandler ConnectCompleted
        {
            add { _bw.RunWorkerCompleted += value; }
            remove { _bw.RunWorkerCompleted -= value; }
        }
    }
}
