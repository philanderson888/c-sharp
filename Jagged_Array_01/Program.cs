using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Array_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[10][];   // 10 jagged arrays of unfixed size at present

            jaggedArray[0] = new int[5];
            jaggedArray[0][4] = 99;
            jaggedArray[1] = new int[4];
            jaggedArray[1][3] = 67;

            Console.WriteLine(jaggedArray[0][4]);
            Console.WriteLine(jaggedArray[1][3]);

        }
    }
}
