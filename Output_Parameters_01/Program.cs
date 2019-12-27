using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_Parameters_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int output;

            Method01(10, out output);

            Console.WriteLine("output is {0}", output);
        }

        static void Method01(int a, out int b)
        {
            b = a * a;
            
        }
    }
}
