using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();
            Console.WriteLine(p.Location);
            // invalid ==>   p.Location += "";
        }
    }

    class Person { 

        public readonly string Location;
    
        public Person()
        {
            Location = DateTime.Today.ToString("ddd,d MMMM yyyy");
        }
    }
}
