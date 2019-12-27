using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assembly_01_GetType
{
    class Program
    {
        static void Main(string[] args)
        {

            Type t = typeof(int);

            Assembly a = Assembly.GetAssembly(t);

            Console.WriteLine("Assembly Full Name {0}", a.FullName);
            Console.WriteLine("In GAC?   {0}", a.GlobalAssemblyCache);


        }
    }
}
