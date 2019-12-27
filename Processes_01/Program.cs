using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Processes_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" == Listing all processes == ");
            Process[] Processes = Process.GetProcesses();
            foreach(Process p in Processes)
            {
                Console.WriteLine(p.Id);
                Console.WriteLine(p.MachineName);
                Console.WriteLine(p.ProcessName);
                Console.WriteLine();
            }
            Console.WriteLine("There are {0} processes running",Processes.Length);
            Console.WriteLine("==  Selecting just one process, in this case, Explorer == ");
            Process process01 = Process.GetProcessesByName("Explorer")[0]; /*get the desired process here*/;
            Console.WriteLine(process01.Id);
            Console.WriteLine(process01.MachineName);
            Console.WriteLine(process01.ProcessName);
            Console.WriteLine("==== ");
            Console.WriteLine("Is Notepad running ? Select by Name and obtain ID  ");
            Process[] notepad = Process.GetProcessesByName("Notepad");
            if (notepad.Length > 0)     // ie notepad is running
            {
                Console.WriteLine("notepad id is " + notepad[0].Id);
                Process ProcessGotById = Process.GetProcessById(notepad[0].Id);
                Console.WriteLine("process name is " + ProcessGotById.ProcessName);
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    }
}
