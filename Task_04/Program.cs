using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parallel
            int[] myArray = new int[50];
            Parallel.For(0, 49, index => {
                myArray[index] = index * index;
                if (index == 25)
                {
                    System.Threading.Thread.Sleep(2000);
                }
            });
            foreach(int i in myArray)
            {
                Console.WriteLine(i);
            }

            Parallel.Invoke(()=> {
                myMethod01();
                myMethod02();
            });
            
        }

        static void myMethod01() { Console.WriteLine("1"); }
        static void myMethod02() { Console.WriteLine("2"); }
    }
}
