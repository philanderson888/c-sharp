using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.ExceptionServices;

namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("============================================================");
            WriteLine("============================================================");
            WriteLine("====                   Tuples                 ==============");
            WriteLine("============================================================");
            WriteLine("============================================================");
            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====                Older Declaration         ==============");
            WriteLine("============================================================");
            WriteLine("This tuple was created with angle brackets and fields are identified using 'item' ... ");

            Tuple<string, int> GetPerson1()
            {
                return Tuple.Create("field 1", 22);
            }

            WriteLine($"item 1 is {GetPerson1().Item1} and item 2 is {GetPerson1().Item2}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====              Named Declaration           ==============");
            WriteLine("============================================================");


            WriteLine("This tuple is declared with named fields ... ");

            (string name, int age) GetPerson2()
            {
                return ("Jill", 33);
            }

            WriteLine($"{GetPerson2().name} is {GetPerson2().age}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====    Assign Tuples As A Named Variable     ==============");
            WriteLine("============================================================");

            var tuple01 = GetPerson2();

            WriteLine($"{tuple01.name} has age {tuple01.age}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====   Deconstruct A Tuple To Separate Named Variables  ====");
            WriteLine("============================================================");

            (string name, int age) = tuple01;

            WriteLine($"{name} has age {age}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====        Assigning Named Variables Into A Tuple      ====");
            WriteLine("============================================================");

            var tuple02 = (10, "hello",true);
            WriteLine(tuple02.Item1); // 10
            WriteLine(tuple02.Item2); // "hello"
            WriteLine(tuple02.Item3); // true
            // we can assign variable names
            int num1 = 10;
            string greeting = "hello";
            bool isValid = true;
            var tuple03 = (num1, greeting, isValid);
            WriteLine(tuple03.num1);
            WriteLine(tuple03.greeting);
            WriteLine(tuple03.isValid);
        }
    }
}
