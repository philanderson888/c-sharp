using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yield_Return_01
{
    class Program
    {
        static void Main(string[] args)
        {


            foreach (int i in list01(10)){
                Console.WriteLine(i);
            }
        }

        // CREATES AN ENUMERABLE LIST
        public static IEnumerable<int> list01(int max)
        {
            for (int i = 0; i < max; i++)
            {
                yield return i;
            }
        }

    }



}
