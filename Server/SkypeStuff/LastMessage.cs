using System;

namespace Server.SkypeStuff
{
    /// <summary>
    /// Klass för att smidigt kunna göra fler kontroller än bara likvärdigt meddelande.
    /// I dagsläget kontrolleras även tiden mellan två lika.
    /// </summary>
    class LastMessage
    {
        private DateTime _controlDateTime;

        public LastMessage()
        {
            _controlDateTime = DateTime.Now.AddMilliseconds(700);
        }

        public LastMessage(string message)
            : this()
        {
            Message = message;
        }

        public string Message { get; set; }

        public bool IsLastMessage(string message)
        {
            // Kontrollerar tiden för att man ska kunna skicka ett periodiskt meddelande
            // men man ska inte få spam

            return Message.Equals(message) && DateTime.Now < _controlDateTime;
        }
    }
}
