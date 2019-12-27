using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {


            int num1 = 10;
            while (num1 >= 0)
            {
                Console.WriteLine(num1);
                num1--;
            }



            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine(i);
            }

            string[] myArray01 = { "a", "b", "c" };

            foreach(string item in myArray01)
            {
                Console.WriteLine(item);
            }




            string password;

            do
            {
                Console.Write("Enter password");
                password = Console.ReadLine();
            }

            while (password != "Pa$$w0rd");




            Console.WriteLine("Correct!");



            Console.ReadLine();

        }
    }
}
