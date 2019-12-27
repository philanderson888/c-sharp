using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Delegate_01
{
    class Program
    {


        public delegate void myDelegate();


        static void Main(string[] args)
        {

            // long way using Delegate
            myDelegate myHandler = myMethod01;
            myHandler();


            // short way using Action
            Action myAction = myMethod01;
            myAction();

        }

        static void myMethod01()
        {
            // do something here : perform some ACTION BUT DON'T RETURN ANYTHING!
            Console.WriteLine("Notice I am doing something here as an action");
            Console.WriteLine("But also returning nothing as well");
            // notice this returns void
        }
    }
}
