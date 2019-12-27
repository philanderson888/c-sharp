using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try_Catch_FInally_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number");
                int a = 12;
                string input = Console.ReadLine();
                int b = int.Parse(input);

                int answer = a / b;


                Console.WriteLine("{0} divided by {1} equals {2}", a, b, answer);


            }

            catch (Exception e) {
                Console.WriteLine("Error {0} \nis type {1}", e, e.GetType());

            }




            Console.ReadLine();

        }
    }
}
