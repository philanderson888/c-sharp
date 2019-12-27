using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBy_03
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> list01 = new List<string>() { "bac", "abc", "cab" };

            var list02 = list01.OrderBy(p => p.Substring(0)).ToList();

            Console.WriteLine();
            Console.WriteLine("===unsorted===");
            Console.WriteLine();

            foreach (string item in list01)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            Console.WriteLine("===sorted===");
            Console.WriteLine();


            foreach (string item in list02)
            {
                Console.WriteLine(item);
            }

        }
    }
}
