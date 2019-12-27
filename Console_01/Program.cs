using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "red", true);
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "yellow", true);
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;
            Console.WriteLine("hello world");
        }
    }
}
