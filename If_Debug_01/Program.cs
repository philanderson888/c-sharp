#define DEBUG
#define MYTEST  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace If_Debug_01
{
    class Program
    {
        static void Main(string[] args)
        {

#if (DEBUG && !MYTEST)
            Console.WriteLine("DEBUG is defined");
#elif (!DEBUG && MYTEST)
        Console.WriteLine("MYTEST is defined");  
#elif (DEBUG && MYTEST)
        Console.WriteLine("DEBUG and MYTEST are defined");
#else
        Console.WriteLine("DEBUG and MYTEST are not defined");  
#endif
            Console.ReadLine();

        }
    }
}
