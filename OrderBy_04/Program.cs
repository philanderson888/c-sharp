using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OrderBy_04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list01 = new List<Person>();
            
            var personToAdd = new Person("Tom", "Trainer");
            list01.Add(personToAdd);
            personToAdd = new Person("Tom", "Athlete");
            list01.Add(personToAdd);
            personToAdd = new Person("Tom", "Bobby");
            list01.Add(personToAdd);

            personToAdd = new Person("Bob", "Insurance Broker");
            list01.Add(personToAdd);
            personToAdd = new Person("Bob", "Builder");
            list01.Add(personToAdd);
            personToAdd = new Person("Bob", "Carpenter");
            list01.Add(personToAdd);

            var outputList = list01.OrderBy(q => q.Name).ThenBy(q => q.Occupation).ToList();

            Console.WriteLine("Sorting list first by name alphabetically and then by occupation");
            Console.WriteLine();

            foreach(Person p in outputList)
            {
                Console.WriteLine($"{p.Name} has occupation {p.Occupation}");
            }

            var outputListLINQ = from person in list01
                                 orderby person.Name, person.Occupation
                                 select person;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now doing the same thing with pure LINQ query");
            Console.WriteLine();

            foreach (Person p in outputList)
            {
                Console.WriteLine($"{p.Name} has occupation {p.Occupation}");
            }

        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
        public Person (string name, string occupation)
        {
            this.Name = name;
            this.Occupation = occupation;
        }
    }
}
