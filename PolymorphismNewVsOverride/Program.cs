using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismNewVsOverride
{
    class Program
    {
        static void Main(string[] args)
        {

            Overrider over = new Overrider();
            BaseClass b1 = over;
            over.Foo();                     //Overrider.Foo
            b1.Foo();                       //Overrider.Foo
            

            Hider hide = new Hider();
            BaseClass b2 = hide;
            hide.Foo();                     //Hider.Foo
            b2.Foo();                       //BaseClass.Foo


        }
    }

    public class BaseClass
    {
        public virtual void Foo()
        {
            Console.WriteLine("BaseClass.Foo");
        }
    }


    public class Overrider : BaseClass
    {
        public override void Foo()
        {
            Console.WriteLine("Overrider.Foo");
        }
    }

    public class Hider : BaseClass
    {
        public new void Foo()
        {
            Console.WriteLine("Hider.Foo");
        }
    }




}
