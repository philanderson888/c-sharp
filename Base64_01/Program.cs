using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64_01
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] byteArray = new byte[128];
            // populate
            (new Random()).NextBytes(byteArray);
            // as bytes in Hex
            Console.WriteLine("\n\n{0,20}\n\n","Hex");
            for (int i = 0; i < byteArray.Length; i++)
            {
                Console.Write($"{byteArray[i]:X}");
            }
            // as Base64
            Console.WriteLine($"\n\n{"Base64",20}\n\n{Convert.ToBase64String(byteArray)}");
        }
    }
}
