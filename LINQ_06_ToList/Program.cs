using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_06_ToList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array
            string[] fruits = { "apple", "passionfruit", "banana", "mango",
                      "orange", "blueberry", "grape", "strawberry" };



            // foreach without lambda
            foreach(string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }



            //foreach with lambda (convert to list<> first)
            fruits.ToList<string>().ForEach(fruit => Console.WriteLine(fruit));



            //foreach with LINQ and lambda
            var fruitSelection =
                (from fruit in fruits
                 where fruit.Length > 5
                 select fruit).ToList();

            fruitSelection.ForEach(fruit=>Console.WriteLine(fruit));

        }
    }
}
