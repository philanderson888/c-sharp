using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;

namespace LINQ_01
{
    class Program
    {
        static void Main(string[] args)
        {


            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = { 0, 1, -2, 3, 20, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // note that the query is DEFERRED ie NOT RUN YET, SO I CAN AMEND THE ARRAY HERE!
            Console.WriteLine("note that the query is DEFERRED ie NOT RUN YET, SO I CAN AMEND THE ARRAY HERE!");
            numbers[0] = 100;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.WriteLine("{0,1} ", num);
            }

            Console.WriteLine();
            Console.WriteLine("First or default");
            Console.WriteLine(numQuery.FirstOrDefault<int>());


            Console.WriteLine("Last");
            Console.WriteLine(numQuery.Last<int>());


            Console.WriteLine("Max");
            Console.WriteLine(numQuery.Max<int>());


            Console.WriteLine("Min");
            Console.WriteLine(numQuery.Min<int>());







        }

    }
}
