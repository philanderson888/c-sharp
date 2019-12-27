using System;
using System.Linq;
using static System.Console;

namespace LINQ_08_dotnet_core
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myArray = { "Michael", "George", "Robin", "Dexter", "Rob", "Paul", "Peter", "Norma" , "Joe" };

            // using explicit Func<string,bool>()
            WriteLine("\n\nQuery strings greater than length 4\n");
            var query = myArray.Where(new Func<string, bool>(LengthGreaterThan4));
            foreach (string s in query)
            {
                WriteLine(s);
            }

            // using implicit newer syntax
            WriteLine("\n\nRepeat query using newer syntax\n");
            var query2 = myArray.Where(LengthGreaterThan4);
            foreach(string s in query2)
            {
                WriteLine(s);
            }


            // finally repeat using Lambda
            WriteLine("\n\nFinally repeat with Lambda");
            var query3 = myArray.Where(s => s.Length > 4);
            WriteLine(string.Join(",", query3));

            // orderby
            WriteLine("\n\nNow add .orderby() length");
            var query4 = myArray.Where(s => s.Length > 3)
                .OrderBy(s => s.Length);
            WriteLine(string.Join(", ", query4));

            // order alphabetical descending
            WriteLine("\n\nNow sort descending alphabetically");
            var query5 = myArray
                .Where(s => s.Length > 3)
                .OrderByDescending(s=>s);
            WriteLine(string.Join(", ", query5));

            // order by length then alphabetical
            WriteLine("\n\nNow sort by length then alphabetical");
            var query6 = myArray
                .Where(s => s.Length > 3)
                .OrderBy(s => s.Length)
                .ThenBy(s => s);
            WriteLine(string.Join(", ", query6));
        }

        static bool LengthGreaterThan4(string s)
        {
            return s.Length > 4;
        }
    }
}
