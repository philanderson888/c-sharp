using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_01_toString
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = 123.456;
            Console.WriteLine(x.ToString("C2"));  // AS £ WITH 2 DP
            Console.ReadLine();
        }
    }
}
