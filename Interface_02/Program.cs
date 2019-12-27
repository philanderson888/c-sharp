using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 object1 = new Class1();
            object1.DoThis();
            Console.WriteLine("==");
            Class2 object2 = new Class2();
            object2.DoThis();
            object2.AlsoDoThis();
        }
    }



    public interface IInterface1
    {
        void DoThis();
    }

    public interface IInterface2 : IInterface1          // extends IInterface 1
    {
        void AlsoDoThis();
    }

    public class Class1 : IInterface1 {
 
        public void DoThis()
        {
            Console.WriteLine("Executing DoThis Method from Within Class 1");
        }
   }

    public class Class2 : IInterface2
    {
        public void DoThis() {
            Console.WriteLine("DoThis from Class2");
        }
        public void AlsoDoThis() {
            Console.WriteLine("AlsoDoThis from Class2");
        }
    }

}
