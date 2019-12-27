using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<string>();

            var node = list.AddLast("First");

            Console.WriteLine("First item in list is {0}",list.First.Value);
            Console.WriteLine("Last item in list is {0}", list.Last.Value);

            Console.WriteLine("");
            Console.WriteLine("");

            list.AddLast("Second");

            Console.WriteLine("First item in list is {0}", list.First.Value);
            Console.WriteLine("Last item in list is {0}", list.Last.Value);

            Console.WriteLine("");
            Console.WriteLine("");


            list.AddAfter(node,"Middle");

            Console.WriteLine("First item in list is {0}", list.First.Value);
            Console.WriteLine("Last item in list is {0}", list.Last.Value);

            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var item in list)
            {
                Console.WriteLine("Item in list is {0}", item);
            }


            Console.WriteLine("");
            Console.WriteLine("");






            LinkedList<string> linkedlist01 = new LinkedList<string>();

            linkedlist01.AddFirst("hi");
            linkedlist01.AddFirst("there");
            linkedlist01.AddFirst("how");
            linkedlist01.AddFirst("are");
            linkedlist01.AddFirst("you");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==linked list");
            Console.WriteLine();
            Console.WriteLine($"Length of list - {linkedlist01.Count}");
            Console.WriteLine();
            foreach (string item in linkedlist01)
            {
                Console.WriteLine($"list item is {item}");
            }

            linkedlist01.Remove("how");

            Console.WriteLine();
            Console.WriteLine($"Length of list - {linkedlist01.Count}");
            Console.WriteLine();
            foreach (string item in linkedlist01)
            {
                Console.WriteLine($"list item is {item}");
            }



            Console.ReadLine();

        }
    }
}



