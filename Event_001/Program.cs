using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_001
{
    class Program
    {
        public delegate void myDelegate(); // trivial case
        public static event myDelegate myEvent;  // declare the event

        static void Main(string[] args)
        {
            myEvent += MyMethod01;  // subscribe to event
            myEvent();   // call the event !!
        }

        static void MyMethod01() {
            Console.WriteLine("In MyMethod01");
        }

    }
}
