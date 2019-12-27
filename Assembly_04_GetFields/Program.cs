using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assembly_04_GetFields
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(myClass);

            Assembly myAssembly = Assembly.GetAssembly(t);

            Console.WriteLine(myAssembly.FullName);

            var types = myAssembly.GetTypes();
            
            foreach(var type in types)
            {
                Console.WriteLine("type is {0}",type);
                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine("field is " + field);
                }

                var properties = type.GetProperties();
                foreach(var property in properties)
                {
                    Console.WriteLine("property is " + property);
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("method is " + method);
                }

            

            }



        }
    }

    class myClass
    {

        public int myField01 { get; set; }

        public void myMethod() { }
    }
}
