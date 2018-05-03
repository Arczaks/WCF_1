using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Discovery;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //z IsCompleted
            var client = new ServiceReference1.EngineClient();
            IAsyncResult res = client.Beginstart(null, null);
            while (!res.IsCompleted) ;
            string wynik = client.Endstart(res);
            Console.WriteLine("1");
            Console.WriteLine(wynik);
            client.Close();

            //z AsyncWaitHandle.WaitOne
            var client2 = new ServiceReference1.EngineClient();
            IAsyncResult res2 = client2.Beginstart(null, null);
            res2.AsyncWaitHandle.WaitOne();
            string wynik2 = client2.Endstart(res2);
            Console.WriteLine("2");
            Console.WriteLine(wynik2);
            client2.Close();
        }
    }
}
