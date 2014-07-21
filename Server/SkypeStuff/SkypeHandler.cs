using SKYPE4COMLib;
using SkypeBot.SkypeStuff;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Server.SkypeStuff
{
    // Publict delegate event för nya meddelanden från skype.
    public delegate void NewMessageEventHandler(object sender, MessageEvent e);

    /// <summary>
    /// Den här klassen innehåller all interaktion med Skype.
    /// </summary>
    public class SkypeHandler : ISkypeHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Skype _skype;
        private Dictionary<string, LastMessage> _lastMessages;
        private string _botUsername;

        /// <summary>
        /// Event att ansluta på för att få info om nya meddelanden.
        /// </summary>
        public event NewMessageEventHandler NewMessage;

        // Skickar meddelande till alla som lyssnar
        private void OnNewMessage(MessageEvent e)
        {
            if (NewMessage != null)
            {
                NewMessage(this, e);
            }
        }

        /// <summary>
        /// Klass för att ta hand om att skicka och ta emot meddelande via skype.
        /// </summary>
        public SkypeHandler()
        {
            // Dictonary för att hålla koll på sista meddelandet som skickades till en chat.
            _lastMessages = new Dictionary<string, LastMessage>();

            // Skype
            _skype = new Skype();

            // Startar skype om det inte redan är startat.
            if (!_skype.Client.IsRunning)
            {
                _skype.Client.Start(false, false);
            }

            // Programmet ansluter till Skype. 
            // True betyder att den här raden blockerar exekveringen tills programet är godkänt i skype.
            _skype.Attach(8, true);

            // Användaren som kör botten.
            _botUsername = _skype.User.Handle;

            // Lyssnar på eventet att nya meddelanden har kommit.
            _skype.MessageStatus += HandleSkypeMessage;
        }

        /// <summary>
        /// Skickar meddelande till en person. Kan inte skicka till sig själv.
        /// </summary>
        /// <param name="user">username på den som ska få meddelandet</param>
        /// <param name="message">Meddelandet som ska skickas.</param>
        public void SendPrivateMessage(string user, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            if (IsLastMessage(user, message)) return;

            SetLastMessage(user, message);

            // Ignorerar ifall något failar
            try
            {
                _skype.SendMessage(user, message);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Skicka ett meddelande till en chat.
        /// </summary>
        /// <param name="chat">Chatens "namn". #markus.wase/$isilvara;bb37064f61d3a556</param>
        /// <param name="message">Meddelandet som ska skickas</param>
        public void SendChatMessage(string chat, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            if (IsLastMessage(chat, message)) return;

            SetLastMessage(chat, message);

            Chat c = GetSkypeChat(chat);

            if (c != null)
            {
                c.SendMessage(message);
            }
        }

        /// <summary>
        /// Sätter senaste meddelandet som skrevs till chat.
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="message"></param>
        private void SetLastMessage(string chat, string message)
        {
            if (string.IsNullOrWhiteSpace(chat) || string.IsNullOrWhiteSpace(message))
            {
                return;
            }
            _lastMessages[chat] = new LastMessage(message);
        }

        /// <summary>
        /// Kontrollerar ifall ett meddelande var det sista som skrevs eller inte
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool IsLastMessage(string chat, string message)
        {
            if (string.IsNullOrWhiteSpace(chat) || string.IsNullOrWhiteSpace(message))
            {
                return false;
            }

            LastMessage lastMessage = null;
            _lastMessages.TryGetValue(chat, out lastMessage);

            if (lastMessage != null)
            {
                return lastMessage.IsLastMessage(message);
            }
            return false;
        }

        /// <summary>
        /// Hämtar skype chat utifrån namn/id
        /// </summary>
        /// <param name="chatname">Namn/id</param>
        /// <returns>Chat</returns>
        private Chat GetSkypeChat(string chatname)
        {
            Chat chat = null;

            // Antar att det är ett korrekt chatnamn/id som skickats in.
            try
            {
                chat = _skype.get_Chat(chatname);
            }
            catch
            {
            }

            // Verkar som get_Chat hittar chatar som inte finns, därför görs kontrollen nedan.
            // Antar att man skapar en ny med det namnet som man först måste bjuda in en eller 
            // flera personer till innan man kan skicka ett meddelande.
            try
            {
                Console.WriteLine(chat.ActivityTimestamp);
            }
            catch
            {
                chat = null;
            }

            // Om det inte var det, så gör vi ett försök med namnet till exempel: Kakmix!
            if (chat == null)
            {
                foreach (Chat c in _skype.Chats)
                {
                    //Name = #markus.wase/$isilvara;bb37064f61d3a556
                    //FriendlyName = namn på enskildkonversation
                    //Topic = namn på flerpersonskonversation
                    if (c.Topic.Equals(chatname) || c.FriendlyName.Equals(chatname))
                    {
                        chat = c;
                        break;
                    }
                }
            }

            return chat;
        }

        /// <summary>
        /// Hämtar skype displayname. Hittas inget returneras användarnamnet.
        /// </summary>
        /// <param name="username">Användarnamn som man ska hämta displayname för.</param>
        /// <returns>Displayname i första hand. Användarnamn i andra hand.</returns>
        public string GetSkypeName(string username)
        {
            try
            {
                User u = _skype.get_User(username);

                if (!string.IsNullOrWhiteSpace(u.FullName))
                {
                    return u.FullName;
                }
            }
            catch
            {
            }

            return username;
        }

        /// <summary>
        /// Hanterar inkommande skype meddelande, kanske sätter kategori eller extra info
        /// Skapar event som den som lyssnar på kan se och göra sin uppfattning
        /// Flera saker kan få trigga på samma sak.
        /// </summary>
        /// <param name="pMessage">Meddelande och info om chat/användare</param>
        /// <param name="Status">Fick man ett meddelande eller skickade vi det?</param>
        private void HandleSkypeMessage(ChatMessage pMessage, TChatMessageStatus Status)
        {
            log.Info("Sender: " + pMessage.Sender.Handle + " Message: " + pMessage.Body + " Status: " + Status.ToString());

            // Fått meddelande från annan part
            if (TChatMessageStatus.cmsReceived == Status)
            {
                TriggerOnNewMessageEvent(pMessage);
            }
            // Boten eller botens användare har skickat ett meddelande
            else if (TChatMessageStatus.cmsSent == Status)
            {
                lock (_lastMessages)
                {
                    if (!IsLastMessage(pMessage.Chat.Name, pMessage.Body))
                    {
                        TriggerOnNewMessageEvent(pMessage);
                    }
                }
            }
        }

        /// <summary>
        /// Hjälp method för att slippa skriva samma kod två gånger
        /// </summary>
        /// <param name="cm">Info om meddelande, användare mm</param>
        private void TriggerOnNewMessageEvent(ChatMessage cm)
        {
            MessageEvent me = new MessageEvent();
            me.Sender = GetSkypeName(cm.Sender.Handle);
            me.Message = cm.Body;
            me.ChatCode = cm.Chat.Name;
            Console.WriteLine(me);
            OnNewMessage(me);
        }

        /// <summary>
        /// Returnerar en lista på aktiva chattar.
        /// Minimalt med info.
        /// </summary>
        /// <returns></returns>
        public List<ChatInfo> GetActiveChats()
        {
            List<ChatInfo> cList = new List<ChatInfo>();

            DateTime LastWeek = DateTime.Now.AddDays(-7);
            foreach (Chat c in _skype.Chats)
            {
                if (c.ActivityTimestamp > LastWeek)
                {
                    cList.Add(GetBasicChatInfo(c));
                }
            }

            return cList;
        }

        /// <summary>
        /// Hämtar mer info om en specific chat
        /// </summary>
        /// <param name="ChatCode"></param>
        /// <returns></returns>
        public ChatInfo GetChatInfo(string ChatCode)
        {
            Chat c = GetSkypeChat(ChatCode);
            ChatInfo ci = GetBasicChatInfo(c);

            List<UserInfo> uList = new List<UserInfo>();

            foreach (User u in c.Members)
            {
                UserInfo ui = new UserInfo();
                ui.DisplayName = !string.IsNullOrWhiteSpace(u.FullName) ? u.FullName : u.Handle;
                ui.Username = u.Handle;
                ui.StatusIcon = GetSkypeStatus(u.OnlineStatus);

                uList.Add(ui);
            }

            ci.UserList = uList;

            return ci;
        }

        /// <summary>
        /// Hämtar grundläggande info
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private ChatInfo GetBasicChatInfo(Chat c)
        {
            if (c == null) return new ChatInfo();

            ChatInfo ci = new ChatInfo();

            //Tittar ifall det är en enpersonskonversation
            if (string.IsNullOrWhiteSpace(c.Topic))
            {
                ci.ChatName = c.FriendlyName;

                TOnlineStatus status = TOnlineStatus.olsUnknown;
                foreach (User u in c.Members)
                {
                    if (!u.Handle.Equals(_botUsername))
                    {
                        status = u.OnlineStatus;
                        break;
                    }
                }

                ci.ChatStatusIcon = GetSkypeStatus(status);
            }
            //Annars en vanlig chat
            else
            {
                ci.ChatName = c.Topic;
                ci.ChatStatusIcon = "Chat";
            }

            ci.ChatCode = c.Name;

            ci.LastActive = c.ActivityTimestamp;

            return ci;
        }

        /// <summary>
        /// Översätter skype statusar
        /// </summary>
        /// <param name="status">SkypeStatus</param>
        /// <returns>Våran tolkning</returns>
        private string GetSkypeStatus(TOnlineStatus status)
        {
            if (TOnlineStatus.olsAway == status)
            {
                return "Away";
            }
            else if (TOnlineStatus.olsDoNotDisturb == status)
            {
                return "DND";
            }
            else if (TOnlineStatus.olsNotAvailable == status)
            {
                return "Invisible";
            }
            else if (TOnlineStatus.olsOffline == status)
            {
                return "Offline";
            }
            else if (TOnlineStatus.olsOnline == status)
            {
                return "Online";
            }

            return "Unknown";
        }
    }
}
