using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throw
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BusinessLogic();
            }

            catch (Exception e) {
                Console.WriteLine("Inside business logic");
                Console.WriteLine(e.StackTrace);
            }

            finally { }

            Console.ReadLine();

        }

        static void BusinessLogic() {
            try
            {
                DataTier();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception is " + e.Data);
            }

            finally { }


        }

        static void DataTier()
        {
            throw new ArgumentException("Something went wrong");
        }
    }
}
