using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var James = new Child();
            James.name = "James";
            James.GetBorn();
            for (var i = 0; i < 15; i++)
            {
                James.Grow();
            }
        }
    }

    public class Child
    {
        public int age;
        public string name;

        public delegate void GrowingUpDelegate();      // will restrict methods that can run when child grows up

        public event GrowingUpDelegate HaveABirthday;   // get one year older

        public void GetBorn()                          // this will initialise the age to 0 and set method to run on birthdays
        {
            age = 0;
            Console.WriteLine("You have been born so your age is now {0}",age);
            HaveABirthday += Celebrate;                 // add a method when we have a birthday event
        }


        public void Grow()
        {
            if (HaveABirthday != null)
            {
                HaveABirthday();
            }
        }
        public void Celebrate()
        {
            age++;
            Console.WriteLine("Let's have a party because {0} you are now {1}",name, age);
        }
    }
}
