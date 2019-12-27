using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // illustrates use of dynamic keyword
            dynamic x = 5;
            object y = 6;
            Console.WriteLine(x.GetType());
            Console.WriteLine(y.GetType());
            x = x + 2;
            // y = y + 2;  NOT PERMITTED AS Y IS OBJECT
            Console.WriteLine("final value of x is {0}",x);
        }
    }
}
