namespace SkypeBot.PeriodicMessage
{
    public class PeriodicMessageSetting
    {
        private int _dueTime;
        private int _period;

        /// <summary>
        /// Används när en ny post ska skapas.
        /// PeriodicMessageId får värdet -1
        /// </summary>
        public PeriodicMessageSetting()
        {
            PeriodicMessageId = -1;
        }

        /// <summary>
        /// Används när information hämtas från databasen så att en befintlig post kan uppdateras.
        /// </summary>
        /// <param name="periodicMessageId">Id-värde som inställningen sparats med i databasen.</param>
        public PeriodicMessageSetting(int periodicMessageId)
        {
            PeriodicMessageId = periodicMessageId;
        }

        /// <summary>
        /// Id-värde som meddelandet sparats med i databasen.
        /// </summary>
        public int PeriodicMessageId { get; set; }

        /// <summary>
        /// Title för att komma ihåg vad det är för meddelande.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Meddelandet som periodiskt ska skrivas.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Chatten som meddelandet ska skrivas till.
        /// </summary>
        public string ChatName { get; set; }

        /// <summary>
        /// Hur länge man ska vänta innan första meddelandet skickas (i sekunder).
        /// 0 eller längre för direkt.
        /// </summary>
        public int DueTime
        {
            get
            {
                return _dueTime;
            }
            set
            {
                if (value < 0)
                {
                    _dueTime = 0;
                }
                else
                {
                    _dueTime = value;
                }
            }
        }

        /// <summary>
        /// Med vilket intervall ska meddelandet återkomma efter att det skickats första gången.
        /// Ange i ekunder. 0 eller lägre betyder att det inte ska fortsättas skickas.
        /// </summary>
        public int Period
        {
            get
            {
                return _period;
            }
            set
            {
                if (value < 1)
                {
                    _period = -1;
                }
                else
                {
                    _period = value;
                }
            }
        }

        /// <summary>
        /// Är det periodiska meddelandet aktivt?
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Id värde + title
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (PeriodicMessageId < 0 ? "" : PeriodicMessageId + ". ") + Title;
        }
    }
}
