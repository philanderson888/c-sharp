using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EventLog_03
{
    class Program
    {
        static void Main(string[] args)
        {

            var systemEventLog = new EventLog();
            systemEventLog.Log = "System";
            systemEventLog.MachineName = ".";  // Local machine
            Console.WriteLine("There are  " + systemEventLog.Entries.Count + " entries in the System event log.");

            int count = 0;

            foreach(EventLogEntry logentry in systemEventLog.Entries)
            {
                Console.WriteLine("Category is " + logentry.Category);
                Console.WriteLine("CategoryNumber is " + logentry.CategoryNumber);
                Console.WriteLine("Data is " + logentry.Data);
                Console.WriteLine("Entry Type is " + logentry.EntryType);
                Console.WriteLine("GetType is " + logentry.GetType());
                Console.WriteLine("Index is " + logentry.Index);
                Console.WriteLine("Machine Name is " + logentry.MachineName);
                Console.WriteLine("Message is " + logentry.Message);
                Console.WriteLine("Source is " + logentry.Source);
                Console.WriteLine("Time Generated is " + logentry.TimeGenerated);
                Console.WriteLine("Time Written is " + logentry.TimeWritten);
                Console.WriteLine("User Name is " + logentry.UserName);
                Console.WriteLine();
                Console.WriteLine();
                count++;
                if (count > 10) break;
            }


        }
    }
}
