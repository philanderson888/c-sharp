using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binary_Reader_01
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryReader reader = new BinaryReader(File.Open(@"abc.bin", FileMode.Open));
            Console.WriteLine(reader.ReadBoolean().ToString());
            reader.Close();
        }
    }
}
