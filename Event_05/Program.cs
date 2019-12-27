using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_23_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            var Paul = new Child();
            Paul.GetBorn();
            for (int i = 1; i < 16; i++)
            {
                int u = Paul.Grow();    // can't stop it!!!
                Console.WriteLine("Let's have a party because you are now {0}", u);
            }
        }
    }

    public class Child
    {
        public int age;


        //DECLARE DELEGATE : RESTRICT TYPE OF METHODS ; SUPER SIMPLE NO INPUTS/OUTPUTS
        public delegate int GrowingUpDelegate();

        // CREATE EVENT : LINK TO DELEGATE
        public event GrowingUpDelegate HaveABirthday;

        public void GetBorn()
        {
            age = 0;
            Console.WriteLine("Congrats!!! You have been born and your age is {0}", age);

            //SUBSCRIBE TO HAVING A BIRTHDAY
            HaveABirthday += Celebrate;
        }

        public int Grow()
        { 
            // ENSURE EVENT IS NOT NULL IE HAS HANDLERS (METHODS) ATTACHED TO IT, READY TO FIRE
            if(HaveABirthday != null)
            {
                return HaveABirthday(); // EVENT !!! 
            }
            return 0;
        }

        public int Celebrate()
        {
            age++;
            Console.WriteLine("Let's have a party because you are now {0}", age);
            return age;
        }
    }
}
