using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lambda_01
{
    class Program
    {

        delegate int Delegate01(int i);

        static void Main(string[] args)
        {

            // Lambda in delegate
            Delegate01 Handler = x => x * x;
            Console.WriteLine(Handler(5));


            // Lambda in collection
            List<int> list01 = new List<int>();
            list01.Add(1);
            list01.Add(2);
            list01.Add(3);
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                list01.ForEach(i => writer.WriteLine(i));
                Console.WriteLine("Check output.txt for the output");
            }


            // Foreach

            list01.ForEach(i => Console.WriteLine(i));

        }
    }
}
