using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Task_01
{
    class Program
    {

        static void Main(string[] args)
        {
            var task1 = new Task(() => {
                Console.WriteLine("task 1 is running");
                Trace.WriteLine("task 1 is running");
            });
            task1.Start();


            var task2 = Task.Factory.StartNew( () => {
                Console.WriteLine("task 2 is running");
                Trace.WriteLine("task 2 is running");
                });


            var task3 = Task.Run(  () => {
                Console.WriteLine("task 3 is running");
                Trace.WriteLine("task 3 is running");

            });




            //Task with Action Delegate
            Console.WriteLine("=============================");
            Console.WriteLine("--------Action Delegate--------");
            Console.WriteLine("--First create task accepting Action delegate with one method as parameter");
            var task04 = new Task(new Action(myMethod));
            Console.WriteLine("--Now start the task--");
            task04.Start();



            var task05 = new Task(delegate { Console.WriteLine("Task05 is running");  });
            task05.Start();

            var task08 = Task.Run(delegate { Console.WriteLine("Task08 is running"); });

            var task06 = new Task( ()=> { }  );


            Action myAction01 = myMethod01;
            var task07 = new Task(myAction01);
            task07.Start();

            Console.Read();

        }


    static void myMethod01()
    {
        // do something here : perform some ACTION BUT DON'T RETURN ANYTHING!
        Console.WriteLine("Notice I am doing something here as an action");
        Console.WriteLine("But also returning nothing as well");
        // notice this returns void
    }


    static void myMethod()
        {
            Console.WriteLine("Task is now running via Action Delegate using one method");
            Console.WriteLine("Working now in myMethod");
        }
    }
}
