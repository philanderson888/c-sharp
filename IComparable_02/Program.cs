using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparable_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Item();
            var b = new Item();
            a.lastName = "Jones";
            b.lastName = "Sawyer";
            Console.WriteLine("{0} compareTo {1} is {2}",a.lastName,b.lastName,a.CompareTo(b));
            a.lastName = "Sawyer";
            b.lastName = "Sawyer";
            Console.WriteLine("{0} compareTo {1} is {2}", a.lastName, b.lastName, a.CompareTo(b));
            a.lastName = "Teller";
            b.lastName = "Sawyer";
            Console.WriteLine("{0} compareTo {1} is {2}", a.lastName, b.lastName, a.CompareTo(b));
        }
    }

    class Item : IComparable
    {
        public string firstName;
        public string lastName;

        public int CompareTo(object o)
        {
            Item i = o as Item;
            return this.lastName.CompareTo(i.lastName);
        }
    }
}
