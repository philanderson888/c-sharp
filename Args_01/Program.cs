using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Args_01
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (string item in args)
            {
                Console.WriteLine("Your arguments were");
                Console.WriteLine(item);
            }

        }
    }
}
