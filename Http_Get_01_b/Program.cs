using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace Http_Get_01_b
{
    class Program
    {
        static void Main(string[] args)
        {

            // Download and display a web page
            // Synchronous version
            var webClient01 = new WebClient { Proxy = null };
            webClient01.DownloadFile("http://www.albahari.com/nutshell/code.html", "myWebPage01.html");
            Console.WriteLine("Main thread is hanging while web page loads");
            Process.Start("myWebPage01.html");
            Console.ReadLine();

            // Asynchronous version
            Console.WriteLine("Now getting page asynchronously");
            GetWebPage01();
            Console.WriteLine("Notice main thread is not hanging");
            Console.WriteLine("Notice main thread is not hanging");
            Console.WriteLine("Notice main thread is not hanging");
            Console.WriteLine("Notice main thread is not hanging");
            Console.WriteLine("Notice main thread is not hanging");
            Console.WriteLine("Notice main thread is not hanging");
            Console.ReadLine();


        }

        async static void GetWebPage01()
        {
            var webClient02 = new WebClient { Proxy = null };
            await webClient02.DownloadFileTaskAsync("http://www.albahari.com/nutshell/code.html", "myWebPage02.html");
            Process.Start("myWebPage02.html");
        }
    }
}
