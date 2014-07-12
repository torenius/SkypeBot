using System;
using System.Collections.Generic;

namespace SkypeBot.SkypeStuff
{
    public class ChatInfo
    {
        public ChatInfo()
        {
            UserList = new List<UserInfo>();
        }

        public string ChatName { get; set; }

        public string ChatCode { get; set; }

        public string ChatStatusIcon { get; set; }

        public DateTime LastActive { get; set; }

        public List<UserInfo> UserList { get; set; }
    }
}
