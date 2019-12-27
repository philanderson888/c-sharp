using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_01
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = { "Charlie", "Rose", "Pauline", "Joseph","Emily", "Bob" };

            Console.WriteLine("");
            Console.WriteLine("Before The Sort");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Array.Sort(names);

            Console.WriteLine("");
            Console.WriteLine("Sorting The Array");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Person[] people =
            {
                new Person {Name = "Charlie" },
                new Person {Name = "Bob" },
                new Person {Name = "Paul" },
                new Person {Name = "Jemima" }
            };

            Console.WriteLine("");
            Console.WriteLine("Next Array - Before The Sort");
            foreach (Person person in people)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("");
            Console.WriteLine("After The Sort");
            Array.Sort(people);
            foreach (Person person in people)
            {
                Console.WriteLine(person.Name);
            }


            Console.WriteLine("");
            Console.WriteLine("Comparing Names With 'Charlie'");
            Array.Sort(people);

            foreach (Person person in people)
            {
                Console.WriteLine(person.Name + " compared to Charlie : " + person.CompareTo(people[1]));
            }





            Console.ReadLine();
        }
    }



    class Person:IComparable
    {
        public string Name;

        public int CompareTo(object obj)
        {
            Person other = obj as Person;
            return this.Name.CompareTo(other.Name);
        }
    }
}
