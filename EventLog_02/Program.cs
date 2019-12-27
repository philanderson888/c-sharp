using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EventLog_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLog01 = new EventLog();

            eventLog01.Log = "Application";
            Console.WriteLine(eventLog01.Log);
            Console.WriteLine(eventLog01.Entries.Count + " entries in Application Event Log");
            int count = 0;
            foreach (EventLogEntry entry in eventLog01.Entries)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("========================");
                Console.WriteLine("Category is " + entry.Category);
                Console.WriteLine("CategoryNumber is " + entry.CategoryNumber);
                Console.WriteLine("Data is " + entry.Data);
                Console.WriteLine("Entry Type is " + entry.EntryType);
                Console.WriteLine("GetType is " + entry.GetType());
                Console.WriteLine("Index is " + entry.Index);
                Console.WriteLine("Machine Name is " + entry.MachineName);
                Console.WriteLine("Message is " + entry.Message);
                Console.WriteLine("Source is " + entry.Source);
                Console.WriteLine("Time Generated is " + entry.TimeGenerated);
                Console.WriteLine("Time Written is " + entry.TimeWritten);
                Console.WriteLine("User Name is " + entry.UserName);
                count++;
                if (count > 5) break;

            }

        }
    }
}
