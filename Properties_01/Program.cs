using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            // p.Age = -20000;
            p.Age = 19;
            Console.WriteLine(p.Age);
            Console.ReadLine();

        }
    }

    class Person
    {
        private int age;

        public int Age
        {
            get { return age; }
            set {
                if ((value < 18) || (value > 65))
                {
                    throw new ArgumentException("Age must be 18-65");
                }
                else
                {
                    age = value;
                }
            }
        }
    }
}
