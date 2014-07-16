using System.Collections.Generic;
using System.ServiceModel;

namespace SkypeBot.AutomaticReply
{
    [ServiceContract]
    public interface IAutomaticReply
    {
        [OperationContract]
        List<AutomaticReplySetting> GetAllAutomaticReply();

        [OperationContract]
        string GetInfoList();

        [OperationContract]
        AutomaticReplySetting InsertUpdateAutomaticReply(AutomaticReplySetting ars);

        [OperationContract]
        bool DeleteAutomaticReply(AutomaticReplySetting ars);
    }
}
