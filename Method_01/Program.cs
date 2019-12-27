using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_01
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStuff();
            Method01(1, "hi", true);
            Console.ReadLine();

        }

        static void DoStuff()  // Must be STATIC if ATTACHED TO THE CLASS
        {
            var p = new Person();
            p.Age = 10;
            p.Name = "Paul";
            p.HaveBirthday();
            p.Output();
            p.Output(p.Name);
            var q = new Person();
            q.Output();
            var r = new Person("Peter", 44);
            r.Output();
            Console.WriteLine("Cost is {0:C}." , CalcHotelCost(100M, 3, 50M));
        }

        static decimal CalcHotelCost(decimal price, int numberOfNights=1, decimal discount=0)
        {
            return ((price * numberOfNights)-discount);
        }

        static void Method01(int a, string b, bool c)
        {
            Console.WriteLine("hi");
        }

    }



    class Person
    {
        public int Age; //field
        public string Name; 

        public Person()
        {
            Name = "Unknown";
            Age = 18;
        }

        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public void HaveBirthday()
        {
            Age++;
        }

        public void Output()
        {
            Console.WriteLine("{0} is {1} years old",Name, Age);
        }

        public void OutputNameOnly()
        {
            Console.WriteLine("Name is {0}.", Name);
        }

        //Overload
        public void Output(string Name)
        {
            Console.WriteLine("{0} is {1} years old", Name, Age);
        }


    }
}
