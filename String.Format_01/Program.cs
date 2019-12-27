using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace String.Format_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Note : with Console.WriteLine can either use string.Format or just omit it - result is the same
            
            Console.WriteLine(string.Format("{0}", "Left Justified Text Is Default"));
            Console.WriteLine();

            Console.WriteLine(string.Format("{0,50}", "Positive Number Right Justifies"));
            Console.WriteLine(string.Format("{0,50}", "Right Here"));

            Console.WriteLine();
            Console.WriteLine(string.Format("{0,-14}", "Negative Number Left Justifies"));
            Console.WriteLine(string.Format("{0,-14}", "y"));


            Console.WriteLine();
            Console.WriteLine(string.Format("{0,40}", "Right Justified Year"));
            Console.WriteLine(string.Format("{0,40:yyyy}",DateTime.Now));
            Console.WriteLine(string.Format("{0,40}", "Right Justified Month"));
            Console.WriteLine(string.Format("{0,40:MMM}", DateTime.Now));
            Console.WriteLine(string.Format("{0,40}", "Right Justified Day"));
            Console.WriteLine(string.Format("{0,40:dd}", DateTime.Now));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(string.Format("{0,30}", 123.456));
            Console.WriteLine(string.Format("{0,-30}", "N0 removes decimals"));
            Console.WriteLine(string.Format("{0,30:N0}", 123.456));
            Console.WriteLine(string.Format("{0,-30}", "N1 one number after decimal"));
            Console.WriteLine(string.Format("{0,30:N1}", 123.456));
            Console.WriteLine(string.Format("{0,-30}", "N6 six decimal places"));
            Console.WriteLine(string.Format("{0,30:N6}", 123.456));


            Console.WriteLine(string.Format("{0,-30}", "Pad out with zeros using :000000.0000"));
            Console.WriteLine(string.Format("{0,30:000000.0000}", 123.456));


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(string.Format("{0,35}", "0.123456"));
            Console.WriteLine(string.Format("{0,-35}", "P2 = Percentage to 2DP"));
            Console.WriteLine(string.Format("{0,35:P2}", 0.123456));
            Console.WriteLine(string.Format("{0,-35}", "P4 = Percentage to 4DP"));
            Console.WriteLine(string.Format("{0,35:P4}", 0.123456));


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Output number to fixed decimal places");
            Console.WriteLine("{0:000.000}",5);        //  005.000
            Console.WriteLine("{0:000.000}", 1234.5678);        //  1234.568 ie rounding up the third decimal place


            // display exponential as a long
            PerformanceCounter PC = new PerformanceCounter();
            PC.CategoryName = "Process";
            PC.CounterName = "Private Bytes";
            PC.InstanceName = "Explorer";
            Console.WriteLine(PC.NextValue());     // exponential
            Console.WriteLine(PC.NextValue().ToString());   // exponential
            Console.WriteLine(PC.NextValue().ToString("0"));   // force as long



            string s = System.String.Format("It is now {0:d} at {0:t}", DateTime.Now);
            Console.WriteLine(s);
            // Output similar to: 'It is now 4/10/2015 at 10:04 AM'

            string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
                        "Ebenezer", "Francine", "George" };
            decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80,
                                16.75m };

            Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");
            for (int i = 0; i < names.Length; i++)
                Console.WriteLine("{0,-20} {1,5:N1}", names[i], hours[i]);

        // The example displays the following output:
        //       Name                 Hours
        //
        //       Adam                  40.0
        //       Bridgette              6.7
        //       Carla                 40.4
        //       Daniel                82.0
        //       Ebenezer              40.3
        //       Francine              80.0
        //       George                16.8


        Console.ReadLine();
        }
    }
}
