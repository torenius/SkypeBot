using SkypeBot.PeriodicMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.PeriodicMessage
{
    class PeriodicMessageMockup : IPeriodicMessage
    {
        public List<PeriodicMessageSetting> GetAllPeriodicMessages()
        {
            return new List<PeriodicMessageSetting>();
        }

        public PeriodicMessageSetting InsertUpdatePeriodMessage(PeriodicMessageSetting pms)
        {
            return new PeriodicMessageSetting();
        }

        public bool DeletePeriodicMessage(PeriodicMessageSetting pms)
        {
            return false;
        }
    }
}
