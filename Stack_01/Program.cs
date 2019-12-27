using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stack<string>();

            s.Push("first");
            s.Push("second");
            s.Push("third");

            string removed = s.Pop();

            Console.WriteLine("{0} was removed off the top", removed);
            Console.ReadLine();

        }
    }
}
