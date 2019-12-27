using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods_01
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass Instance01 = new MyClass();
            Instance01.Method01();
            // invalid ----- Extension Instance02 = new Extension();
            
            string s = "hi";
            s.Method03();

            var Instance02 = new MyClass();
            Instance02.num1 = 50;
            Instance02.Method04();
        }
    }

    sealed public class MyClass
    {
        public double num1;
        public void Method01 () { }
    }

    public static class Extension
    {
        public static void Method02() { }
        public static void Method03(this string s) {
            Console.WriteLine(s + s + s);
        }
        public static void Method04(this MyClass m) {
            Console.WriteLine(m.num1 * m.num1);
        }
    }
}
