using MathServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostMathService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var serviceSelfHost = new ServiceHost(typeof(MathService)))
            {
                serviceSelfHost.AddServiceEndpoint(
                    typeof(IMathService),
                    new BasicHttpBinding(),
                    "http://localhost:4444/MathService");

                serviceSelfHost.AddServiceEndpoint(
                    typeof(IMathService),
                    new BasicHttpBinding(),
                    "http://localhost:5555/MathService");

                serviceSelfHost.Open();

                Console.WriteLine("Hosting uruchomiony");
                Console.WriteLine("MathService nasłuchuje żądań na adresach:");
                Console.WriteLine();

                foreach (var serviceEndpoint in serviceSelfHost.Description.Endpoints)
                {
                    Console.WriteLine($"Adres: {serviceEndpoint.Address} Wiązanie: {serviceEndpoint.Binding.Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Wciśnij dowolny klawisz, aby zakończyć pracę programu");
                Console.ReadKey();

                serviceSelfHost.Close();
            }
        }
    }
}
