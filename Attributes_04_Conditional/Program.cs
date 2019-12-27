#define TRACE_ON
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Attributes_04_Conditional
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlyIfTraceIsSet.DoThisOnlyIfTraceIsSet();
            OnlyIfTraceIsSet.DoThisOnlyIfDebugISSet();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

    public class OnlyIfTraceIsSet
    {
        [Conditional("TRACE_ON")]
        public static void DoThisOnlyIfTraceIsSet() {
            Console.WriteLine("if you see this then trace is set");
        }

        [Conditional("DEBUG")]
        public static void DoThisOnlyIfDebugISSet()
        {
            Console.WriteLine("If you see this then DEBUG is set");
        }
    }
}
