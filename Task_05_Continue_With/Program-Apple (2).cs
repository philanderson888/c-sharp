using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05_Continue_With
{
    class Program
    {
        static void Main(string[] args)
        {

            Task.Run(() =>
            {
                Console.WriteLine("Running first part of task");
            });

            Task<int>.Factory.StartNew(() =>
            {
                Console.WriteLine("In Task Factory at start ");
                return 5;
            }).ContinueWith((antecedent) => {
                Console.WriteLine("In Task Factory 6 ");
                Console.WriteLine("antecedent is {0}", antecedent.Result);
                return 6;
            }).ContinueWith((antecedent) => {
                Console.WriteLine("In Task Factory 7 ");
                return 7;
            }).ContinueWith((antecedent) => {
                Console.WriteLine("In Task Factory 8 ");
                return 8;
            }).ContinueWith((antecedent) => {
                Console.WriteLine("In Task Factory 9 ");
                return 9;
            });

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("moving on to an ordered set of tasks");

            Task<string> task1 = new Task<string>( () => { return "hi"; }  );


            Task<string> task2 = task1.ContinueWith( input => {
                Console.WriteLine(input.Result);
                return "there";
            });
            Task<string> task3 = task2.ContinueWith(input => {
                Console.WriteLine(input.Result);
                return "now";
            });


            task1.Start();

            Console.WriteLine(task3.Result);

            Console.ReadLine();
        }
    }
}
