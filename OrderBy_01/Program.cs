using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBy_01
{
    class Program
    {
        static void Main(string[] args)
        {

            // from https://msdn.microsoft.com/en-us/library/bb534966(v=vs.110).aspx

            Pet[] pets = { new Pet { Name="Barley", Age=8 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=1 } };

            IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

            foreach (Pet pet in query)
            {
                Console.WriteLine("{0} - {1}", pet.Name, pet.Age);
            }


            /*
             This code produces the following output:

             Whiskers - 1
             Boots - 4
             Barley - 8
            */



        }
    }

    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


}
