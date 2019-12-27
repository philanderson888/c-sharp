using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> dictionary01 = new Dictionary<int, string>();

            dictionary01.Add(1, "one");
            dictionary01.Add(2, "two");
            dictionary01.Add(3, "three");
            dictionary01.Add(4, "four");

            foreach (int key in dictionary01.Keys)
            {
                Console.WriteLine(key);
                Console.WriteLine(dictionary01[key]);
            }

            foreach (var item in dictionary01)
            {
                Console.WriteLine(item.Key + item.Value);
            }

            Dictionary<string, string> mydict02 = new Dictionary<string, string>();
            mydict02.Add("first", "Jayne Eyre");
            mydict02.Add("first", "Jayne Eyre");


        }
    }






}
