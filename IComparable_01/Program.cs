using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparable_01
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = new Item();
            var b = new Item();
            a.Name = "Bob";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}",a.Name,b.Name,a.CompareTo(b));
            a.Name = "Carly";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            a.Name = "Edward";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));

        }
    }



    public class Item : IComparable
    {
        public string Name;
        
        public int CompareTo(object o) {
            Item that = o as Item;
            return this.Name.CompareTo(that.Name);
        }
    }
}
