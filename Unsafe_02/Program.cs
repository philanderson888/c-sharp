using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsafe_02
{
    class Program
    {
        static void Main()
        {

            // Normal pointer to an object.  
            int[] a = new int[5] { 10, 20, 30, 40, 50 };

            // Must be in unsafe code to use interior pointers.  
            unsafe {
                // Must pin object on heap so that it doesn't move while using interior pointers.  
                fixed (int* p = &a[0])
                {
                    // p is pinned as well as object, so create another pointer to show incrementing it.  
                    int* p2 = p;
                    Console.WriteLine(*p2);
                    // Incrementing p2 bumps the pointer by four bytes due to its type ...  
                    p2 += 1;
                    Console.WriteLine(*p2);
                    p2 += 1;
                    Console.WriteLine(*p2);
                    Console.WriteLine("--------");

                    Console.WriteLine(*p);
                    // Deferencing p and incrementing changes the value of a[0] ...  
                    *p += 1;
                    Console.WriteLine(*p);
                    *p += 1;
                    Console.WriteLine(*p);
                }


                int[] numbers = { 0, 1, 2, 3, 4 };

                // Assign the array address to the pointer:
                fixed (int* p1 = numbers)
                {
                    // Step through the array elements:
                    for (int* p2 = p1; p2 < p1 + numbers.Length; p2++)
                    {
                        System.Console.WriteLine("Value:{0} @ Address:{1}", *p2, (long)p2);
                    }
                }


                fixed (int* b = &a[0])
                {
                    Console.WriteLine(*b);
                    Console.WriteLine((long)b);
                }

            }

        }


    }



}
