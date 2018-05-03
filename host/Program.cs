using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Discovery;

namespace host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(WcfService1.Service1));

            host.AddServiceEndpoint(typeof(WcfService1.IEngine),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/EnginePotok");

            host.AddServiceEndpoint(typeof(WcfService1.IEngine),
                new NetTcpBinding(),
                "net.tcp://127.0.0.1:8001/Enginetcp");

            //var b = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            //if (b == null) b = new ServiceMetadataBehavior();
            //host.Description.Behaviors.Add(b);
            //host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
            //    MetadataExchangeBindings.CreateMexNamedPipeBinding(),
            //    "net.pipe://localhost/metadane");

            host.Open();
            Console.ReadKey();
            host.Close();

        }
    }
}
