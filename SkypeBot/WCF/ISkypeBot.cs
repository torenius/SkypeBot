using SkypeBot.AutomaticReply;
using SkypeBot.PeriodicMessage;
using SkypeBot.SkypeStuff;
using System.ServiceModel;

namespace SkypeBot.WCF
{
    [ServiceContract]
    public interface ISkypeBot : ISkypeHandler, IPeriodicMessage, IAutomaticReply
    {
        // Testar att vi har en anslutning
        [OperationContract]
        string ping();
    }
}
