using HostIndependentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //one per service class
            ServiceHost host = new ServiceHost(typeof(EmployeeService));
            host.Open();

            Console.WriteLine("Serviuce started");
            Console.Read();

            host.Close();
        }
    }
}
