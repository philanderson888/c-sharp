using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Attributes_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAssembly = Assembly.LoadFrom(@"Z:\Users\Shared\OneDrive\PC\Course MTA 98-361 Software C#\VSProjects2015\Master\Attributes_03\bin\Debug\Attributes_03.exe");

            var types = myAssembly.GetTypes();

            foreach (var type in types)
            {
                
                var attributes = type.GetCustomAttributes();


                foreach (var attribute in attributes)
                {
                    Console.WriteLine("== TYPE {0} == ATTRIBUTE == {1}", type, attribute);


                    if (attribute is DemoAttribute)
                    {
                        DemoAttribute attr01 = (DemoAttribute)attribute;
                        Console.WriteLine("== TYPE {0} == ATTRIBUTE == {1} == DATA == {2}", type, attribute, attr01.myProperty);
                    }

                }

            }

            Console.WriteLine();
            Console.WriteLine("==second loop : just targeting this attribute only");
            Console.WriteLine();
            foreach (var type in types)
            {
                var attrs = type.GetCustomAttributes(typeof(DemoAttribute), false);

                foreach (var attr in attrs)
                {

                    if (attr is DemoAttribute)
                    {
                        DemoAttribute attr01 = (DemoAttribute)attr;
                        Console.WriteLine(attr01.myProperty);
                    }


                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class DemoAttribute : Attribute
    {
        public string myProperty { get; set; }

        public DemoAttribute(string myProperty)
        {
            this.myProperty = myProperty;
        }
    }


    [Demo("This is data in myProperty")]
    public class MyClass
    {

    }

    [Demo("This is some more data above Class2")]
    public class MyClass2
    {

    }



}
