using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assembly_03_GetTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(int);
            Assembly myAssembly = Assembly.GetAssembly(t);
            var types = myAssembly.GetTypes();
            foreach(var item in types)
            {
                Console.WriteLine(item);
                
            }
        }
    }
}
