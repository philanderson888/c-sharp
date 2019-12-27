using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace StreamWriter_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list01 = new List<int>();
            list01.Add(1);
            list01.Add(2);
            list01.Add(3);
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                list01.ForEach(i => writer.WriteLine(i));
                Console.WriteLine("Check output.txt for the output");
            }

            
        }
    }
}
