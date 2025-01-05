#nullable enable
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.ExceptionServices;

namespace types
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("\n\n\n\n\n\n\n\n\n");
            WriteLine("============================================================");
            WriteLine("============================================================");
            WriteLine("====                        .NET                        ====");
            WriteLine("============================================================");
            WriteLine("============================================================");
            WriteLine("");

            WriteLine("============================================================");
            WriteLine("====                    Introduction                    ===="); 
            WriteLine("============================================================");
            WriteLine("");

            WriteLine("The .NET platform is a software framework developed by Microsoft.");
            WriteLine("The .NET platform is designed to build and run software applications for Windows, Windows Server, Microsoft Azure, and other operating systems.");
            
            WriteLine("\nThe .NET platform has been around since 2002.");
            WriteLine("The .NET platform has evolved over the years.");
            WriteLine("The .NET platform has been open-source since 2014.");
            WriteLine("The .NET platform has been cross-platform since 2016.");
            WriteLine("The .NET platform has been unified since 2020.");
            
            
            WriteLine("\n============================================================");
            WriteLine("====                     Version                        ===="); 
            WriteLine("============================================================");
            WriteLine("");

            WriteLine("\ncheck your version of .NET by running `dotnet --version`");
            WriteLine("... 9.0.101");

            WriteLine("\n... and also by running `dotnet --list-sdks`");
            WriteLine("... 9.0.101 [/usr/local/share/dotnet/sdk]");

            WriteLine("\n============================================================");
            WriteLine("====                     Warning                        ===="); 
            WriteLine("============================================================");
            WriteLine("");

            WriteLine("To treat warnings as errors, you can add the following to your .csproj file:");
            WriteLine("<TreatWarningsAsErrors>true</TreatWarningsAsErrors>");

            WriteLine("\n============================================================");
            WriteLine("====                     Building                        ===="); 
            WriteLine("============================================================");

            WriteLine("to ensure a clean build of all assemblies you can first run the command `dotnet clean`");
            WriteLine("\nTo build a .NET project, run `dotnet build`");
            WriteLine("... this will compile the project and create a `bin` directory with the compiled output");

            WriteLine("\n============================================================");
            WriteLine("====                     Running                        ===="); 
            WriteLine("============================================================");

            WriteLine("\nTo run a .NET project, run `dotnet run`");
        }
    }
}
