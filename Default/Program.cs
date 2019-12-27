using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default
{
    class Program
    {
        static void Main(string[] args)
        {
            // string default is null
            string x = default;
            // int default is 0
            int y = default;

            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
