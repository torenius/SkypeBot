using Server.SkypeStuff;
using SkypeBot.AutomaticReply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AutomaticReplyStuff
{
    public class AutomaticReply : IAutomaticReply
    {
        private SkypeHandler _skype;
        private AutomaticReplyDB _db;
        private Dictionary<string, AutomaticReplySetting> _settings;

        public AutomaticReply(SkypeHandler skypeHandler)
        {
            _skype = skypeHandler;

            _db = new AutomaticReplyDB();
            _settings = _db.GetAllAutomaticReplyFromDB();

            _skype.NewMessage += Skype_NewMessage;
        }
        
        /// <summary>
        /// Returnerar alla replysetting i en lista.
        /// </summary>
        /// <returns>Lista med alla regler.</returns>
        public List<AutomaticReplySetting> GetAllAutomaticReply()
        {
            return _settings.Values.ToList();
        }

        /// <summary>
        /// Returnerar en lista på saker som man kan använda i svaren.
        /// </summary>
        /// <returns></returns>
        public string GetInfoList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Will be replaced in reply:");
            sb.AppendLine("%s - Senders name");

            return sb.ToString();
        }

        /// <summary>
        /// Uppdaterar eller skappar ett nytt AutomaticReply.
        /// </summary>
        /// <param name="ars">Objektet som ska ändras eller läggas till</param>
        /// <returns>Null om det misslyckades. Annars objektet.</returns>
        public AutomaticReplySetting InsertUpdateAutomaticReply(AutomaticReplySetting ars)
        {
            ars = _db.InsertUpdateDB(ars);

            if (ars != null && !string.IsNullOrWhiteSpace(ars.TriggerMessage))
            {
                _settings[ars.TriggerMessage] = ars;

                return ars;
            }

            return null;
        }

        /// <summary>
        /// Ta bort ett AutomaticReply
        /// </summary>
        /// <param name="ars">Replyet som ska tas bort</param>
        /// <returns>True om det togs bort annars false</returns>
        public bool DeleteAutomaticReply(AutomaticReplySetting ars)
        {
            if (ars == null || string.IsNullOrWhiteSpace(ars.TriggerMessage))
            {
                return false;
            }

            _settings.Remove(ars.TriggerMessage);
            _db.DeleteAutomaticReplyDB(ars);

            return true;
        }

        /// <summary>
        /// Event som sker när någon i chatten skriver något.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Skype_NewMessage(object sender, MessageEvent e)
        {
            if (string.IsNullOrWhiteSpace(e.Message))
            {
                return;
            }

            AutomaticReplySetting ars;
            if (!_settings.TryGetValue(e.Message, out ars))
            {
                return;
            }

            string reply = ars.ReplyMessage.Replace("%s", e.Sender);

            _skype.SendChatMessage(e.ChatCode, reply);
        }
    }
}
