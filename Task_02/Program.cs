using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {

            // Task wait

            var task01 = Task.Run(()=> {
                Console.WriteLine("task01 running");
                System.Threading.Thread.Sleep(2000);
                });
            Console.WriteLine("doing some other work");
            Console.WriteLine("now waiting for task01 to complete");
            task01.Wait();
            Console.WriteLine("task01 has completed so continuing program");

            
            Console.WriteLine("==========================");
            Console.WriteLine("------Wait Any--------");
            // Wait Any and Wait All
            // Create an array of tasks (here just 2 items)
            Task[] tasks = new Task[2];
            tasks[0] = Task.Run(() => {
                System.Threading.Thread.Sleep(1000);
            });
            tasks[1] = Task.Run(() => {
                System.Threading.Thread.Sleep(5000);
            });

            Console.WriteLine("Tasks[0] and Tasks[1] have both begun");

            Task.WaitAny(tasks);

            Console.WriteLine("first one done");

            Console.WriteLine("==========================");
            Console.WriteLine("------Wait All ---------");
            Task.WaitAll(tasks);

            Console.WriteLine("Finished all tasks - done");

            // task result
            Console.WriteLine("==========================");
            Console.WriteLine("---Task<T> always returns a result of type <T>--");


            var task02 = Task<string>.Run(() => {
                return "joe";
            });
            Console.WriteLine(task02.Result);




        }
    }
}
