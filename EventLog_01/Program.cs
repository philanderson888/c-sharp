using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EventLog_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sSource = "x";
            //string sLog = "Application";

            //if (!EventLog.SourceExists(sSource))
            //    EventLog.CreateEventSource(sSource, sLog);


            // Write to Event Log
            EventLog.WriteEntry("Application", "Message from Phil", EventLogEntryType.Information, 5001, 1234);


            EventLog eventLog01 = new EventLog();            // Event Log
            eventLog01.Log = "Application";
            var eventLogArray = eventLog01.Entries;          // Array of entries in Log
            Console.WriteLine("Events in log {0:0000.0000}",eventLogArray.Count);

            var count = 1;
            foreach (EventLogEntry entry in eventLog01.Entries)
            {
             if (entry.Source == "Application" && entry.CategoryNumber == 123)
                {
                    Console.WriteLine(entry.Source);
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
                    if (count > 3) break;
                }

            }




            // log as array


            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("=======================");
                Console.WriteLine(eventLogArray[i].Message);
            }










        }
    }
}
