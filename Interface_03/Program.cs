using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var object01 = new class01();
            object01.X = 5;
            Console.WriteLine(object01.X); 
        }
    }

    interface IInterface1
    {
        // no fields allowed
        // property is PUBLIC even though PUBLIC KEYWORD IS MISSING, SO IT IS AUTOMATICALLY IMPLIED!
        int X { get; set; }
    }

    class class01 : IInterface1
    {
        private int x;
        public int X { get { return x; } set { x = value; } }
    }
}
