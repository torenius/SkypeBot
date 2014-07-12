using Server.PeriodicMessageStuff;
using Server.SkypeStuff;
using SkypeBot.PeriodicMessage;
using SkypeBot.SkypeStuff;
using SkypeBot.WCF;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server.WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SkypeBotServer : ISkypeBot
    {
        private SkypeHandler _skypeHandler;
        private PeriodicMessage _periodicMessage;

        public SkypeBotServer()
        {
            _skypeHandler = new SkypeHandler();
            _periodicMessage = new PeriodicMessage(_skypeHandler);
        }

        /// <inheritdoc />
        public List<ChatInfo> GetActiveChats()
        {
            return _skypeHandler.GetActiveChats();
        }

        /// <inheritdoc />
        public ChatInfo GetChatInfo(string ChatCode)
        {
           return _skypeHandler.GetChatInfo(ChatCode);
        }

        /// <inheritdoc />
        public List<PeriodicMessageSetting> GetAllPeriodicMessages()
        {
            return _periodicMessage.GetAllPeriodicMessages();
        }

        /// <inheritdoc />
        public PeriodicMessageSetting InsertUpdatePeriodMessage(PeriodicMessageSetting pms)
        {
            return _periodicMessage.InsertUpdatePeriodMessage(pms);
        }

        /// <inheritdoc />
        public bool DeletePeriodicMessage(PeriodicMessageSetting pms)
        {
            return _periodicMessage.DeletePeriodicMessage(pms);
        }

        public string ping()
        {
            return "pong";
        }
    }
}
