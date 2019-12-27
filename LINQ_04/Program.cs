using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LINQ_04
{
    class Program
    {
        static void Main(string[] args)
        {

            Hashtable products = new Hashtable();
            products.Add("tent", 100);
            products.Add("rucksack", 70);
            products.Add("sleeping bag", 20);

            Console.WriteLine("Raw hashtable output");
            foreach(var product in products.Keys)
            {
                Console.WriteLine("Item is {0} which has price {1}", product , products[product]);
            }

            Console.WriteLine("================");
            Console.WriteLine("Using LINQ query");
            Console.WriteLine("List of items by price ascending");
            var productList01 =
                from string product in products.Keys
                orderby products[product] ascending
                select product;


            foreach (var item in productList01)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("================");
            Console.WriteLine("Using LINQ query");
            Console.WriteLine("List of prices by price ascending");

            var productList02 =
                from string product in products.Keys
                orderby products[product] ascending
                select products[product];

            foreach(var item in productList02)
            {
                Console.WriteLine(item);
            }






            Console.WriteLine("================");
            Console.WriteLine("Using LINQ query");
            Console.WriteLine("List of prices by price ascending which are also less than value 50");

            var productList03 =
                from string product in products.Keys
                where (int)products[product] < 50
                orderby products[product] ascending
                select products[product];


            foreach (var item in productList03)
            {
                Console.WriteLine(item);
            }








        }
    }
}
