using System;
using System.Linq;
using System.Collections.Generic;

namespace HashSet_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashset = new HashSet<int>();
            hashset.Add(10);
            hashset.Add(20);
            hashset.Add(10); // duplicate value overwritten but no exception
            foreach (var item in hashset) {
                Console.WriteLine(item);
            }
        }
    }
}
