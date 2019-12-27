using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Method01(1, "hi", false);
            Method01(1, "hi");
            Method01(c: false, a: 22, b: "hello");   // MIX ORDER
            Method01(44, c: true, b: "string01");
        }

        static void Method01(int a, string b, bool c = true)
        {

        }
    }
}
