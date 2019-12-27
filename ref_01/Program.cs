using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ref_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // ref keyword

            int i = 1;
            Console.WriteLine("The value of i before is {0}", i);
            Method01(ref i);
            Console.WriteLine("The value of i after is {0}",i);
        }

        static void Method01(ref int i)
        {
            i++;
        }
    }
}
