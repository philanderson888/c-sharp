using System;
using System.Net;
using System.Net.Http;
using System.IO;

namespace API_2019_09_10_HTTP_GET
{
    class Program
    {
        static string url = "https://raw.githubusercontent.com/philanderson888/data/master/customers.json";
         
        static void Main(string[] args)
        {

            Console.WriteLine("\n\nWebClient\n\n");
             var webclient = new WebClient { Proxy = null };
            Console.WriteLine(webclient.DownloadString(url));
   
            Console.WriteLine("\n\nWeb Request\n\n");
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "Get";
            var webresponse = (HttpWebResponse)webrequest.GetResponse();
            Console.WriteLine(webresponse.Headers);

            Console.WriteLine("\n\nWebResponse As Stream\n\n");
            var webresponsestream = webresponse.GetResponseStream();
            using (var reader = new StreamReader(webresponsestream))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }


            Console.WriteLine("\n\nHttpClient\n");
            Console.WriteLine("This is the one to go for!\n\n");
            var httpclient = new HttpClient();
            Console.WriteLine(httpclient.GetStringAsync(url).Result);

                 


        }


        async static void HttpClientGetData01Async()
        {
            using (var httpclient = new HttpClient())
            {
                var content = await httpclient.GetStringAsync(url);

            }
        }
    }

    class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
