using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // construct tuples

            // old CSharp declaration
            Tuple<string, int> GetPerson1()
            {
                return Tuple.Create("Bob", 22);
            }

            // C#7 tuple declaration
            // must install Nuget ValueTuple to get this working


            (string name, int age) GetPerson3()
            {
                return ("Jill", 33);
            }

            WriteLine($"{GetPerson3().name} is {GetPerson3().age}");

            string x = default;
            WriteLine($"x is {x}");

            // assign tuples to variables

            var tuple01 = GetPerson3();

            WriteLine($"{tuple01.name} has age {tuple01.age}");

            // deconstruct

            (string name, int age) = tuple01;

            WriteLine($"{name} has age {age}");
        }
    }
}
