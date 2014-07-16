using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeBot.AutomaticReply
{
    public class AutomaticReplySetting : IEquatable<AutomaticReplySetting>
    {
        public AutomaticReplySetting()
        {

        }

        /// <summary>
        /// Meddelandet som ska boten ska trigga på.
        /// </summary>
        public string TriggerMessage { get; set; }

        /// <summary>
        /// Meddelandet som ska skickas tillbaka.
        /// </summary>
        public string ReplyMessage { get; set; }

        /// <summary>
        /// To string blir bara TriggerMessage
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TriggerMessage;
        }

        public bool Equals(AutomaticReplySetting other)
        {
            return other.TriggerMessage.Equals(TriggerMessage);
        }
    }
}
