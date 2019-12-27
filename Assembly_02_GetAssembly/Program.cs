using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assembly_02_GetAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAssembly = Assembly.LoadFile(@"C:\OneDrive\PC\Course MTA 98-361 Software C#\VSProjects2015\Master\Assembly_01_GetType\bin\Debug\Assembly_01_GetType.exe");
            Console.WriteLine(myAssembly.FullName);
            Console.WriteLine(myAssembly.GlobalAssemblyCache);
        }
    }
}
