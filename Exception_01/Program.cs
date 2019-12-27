using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_01
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 1, y = 0;

            try { int z = x / y; }
            catch (DivideByZeroException e)              //SPECIFIC 
            {
                Console.WriteLine("specific");
                Console.WriteLine(e);
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Data);
            }
            catch (Exception e)
            {           //GENERAL
                Console.WriteLine(e);
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Data);
            }
            finally
            {
                Console.WriteLine("SYSTEM HAS NOT CRASHED");
            }

            Console.WriteLine("======system reset=========");
            try
            {
               var e = new NullReferenceException("hi");
               throw e;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Data);
            }

            finally
            {
                Console.WriteLine("SYSTEM HAS NOT CRASHED");
            }

            Console.WriteLine("======system reset=========");



            try
            {
                throw (new Exception("error"));
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Data);
            }


            finally
            {
                Console.WriteLine("SYSTEM HAS NOT CRASHED");
            }

            Console.WriteLine("======system reset=========");


        }
    }
}
