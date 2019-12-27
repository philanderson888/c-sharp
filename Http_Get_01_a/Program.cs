using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace Http_Get_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Uri bbc01 = new Uri("http://www.bbc.co.uk");
            Uri bbc02 = new Uri("https://www.bbc.co.uk/sport/golf/45408328");
            Console.WriteLine(bbc02.Host);
            Console.WriteLine(bbc02.Port);

            Uri notepad = new Uri("https://notepad-plus-plus.org/repository/7.x/7.5.8/npp.7.5.8.Installer.x64.exe");
            WebClient downloadNotepad = new WebClient { Proxy = null };
            downloadNotepad.DownloadFile(notepad, "npp.7.5.8.Installer.x64.exe");

            //Console.WriteLine("This will fail as requires elevation");
            //var startInfo = new ProcessStartInfo("npp.7.5.8.Installer.x64.exe");
            //startInfo.Verb = "runas";
            //Process.Start(startInfo);

            Uri htmWebPage01 = new Uri("https://tcserver.docs.pivotal.io/4x/docs-tcserver/topics/about-tc-server.html");
            var getHtmlWebPage01 = new WebClient { Proxy = null };
            getHtmlWebPage01.DownloadFile(htmWebPage01, "about-tc-server.html");

            Console.WriteLine(File.ReadAllText("about-tc-server.html"));

            Uri getWebPage02 = new Uri("http://www.albahari.com/nutshell/code.html");

        }



    }
}

