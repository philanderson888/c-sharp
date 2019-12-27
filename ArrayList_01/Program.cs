using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayList_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList x = new ArrayList();

            x.Add("hi");
            x.Add(2);
            x.Add(new Array[1]);
            Console.WriteLine("==");
            foreach (object o in x)
            {
                Console.WriteLine(o);
                Console.WriteLine(o.GetType());
                Console.WriteLine("==");
            }


           
        }
    }
}
