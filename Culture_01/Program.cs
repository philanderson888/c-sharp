using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Culture_01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal price = 23.99M;
            DateTime dob = new DateTime(1972, 12, 25);
            var t = Thread.CurrentThread;

            Console.WriteLine("CurrentUICulture is " + t.CurrentUICulture);
            Console.WriteLine("CurrentCulture is " + t.CurrentCulture);
            Console.WriteLine("");


            Console.WriteLine("Price is {0:C}", price);
            Console.WriteLine("DOB is {0}", dob.ToLongDateString());


            Console.WriteLine("");
            Console.WriteLine("");


            t.CurrentCulture = new System.Globalization.CultureInfo("fr-CA");

            Console.WriteLine("CurrentUICulture is " + t.CurrentUICulture);
            Console.WriteLine("CurrentCulture is " + t.CurrentCulture);
            Console.WriteLine("");

            Console.WriteLine("Price is {0:C}", price);
            Console.WriteLine("DOB is {0}", dob.ToLongDateString());

            Console.WriteLine("");
            Console.WriteLine("");


            t.CurrentCulture = new System.Globalization.CultureInfo("fr");

            Console.WriteLine("CurrentUICulture is " + t.CurrentUICulture);
            Console.WriteLine("CurrentCulture is " + t.CurrentCulture);
            Console.WriteLine("");

            Console.WriteLine("Price is {0:C}", price);
            Console.WriteLine("DOB is {0}", dob.ToLongDateString());



            Console.ReadLine();
        }
    }
}
