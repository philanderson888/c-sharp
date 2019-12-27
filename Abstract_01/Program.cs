using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_01
{
    class Program
    {
        static void Main(string[] args)
        {

            // ERROR !!!    Animal a = new Animal




        }
    }

    abstract class Animal
    {
        public abstract void Move();

    }

    class Dog :Animal
    {
        public override void Move()
        {

        }
    }
}
