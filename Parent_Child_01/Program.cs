using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parent_Child_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Animal();
            a.Name = "Felix";
            a.Speak();

            Dog d = new Dog();
            d.Name = "Fido";
            d.Speak();
            d.Bite();

            Cat c = new Cat();
            c.Name = "Fluffy";
            c.Speak();
            c.Scratch();

            Poke(d);
            
            Console.ReadLine();
        }

        static void Poke(Animal a)
        {
            Console.WriteLine("Poking {0}", a.Name);
            a.Speak();
        }
    }

    class Animal
    {
        public string Name;
        public void Speak()
        {
            Console.WriteLine("{0} is speaking", Name);
        }


    }

    class Dog :Animal
    {
        public void Bite()
        {
            Console.WriteLine("{0} is biting",Name);
        }

        public new void Speak()
        {
            Console.WriteLine("{0} is speaking as a Dog!!!", Name);
        }


    }

    class Cat : Animal
    {
        public void Scratch()
        {
            Console.WriteLine("{0} is scratching",Name);
        }
    }


}
