// Code to illustrate creating a callback using a delegate

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_06
{
    class Program
    {


        public delegate void MyDelegate();

        static void Main(string[] args)
        {
            MyDelegate myDelegateInstance = Method01;
            myDelegateInstance += Method02;
            MyMethod(myDelegateInstance);
        }

        public static void MyMethod(MyDelegate callback)
        {
            System.Threading.Thread.Sleep(1000);
            callback();
        }

        public static void Method01() {
            Console.WriteLine("In Method01");
        }

        public static void Method02()
        {
            Console.WriteLine("In Method02");
        }



    }
}
