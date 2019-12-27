using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_02
{
    class Program
    {

        public delegate void myDelegate(int x);

        static void Main(string[] args)
        {

            myDelegate myHandler = myMethod01; // myHandler will be array of methods which can fire when event fires
            myHandler += myMethod02;
            myHandler(10); // now actually fire the event            

            // Longhand
            myDelegate myHandler2 = new myDelegate(myMethod01);
        }

        public static void myMethod01(int x)
        {
            Console.WriteLine("Method01 is firing");
            Console.WriteLine(x * x);
        }

        public static void myMethod02(int x)
        {
            Console.WriteLine("Method02 is firing");
            Console.WriteLine(x * x * x);
        }

    }
}
