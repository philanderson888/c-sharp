using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace Debugger_Display_01
{
    class Program
    {
        static void Main(string[] args)
        {



            var instance01 = new x();
            instance01.i = 5;
            instance01.i = 6;
            instance01.i = 7;

            int x = 0;
            while (x < 10)
            {
                x++;
                x++;
                x++;
                var thislineissettohitcount = "breakpoint only counted";
                thislineissettohitcount += " when reaches 2";
            }


        }

    }

    [DebuggerDisplay("Class x Instance : Integer i = {i}")]
    class x
    {
        public int i;
    }





}
