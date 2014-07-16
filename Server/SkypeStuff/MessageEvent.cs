using System;
using System.Text;

namespace Server.SkypeStuff
{
    public class MessageEvent : EventArgs
    {
        /// <summary>
        /// Vem som skickade meddelandet
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Meddelandet
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Chaten som meddelandet skrevs i.
        /// </summary>
        public string ChatCode { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Sender: ");
            sb.Append(Sender);
            sb.Append(" Message: ");
            sb.Append(Message);
            sb.Append(" ChatCode: " + ChatCode);

            return sb.ToString();
        }
    }
}
