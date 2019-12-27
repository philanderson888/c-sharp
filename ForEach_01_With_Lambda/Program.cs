using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEach_01_With_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.ForEach(i => Console.WriteLine(i));

        }
    }
}
