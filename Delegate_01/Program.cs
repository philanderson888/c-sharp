using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_01
{
    class Program
    {

        delegate int Delegate01(int i);

        static void Main(string[] args)
        {
            Delegate01 Handler = x => x * x;
            Console.WriteLine(Handler(5));

            Delegate01 Handler2 = (x) => ( x * x * x );
            Console.WriteLine(Handler2(5));

        }
    }
}





