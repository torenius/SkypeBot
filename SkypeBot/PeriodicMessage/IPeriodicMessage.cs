using System.Collections.Generic;
using System.ServiceModel;

namespace SkypeBot.PeriodicMessage
{
    [ServiceContract]
    public interface IPeriodicMessage
    {
        [OperationContract]
        List<PeriodicMessageSetting> GetAllPeriodicMessages();

        [OperationContract]
        PeriodicMessageSetting InsertUpdatePeriodMessage(PeriodicMessageSetting pms);

        [OperationContract]
        bool DeletePeriodicMessage(PeriodicMessageSetting pms);
    }
}
