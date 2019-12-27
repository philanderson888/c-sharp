using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_01
{
    class Program
    {
        static void Main(string[] args)
        {

            string value = "9quali52ty3";

            // Convert the string into a byte[].
            byte[] asciiBytes = Encoding.ASCII.GetBytes(value);

            foreach (var myByte in asciiBytes)
            {
                Console.WriteLine(myByte);
            }

        }
    }
}
