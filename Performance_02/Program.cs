using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Performance_02
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("== Performance Counter Output ==");
            PerformanceCounter PC = new PerformanceCounter();
            PC.CategoryName = "Process";
            PC.InstanceName = "Explorer";
            PC.CounterName = "Private Bytes";
            Console.WriteLine(PC.NextValue().ToString("0"));

            // Category => Instance => Counter

            Console.WriteLine("== Performance Counter Categories ==");
            var performanceCounterCategories = PerformanceCounterCategory.GetCategories();
            foreach (PerformanceCounterCategory category in performanceCounterCategories)
            {
                Console.WriteLine();
                Console.WriteLine("Performance Category : {0}", category.CategoryName);

                var instanceNames = category.GetInstanceNames();
                var loopCounter01 = 0;
                foreach (var instance in instanceNames)
                {
                    Console.WriteLine("     Instance : {0}", instance);
                    var counters = category.GetCounters(instance);
                    loopCounter01++;
                    if (loopCounter01 > 1) break;
                    var loopCounter02 = 0;
                    foreach (var counterItem in counters)
                    {
                        Console.WriteLine("          Counter Name : {0}", counterItem.CounterName);
                        loopCounter02++;
                        if (loopCounter02 > 5) break;
                    }
                }
            }



            Console.WriteLine("== Read-only (Non-Custom) Performance Counter ==");
            PerformanceCounter p = new PerformanceCounter();
            Console.WriteLine(p.CategoryName);
            Console.WriteLine(p.CounterName);
            Console.WriteLine(p.InstanceName);
            Console.WriteLine(p.MachineName);
            Console.WriteLine(p.GetHashCode());
            Console.WriteLine(p.GetType());
            Console.WriteLine(p.ToString());


            Console.WriteLine("==  Read-Only (Non-Custom) Performance Counter 2 ==");
            PerformanceCounter q = new PerformanceCounter();
            q.CategoryName = "Process";
            q.CounterName = "Private Bytes";
            q.InstanceName = "Explorer";
            q.MachineName = "LocalHost";
            Console.WriteLine(q.CategoryName);
            Console.WriteLine(q.CounterName);
            Console.WriteLine(q.InstanceName);
            Console.WriteLine(q.MachineName);
            Console.WriteLine(q.GetHashCode());
            Console.WriteLine(q.GetType());
            Console.WriteLine(q.ToString());



            Console.WriteLine("==selecting one process==");
            Process process01 = Process.GetProcessesByName("Explorer")[0]; /*get the desired process here*/;
            Console.WriteLine("==create performance counters based on this process==");
            PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", process01.ProcessName);
            PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", process01.ProcessName);
            int counter = 0;
            string accumulator = "";
            while (counter < 100)
            {
                Thread.Sleep(50);
                double ram = ramCounter.NextValue();
                double cpu = cpuCounter.NextValue();
                counter++;
                accumulator += "somemoredatatoaddon";
                Console.WriteLine("RAM: " + (ram / 1024 / 1024) + " MB; CPU: " + cpu + " %");
            }




        }
    }
}

