using Server.SkypeStuff;
using SkypeBot.PeriodicMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Server.PeriodicMessageStuff
{
    public class PeriodicMessage : IPeriodicMessage, IDisposable
    {
        private SkypeHandler _skype;
        private Dictionary<int, PeriodicMessageSetting> _settings;
        private Dictionary<int, Timer> _timers;
        private PeriodicMessageDB _db;
        private static object TimerLock = new object();

        public PeriodicMessage(SkypeHandler skypeHandler)
        {
            _skype = skypeHandler;

            _db = new PeriodicMessageDB();
            _settings = _db.GetAllPeriodicMessageFromDB();
            _timers = new Dictionary<int, Timer>();

            foreach (PeriodicMessageSetting pms in GetAllPeriodicMessages())
            {
                if (pms.PeriodicMessageId > 0)
                {
                    UpdateTimer(pms.PeriodicMessageId);
                }
            }
        }

        /// <summary>
        /// Returnerar alla meddelanden i en lista.
        /// </summary>
        /// <returns>List med alla meddelanden</returns>
        public List<PeriodicMessageSetting> GetAllPeriodicMessages()
        {
            Console.WriteLine(" Count: " + _settings.Count);
            return _settings.Values.ToList();
        }

        /// <summary>
        /// Uppdaterar eller skapar ett nytt periodiskt meddelande.
        /// </summary>
        /// <param name="pms">Värden som ska ändras eller läggas till.</param>
        /// <returns>Null om det misslyckas annars klassen (med id värde om ny post)</returns>
        public PeriodicMessageSetting InsertUpdatePeriodMessage(PeriodicMessageSetting pms)
        {
            Console.WriteLine("InsertUpdate: " + pms.ToString() + " Count: " + _settings.Count);
            pms = _db.InsertUpdateDb(pms);
            if (pms != null && pms.PeriodicMessageId > 0)
            {
                _settings[pms.PeriodicMessageId] = pms;
                UpdateTimer(pms.PeriodicMessageId);
                return pms;
            }
            return null;
        }

        /// <summary>
        /// Tar bort ett periodiskt meddelande.
        /// </summary>
        /// <param name="pms">Meddelandet som ska tas bort.</param>
        /// <returns>Om det gick bra att ta bort eller itne.</returns>
        public bool DeletePeriodicMessage(PeriodicMessageSetting pms)
        {
            Console.WriteLine("Delete: " + pms.ToString() + " Count: " + _settings.Count);
            if (pms == null || pms.PeriodicMessageId == -1)
            {
                return false;
            }

            _settings.Remove(pms.PeriodicMessageId);

            Timer t = null;
            _timers.TryGetValue(pms.PeriodicMessageId, out t);

            if (t != null)
            {
                t.Dispose();
            }

            _db.DeleteDb(pms.PeriodicMessageId);

            return true;
        }

        /// <summary>
        /// Startar/stänger av eller uppdaterar värden.
        /// Finns det redan en timer så uppdateras bara tiden.
        /// Ifall IsActive = false, så stängs eventuell timer av.
        /// </summary>
        /// <param name="periodicMessageId">Id-värde</param>
        private void UpdateTimer(int periodicMessageId)
        {
            PeriodicMessageSetting pm = null;
            _settings.TryGetValue(periodicMessageId, out pm);

            if (pm == null) return;

            Timer t = null;
            _timers.TryGetValue(periodicMessageId, out t);

            // Kontrollerar om det finns en timer.
            if (t == null && pm.IsActive)
            {
                // Skapar timern och startar den.
                t = new Timer(HandleEventTime, pm, pm.DueTime * 1000, pm.Period * 1000);
                _timers[periodicMessageId] = t;
            }
            // Om meddelandet inte är aktivt så stänger vi av timern.
            else if (t != null && !pm.IsActive)
            {
                t.Dispose();
                _timers[periodicMessageId] = null;
            }
            // Annars så uppdaterar vi bara värdena.
            else if (t != null)
            {
                t.Change(pm.DueTime * 1000, pm.Period * 1000);
            }
        }

        /// <summary>
        /// Tar hand om att skriva meddelandet när timer skapar ett event.
        /// </summary>
        /// <param name="o">PeriodicMessageSetting</param>
        private void HandleEventTime(object o)
        {
            PeriodicMessageSetting pm = (PeriodicMessageSetting)o;
            _skype.SendChatMessage(pm.ChatName, pm.Message);
        }

        public void Dispose()
        {
            foreach (Timer t in _timers.Values)
            {
                if (t != null)
                {
                    t.Dispose();
                }
            }
        }
    }
}
