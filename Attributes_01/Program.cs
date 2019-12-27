using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes_01
{
    class Program
    {
        static void Main(string[] args)
        {




        }


        [myCustomAttribute("data for field x")]
        class myClass
        {

        }


        public class myCustomAttribute : System.Attribute
        {
            private string x;
            public myCustomAttribute(string x)
            {
                this.x = x;

            }
        }

    }
}
