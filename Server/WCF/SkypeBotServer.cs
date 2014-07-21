using Server.AutomaticReplyStuff;
using Server.PeriodicMessageStuff;
using Server.SkypeStuff;
using SkypeBot.AutomaticReply;
using SkypeBot.PeriodicMessage;
using SkypeBot.SkypeStuff;
using SkypeBot.WCF;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server.WCF
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single, 
        IncludeExceptionDetailInFaults=true)]
    public class SkypeBotServer : ISkypeBot
    {
        private SkypeHandler _skypeHandler;
        private PeriodicMessage _periodicMessage;
        private AutomaticReply _automaticReply;

        public SkypeBotServer()
        {
            _skypeHandler = new SkypeHandler();
            _periodicMessage = new PeriodicMessage(_skypeHandler);
            _automaticReply = new AutomaticReply(_skypeHandler);
        }

        /// <summary>
        /// Används för att test ifall man har anslutning till servern.
        /// </summary>
        /// <returns></returns>
        public string ping()
        {
            Console.WriteLine("PingPong");
            return "pong";
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

        /// <inheritdoc />
        public List<AutomaticReplySetting> GetAllAutomaticReply()
        {
            return _automaticReply.GetAllAutomaticReply();
        }

        /// <inheritdoc />
        public string GetInfoList()
        {
            return _automaticReply.GetInfoList();
        }

        /// <inheritdoc />
        public AutomaticReplySetting InsertUpdateAutomaticReply(AutomaticReplySetting ars)
        {
            return _automaticReply.InsertUpdateAutomaticReply(ars);
        }

        /// <inheritdoc />
        public bool DeleteAutomaticReply(AutomaticReplySetting ars)
        {
            return _automaticReply.DeleteAutomaticReply(ars);
        }
    }
}
