using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binary_Writer_01
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter writer = new BinaryWriter(File.Create(@"abc.bin"));
            writer.Write(true);  // 1 bit
            Console.WriteLine("Binary writer has written one bit");
            writer.Close();
        }
    }
}
