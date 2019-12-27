using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Hashtable_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable h = new Hashtable();

            h.Add("fred", "drinks slowly");
            h.Add("jerry", "does not drink unless really thirsty");
            h.Add("tom", "loves only milk");
            h.Add(1, "numerical entry");

            foreach( object key in h.Keys )   // note : Hashtable key can be any data type
            {
                Console.WriteLine(key);
                Console.WriteLine(h[key]);
                Console.WriteLine("==");
            }

        }
    }
}
