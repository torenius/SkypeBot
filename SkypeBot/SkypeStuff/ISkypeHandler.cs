using System.Collections.Generic;
using System.ServiceModel;

namespace SkypeBot.SkypeStuff
{
    [ServiceContract]
    public interface ISkypeHandler
    {
        [OperationContract]
        List<ChatInfo> GetActiveChats();

        [OperationContract]
        ChatInfo GetChatInfo(string ChatCode);
    }
}
