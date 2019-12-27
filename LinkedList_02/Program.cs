using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_02
{
    class Program
    {
        static void Main(string[] args)
        {


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

            Console.WriteLine();
            Console.WriteLine("Removing one item - middle item 'how'");
            linkedlist01.Remove("how");

            Console.WriteLine();
            Console.WriteLine($"Length of list - {linkedlist01.Count}");
            Console.WriteLine();
            foreach (string item in linkedlist01)
            {
                Console.WriteLine($"list item is {item}");
            }


        }
    }
}
