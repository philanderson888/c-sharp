using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Debug_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hi");
            var d = DateTime.Now;
            // only visible in Build=>Configuration Manager=>Debug mode
            Debug.WriteLine("debug write line " + d.ToString());
            Trace.WriteLine("trace write line " + d.ToString());
            Console.ReadLine();
        }
    }
}
