using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_01
{
     enum Fruit
    {
        Apple = 5, Banana = 10, Cherry, Date, Elderberry
    }

    [Flags]

    enum Plants
    {
        Tree = 0,Shrub=1,Bush=2,Week =4
    }

    enum Test
    {
        Unknown = -1, first, second, third, count
    }


    class Program
    {
        static void Main(string[] args)
        {
            Fruit f = Fruit.Cherry;
            Console.WriteLine(f);
            Console.WriteLine((int)f);

            f = (Fruit)6;
            Console.WriteLine(f);
            Console.WriteLine((int)f);


            Plants p = Plants.Shrub | Plants.Week;
            Console.WriteLine(p);
            Console.WriteLine((int)p);


            Console.WriteLine("Items in Test are " + (int)Test.count);

            Console.ReadLine();
        }
    }
}
