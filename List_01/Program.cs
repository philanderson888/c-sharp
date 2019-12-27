using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>();

            myList.Add("first");
            myList.Add("second");
            myList.Add("third");
            myList.Add("first");

            foreach(var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Removing one item");
            myList.Remove("first");

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
