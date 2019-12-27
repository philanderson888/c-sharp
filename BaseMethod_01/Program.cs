using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseMethod_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var Peter = new Child();
            Peter.Grow();
            Peter.Grow();
            Peter.Grow();
            Peter.Grow();
            Peter.Grow();
        }
    }

    class Parent
    {
        public int Age;
        public virtual void Grow()
        {
            Age++;
            Console.WriteLine(Age);
        }
    }

    class Child :Parent
    {
        public override void Grow()
        {
            Console.WriteLine("Child is growing");
            base.Grow();
        }
    }
}
