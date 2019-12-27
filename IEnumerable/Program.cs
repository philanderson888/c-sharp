using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {

            // arrays are enumerable
            string[] names = { "Bob", "Emily", "Peter", "Mike" };
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("=======================");
            System.Collections.IEnumerator enumerator = names.GetEnumerator();
            Console.WriteLine(enumerator.MoveNext());
            Console.WriteLine(enumerator.Current);
            Console.WriteLine(enumerator.MoveNext());
            Console.WriteLine(enumerator.Current);
            Console.WriteLine(enumerator.MoveNext());
            Console.WriteLine(enumerator.Current);
            Console.WriteLine(enumerator.MoveNext());
            Console.WriteLine(enumerator.Current);
            Console.WriteLine("=======================");
            Console.WriteLine("End of array reached so MoveNext() now returns false");
            Console.WriteLine(enumerator.MoveNext());


        }
    }
}
