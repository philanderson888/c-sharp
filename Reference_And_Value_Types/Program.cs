using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reference_And_Value_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point3D { X = 10, Y = 23, Z = 12 };

            var p2 = p1;

            Console.WriteLine("{0},{1},{2}", p2.X, p2.Y, p2.Z);


            var p3 = new Point3DValue { X = 10, Y = 23, Z = 12 };

            var p4 = p3;
            p4.X++;
            Console.WriteLine("P3: {0},{1},{2}", p3.X, p3.Y, p3.Z);
            Console.WriteLine("P4: {0},{1},{2}", p4.X, p4.Y, p4.Z);

            Console.ReadLine();

        }

        class Point3D
        {
            public int X, Y, Z;
        }

        struct Point3DValue
        {
            public int X, Y, Z;
        }


    }
}
