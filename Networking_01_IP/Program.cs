using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;


namespace Networking_01_IP
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                var host = Dns.GetHostEntry(Dns.GetHostName());

                Console.WriteLine();
                Console.WriteLine("=================");
                Console.WriteLine("Host Name is ");
                Console.WriteLine(host);
                Console.WriteLine(host.HostName);

                Console.WriteLine();
                Console.WriteLine("=================");
                Console.WriteLine("IP addresses are");
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine();
                        Console.WriteLine("=================");
                        Console.WriteLine($"(ip.ToString(),20");



                    }
                }

                GetLocalIPv4(NetworkInterfaceType.Ethernet);


                GetLocalIPv4(NetworkInterfaceType.Wireless80211);



            }

            catch (Exception e)
            {

                throw new Exception("No network adapters with an IPv4 address in the system!");

            }


            void GetLocalIPv4(NetworkInterfaceType _type)
            {
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    Console.WriteLine();
                    string a = "==================";
                    Console.WriteLine($"{a,40}");
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(item.OperationalStatus);
                    Console.WriteLine(item.Description);
                    Console.WriteLine(item.GetIPProperties());
                    Console.WriteLine(item.GetIPStatistics());
                    Console.WriteLine(item.GetIPv4Statistics());
                    Console.WriteLine(item.GetPhysicalAddress());
                    Console.WriteLine(item.GetType());
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.NetworkInterfaceType);
                    Console.WriteLine(item.Speed);


                    if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                    {



                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                Console.WriteLine("IP Address is UP");
                                Console.WriteLine(ip.Address.ToString());

                                Console.WriteLine("Endpoint");
                                EndPoint ep = new IPEndPoint(ip.Address, 80);


                                Console.WriteLine(ep.ToString());
                            }
                        }
                    }
                }




            }





        }
    }
}
