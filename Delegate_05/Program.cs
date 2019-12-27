using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_05
{
    class Program
    {
        public delegate void MyDelegate();

        static void Main(string[] args)
        {
            MyDelegate delegateInstance01 = MyMethod01;
            delegateInstance01 += MyMethod02;
            delegateInstance01();
        
        }

        static void MyMethod01()
        {
            Console.WriteLine("In MyMethod01");
        }

        static void MyMethod02()
        {
            Console.WriteLine("In MyMethod02");
        }

    }
}
