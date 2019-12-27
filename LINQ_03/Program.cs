using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LINQ_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable priceList = new Hashtable();
            priceList.Add("tent", 100);
            priceList.Add("sleeping bag", 15);
            priceList.Add("rucksack", 70);

            Console.WriteLine("List of items");
            var items =
                from string item in priceList.Keys
                select item;

            foreach (string productName in items)
            {
                Console.WriteLine(productName);
            }

            Console.WriteLine("List of prices");
            var prices =
                from string product in priceList.Keys
                select priceList[product];

            foreach(var price in prices)
            {
                Console.WriteLine(price);
            }

        }
    }
}
