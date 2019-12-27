using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_04_Implicit_Explicit
{
    class Program
    {
        static void Main(string[] args)
        {
            var object01 = new Class01();
            object01.DoThis();

            var object02 = new Class02();
            var interface01Object02 = (IInterface01)object02;
            interface01Object02.DoThis();   
        }
    }

    public interface IInterface01
    {
        void DoThis();
    }

    public interface IInterface02
    {
        void DoThis();
    }

    public class Class01 : IInterface01, IInterface02
    {
        //Implicit
        public void DoThis() { Console.WriteLine("Implicit Method DoThis() "); }
    }

    public class Class02 : IInterface01, IInterface02
    {
        //Explicit
        // Be aware : EXPLICIT IMPLEMENTATION NOT PERMITTED TO HAVE
        // ANY ACCESS MODIFIER

        void IInterface01.DoThis() { Console.WriteLine("Explicit Method DoThis() "); }
        void IInterface02.DoThis() { }

        
    }

}
