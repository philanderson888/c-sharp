using System;
using static System.Console;
using System.Linq;

namespace LINQ_09_Combining_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // this tutorial looks at combining two sets of data
            string[] array01 = { "one", "two", "three", "four" };
            string[] array02 = { "three", "three", "four", "five", "six" };
            WriteLine("\n\nThis is array01  -  " + string.Join(", ", array01));
            WriteLine("\n\nThis is array02  -  " + string.Join(", ", array02));

            // Distinct from array02 as it has duplicate items
            WriteLine("\n\nFirstly extract only distinct values from array02");
            WriteLine(string.Join(", ", array02.Distinct()));

            WriteLine("\n\nNow Union() 2 arrays which eliminates duplicates");
            WriteLine(string.Join(", ", array01.Union(array02)));
            WriteLine("\n\nNow Contat() which joins and keeps all elements");
            WriteLine(string.Join(", ", array01.Concat(array02)));
            WriteLine("\n\nIntersect shows items in both sets");
            WriteLine(string.Join(", ", array01.Intersect(array02)));
            WriteLine("\n\nExcept only includes items in first array which are not present in second");
            WriteLine(string.Join(", ", array01.Except(array02)));
            WriteLine("\n\nZip matches the first with the first, and so on");
            // Create an enumerable collection of strings
            var arrayOfPairs = array01.Zip(array02, (a, b) => $"{a} with {b}");
            WriteLine(string.Join(", ", arrayOfPairs));
        }
    }
}
