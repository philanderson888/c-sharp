using System;

namespace BitShift
{
    class Program
    {
        static void Main(string[] args)

        {

            int i = 1;

            // Shift i one bit to the left. The result is 2.
            
            // Think of it as   
            // 1010 binary number shifting everything << to left
            // becomes
            // 10100 ie double
                            
            Console.WriteLine("0x{0:x}", i << 1);
            Console.WriteLine("Starting with i=1");
            Console.WriteLine(i);
            Console.WriteLine(i << 1);    // multiply by 2
            Console.WriteLine(i << 2);    // multiply by 2^2=4
            Console.WriteLine(i << 3);    // multiply by 2^3=8
            Console.WriteLine(i << 4);    // multiply by 2^4=16

            // Change i to be 32

            i = 32;
            Console.WriteLine("Starting with i = 32");
            Console.WriteLine(i);
            Console.WriteLine(i >> 1);    // divide by 2
            Console.WriteLine(i >> 2);    // divide by 2^2=4

            // Change i to be 33

            Console.WriteLine("Starting with i = 33");
            i = 33;
            Console.WriteLine(i);
            Console.WriteLine(i << 1);    // multiply by 2 
            Console.WriteLine(i << 2);    // multiply by 2 to power 2 = x4
            Console.WriteLine(i << 3);    // multiply by 2^3=8
            Console.WriteLine(i << 4);    // multiply by 2^4=16
            Console.WriteLine(i << 3);    // multiply by 2^3=8
            Console.WriteLine(i << 2);    // multiply by 2 to power 2 = x4
            Console.WriteLine(i);
            Console.WriteLine(i >> 1);    // divide by 2
            Console.WriteLine(i >> 2);    // divide by 2^2=4
            Console.WriteLine(i >> 3);    // divide by 2^3=8

            var x = 22;
            int y = x << 1;
            Console.WriteLine(y);
            Console.ReadLine();
        }
    }
}
