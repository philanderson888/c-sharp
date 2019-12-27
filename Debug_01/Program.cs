using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Debug_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Writing text from Debug.WriteLine");
            Debug.Indent();
            Debug.WriteLine("Text Is Indented From Now On");

            Debug.WriteLineIf(true, "This message WILL appear");
        
            Debug.WriteLineIf(false, "This message will NOT appear");

            Debug.Assert(true, "Writing text from Debug.Assert when true");

            Debug.Assert(false, "This assert will fail and cause an alert to appear");


            // Debug to console window

            TextWriterTraceListener tr = new TextWriterTraceListener(Console.Out);
            Debug.Listeners.Add(tr);
            Debug.WriteLine("Now writing to console also");
     

            // Debug to text file
            TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("Output.txt"));
            Debug.Listeners.Add(tr2);

            
            Debug.WriteLine("Now also writing to text file also!!!");
            Debug.WriteLine("Second line of output to text file also");
            Debug.Flush();



            TextWriterTraceListener[] listeners = new TextWriterTraceListener[] {
                new TextWriterTraceListener("debug.txt"),
                new TextWriterTraceListener(Console.Out)
            };

            Debug.Listeners.AddRange(listeners);

            Debug.WriteLine("Some Value", "Some Category");
            Debug.WriteLine("Some Other Value");
            Debug.Flush();


            // Trace goes to OUTPUT WINDOW REGARDLESS OF DEBUG MODE

            Trace.WriteLine("Trace output");
            Trace.Indent();
            Trace.WriteLine("indented");
            Trace.Unindent();
            Trace.WriteLineIf(true, "trace output if true");
            Trace.Assert(false, "Trace : Message if boolean is false : Will appear even in production environment");
            Trace.Assert(true, "This message is not displayed");
            Trace.Flush();
            Trace.AutoFlush = true;

            Console.ReadLine();
        }
    }
}
