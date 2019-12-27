using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue<string>();

            q.Enqueue("first");
            q.Enqueue("second");
            q.Enqueue("third");
            q.Enqueue("fourth");
            q.Enqueue("fifth");
            q.Enqueue("sixth");

            Console.WriteLine("Printing Out Original Queue");
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");
            Console.WriteLine("");

            string nextPerson = q.Dequeue();
            Console.WriteLine("Processing next person who is {0}", nextPerson);

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Printing Out Amended Queue");
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
