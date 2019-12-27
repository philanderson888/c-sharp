using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_05_GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {

            // Program to put items into groups then count how many items are in a group 

            List<Result> list01 = new List<Result>();

            list01.Add(new Result { product = "shoe", colour = "red" });
            list01.Add(new Result { product = "shoe", colour = "blue" });
            list01.Add(new Result { product = "shoe", colour = "green" });

            list01.Add(new Result { product = "ball", colour = "red" });
            list01.Add(new Result { product = "ball", colour = "blue" });
            list01.Add(new Result { product = "ball", colour = "green" });

            list01.Add(new Result { product = "top", colour = "red" });
            list01.Add(new Result { product = "top", colour = "blue" });
            list01.Add(new Result { product = "top", colour = "black" });

            list01.Add(new Result { product = "shirt", colour = "black" });
            list01.Add(new Result { product = "shirt", colour = "black" });
            list01.Add(new Result { product = "shirt", colour = "black" });

            var outputList = from item in list01
                             group item by item.colour into groups
                             select new { ColourGroup = groups.Key, Count = groups.Count() };

            foreach (var item in outputList)
            {
                Console.WriteLine($"{item.ColourGroup} has {item.Count} instances");
            }

            // output grouping by product : number of 
            var outputList2 = from item in list01
                              group item by item.product into groups
                              select new { ProductGroup = groups.Key, Count = groups.Count() };

            foreach (var item in outputList2)
            {
                Console.WriteLine($"{item.ProductGroup} has {item.Count}");
            }
        }
    }

    public class Result
    {
        public string product;
        public string colour;
    }
}
