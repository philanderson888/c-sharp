using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stringbuilder_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            sb.Append("Some text ");
            sb.Append("Some more text ");
            sb.Append("And more too ");

            string output = sb.ToString();
            Console.WriteLine(sb);   // implied
            Console.WriteLine(output);  // explicit to string
            Console.WriteLine(sb.GetType());
            Console.WriteLine(sb.Capacity);
            Console.WriteLine(sb.MaxCapacity);
            
        }
    }
}
