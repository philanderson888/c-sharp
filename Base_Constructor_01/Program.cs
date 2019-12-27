using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Constructor_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Parent(10);
            Child c = new Child(20);
        }
    }

    class Parent {
        private int field;
        public Parent() { }
        public Parent(int field)
        {
            this.field = field;
        }
    }
    class Child : Parent {

        public Child() { }

        public Child (int field) : base(field)
        {
      
        }
    }
}
