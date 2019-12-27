using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor_01
{
    class Program
    {
        static void Main(string[] args)
        {


            Third t = new Third();


            /* Run with F5 then check Output Window
             *  Third's destructor is called.
                Second's destructor is called.
                First's destructor is called.
            */
        }

    }


    class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("First's destructor is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("Second's destructor is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("Third's destructor is called.");
        }
    }




}
