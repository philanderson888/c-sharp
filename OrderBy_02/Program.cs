using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBy_02
{
    class Program
    {
        static void Main(string[] args)
        {


            // Input array.
            string[] array = { "the", "glass", "bead", "game" };

            // Order alphabetically by reversed strings.
            var result = array.OrderBy(a => new string(a.ToCharArray().Reverse().ToArray()));

            Console.WriteLine($"Result is an {result.GetType()}");
            
            // Display results.
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            /*
             
              Output ordering by last letter
             
                bead
                the
                game
                glass

            */


        }
    }
}
