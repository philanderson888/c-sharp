using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass_By_Reference_01
{



    class Person

    {

        public int age;

    }



    class Program

    {

        static void Square(Person a, Person b)

        {

            a.age = a.age * a.age;

            b.age = b.age * b.age;

            Console.WriteLine(a.age + " " + b.age);

        }



        static void Main(string[] args)

        {



            Person p1 = new Person();

            Person p2 = new Person();



            p1.age = 5;

            p2.age = 10;



            Console.WriteLine(p1.age + " " + p2.age);

            Square(p1, p2);

            Console.WriteLine(p1.age + " " + p2.age);

            Console.ReadLine();

        }

    }


}
