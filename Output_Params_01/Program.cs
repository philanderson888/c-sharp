using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_Params_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 100;
            int output = 0;
            Console.WriteLine("output is {0}", output);
            Method01(input, out output);
            Console.WriteLine("output is {0}", output);

            //() => Console.WriteLine("output of lambda");
        }


        static void Method01(int a, out int b)
        {
            b = a * a;
        }
    }
}
