using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes_02
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class MyCustomAttribute : System.Attribute
    {
        private string field01;
        public string field02;
        public string property01
        {
            get { return this.property01; }
            set { this.property01 = value;  }
        }
        public MyCustomAttribute(string x, string y,string z = "OPTIONAL")
        {
            this.field01 = x;
            this.field02 = y;
            this.property01 = z;
        }
    }

    [MyCustomAttribute("test","test","test")]
    [MyCustomAttribute("test2", "test2", "test2")]
    class x
    {

    }
}
