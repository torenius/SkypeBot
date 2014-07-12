using Server.WCF;
using SkypeBot.WCF;
using System;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost _host = new ServiceHost(
                typeof(SkypeBotServer), 
                new Uri[] 
                { 
                    new Uri("net.tcp://localhost:14445") 
                })
            )
            {
                _host.AddServiceEndpoint(typeof(ISkypeBot), new NetTcpBinding(SecurityMode.None), "SkypeBot");
                _host.Open();
                Console.WriteLine("Server is up...");
                Console.ReadLine();
                _host.Close();
            }            
        }
    }
}
