using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Http_Server_01
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUpServerAsync();
            var webClient01 = new WebClient();
            Console.WriteLine(webClient01.DownloadString("http://localhost:51111/MyApp/Request01.txt"));
        }

        async static void SetUpServerAsync()
        {
            var HttpServer01 = new HttpListener();
            HttpServer01.Prefixes.Add("http://localhost:51111/MyApp/");
            HttpServer01.Start();
        
            HttpListenerContext request01 = await HttpServer01.GetContextAsync();

            string messageResponse = "You asked for " + request01.Request.RawUrl;
            using (Stream stream01 = request01.Response.OutputStream)
            {
                using (var writer01 = new StreamWriter(stream01))
                {
                    await writer01.WriteAsync(messageResponse);
                }
            }


        }
    }
}
