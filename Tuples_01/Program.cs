using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.ExceptionServices;

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

            var tuple02 = (10, "hello",true);
            Console.WriteLine(tuple02.Item1); // 10
            Console.WriteLine(tuple02.Item2); // "hello"
            Console.WriteLine(tuple02.Item3); // true
            // we can assign variable names
            int num1 = 10;
            string greeting = "hello";
            bool isValid = true;
            var tuple03 = (num1, greeting, isValid);
            Console.WriteLine(tuple03.greeting);
        }
    }
}
