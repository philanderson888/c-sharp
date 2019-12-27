using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Certificate_01
{
    class Program
    {
        static void Main(string[] args)
        {


            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            var certificate = default(X509Certificate2);
            var certificateName = "CN=FourthCoffee";
            store.Open(OpenFlags.ReadOnly);
            foreach (var storeCertificate in store.Certificates)
            {
                Console.WriteLine(storeCertificate.FriendlyName);

                if (storeCertificate.SubjectName.Name == certificateName)
                {
                    certificate = storeCertificate;
                    continue;
                }
            }
            store.Close();
        }
    }
}
