using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace Http_Get_03_Async_With_Progress
{
    class Program
    {
        static void Main(string[] args)
        {
            GetWebPage();
            Console.ReadLine();
        }

        async static void GetWebPage()
        {
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadProgressChanged += (sender, args) =>
            {
                Console.WriteLine(args.ProgressPercentage + "% complete");
            };
            await Task.Delay(5000).ContinueWith(ant => webClient.CancelAsync());
            await webClient.DownloadFileTaskAsync("http://www.albahari.com/nutshell/code.html", "myPage.html");
            Process.Start("myPage.html");
        }
    }
}
