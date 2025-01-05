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
            WriteLine("====                        Null                        ====");
            WriteLine("============================================================");
            WriteLine("============================================================");
            WriteLine("");

            WriteLine("============================================================");
            WriteLine("====                    Introduction                    ===="); 
            WriteLine("============================================================");
            WriteLine("");
            WriteLine("Null is a special value that represents the absence of a value.");
            WriteLine("It is used to indicate that a variable does not have a value.");
            WriteLine("Null is a reference type and can be assigned to any reference type variable.");
            WriteLine("Null is not the same as zero or an empty string.");
            WriteLine("Null is not the same as an empty collection.");
            WriteLine("Null is not the same as a default value.");
            WriteLine("Null is not the same as undefined, void, nil, None, Nothing, NaN, or Infinity.");

            WriteLine(" ");
            WriteLine("... null check enabled using `#nullable enable` directive.");
            WriteLine("... and also using <Nullable>enable</Nullable> in the project file.");
            WriteLine("... this is enabled by default since .NET 6.0.");

            WriteLine(" ");
            WriteLine("... here is null exception example");

            WriteLine(" ");
            WriteLine("... declare variable and assign it as null.");
            WriteLine("... exlamation mark suppresses compiler warning ...");
            //FooBar fooBar = null;
            FooBar fooBar = null!;

            WriteLine("... try to access the variable.");
            try
            {
                WriteLine(" ");
                WriteLine("... dereference variable by calling ToString.");
                WriteLine("... this will throw a NullReferenceException.");
                _ = fooBar.ToString();
            }
            catch (NullReferenceException ex)
            {
                WriteLine($"NullReferenceException: {ex.Message}");
            }

            WriteLine(" ");
            WriteLine("... check for null before accessing the variable.");

            if (fooBar is not null)
            {
                _ = fooBar.ToString();
            } else
            {
                WriteLine("fooBar is null so it cannot be accessed and is not checked");
            }

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====                   Default                ==============");
            WriteLine("============================================================");
            WriteLine("");
            WriteLine("... default types for primitives are 0, false, null, etc.");
            WriteLine("... default types for reference types are null.");

            int defaultInteger = default;
            WriteLine($"\ndefault integer has value {defaultInteger}");

            bool defaultBoolean = default;
            WriteLine($"\ndefault boolean has value {defaultBoolean}");

            //string unassignedString;
            WriteLine($"\ncannot use unassigned string unassignedString");

            //string defaultString = default;
            //WriteLine($"\ndefault string is null ie {defaultString}");

            string emtpyString = string.Empty;
            WriteLine($"\nempty string is {emtpyString}");

            //DateTime unassignedDateTime;
            WriteLine(" ");
            WriteLine($"\ncannot use unassigned date time");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====                     Nullable                       ====");
            WriteLine("============================================================");

            //int? uninitializedIntegerIsNull;           
            WriteLine($"\nfirst is null as it is not initialized ... and as such it cannot be used");
            //WriteLine(uninitializedIntegerIsNull);

            int? nullAssignedInteger = null;
            WriteLine($"\nnull assigned integer has value null ... ${nullAssignedInteger}");

            int? defaultNullAssignedInteger = default; 
            WriteLine($"\ndefault null assigned integer has value null ... ${defaultNullAssignedInteger}");

            int? newAssignedIntegerIsZero = new();    
            WriteLine($"\nnew assigned integer has value 0 ... ${newAssignedIntegerIsZero}");

            string? nullableString = null;
            WriteLine($"\nnullable string has value null ... ${nullableString}");

            nullableFoobar? nullableFooBarInstance = null;
            WriteLine($"\nnullable FooBar has value null ... ${nullableFooBarInstance}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====                  Best Practice                    ====");
            WriteLine("============================================================");
            WriteLine("assign with default values where possible eg use 'new' keyword");
            FooBar fooBarRealInstance = new(Id: 1, Name: "Foo");
            WriteLine($"\nfooBarRealInstance has value {fooBarRealInstance}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====                  Null Forgiving (!)                ===="); 
            WriteLine("============================================================");
            WriteLine("... best practice is to avoid using null forgiving operator");
            WriteLine("\n... in this instance the non nullable list is potentially null so we must ask the compiler to ignore the null check");

            var fooList = new List<FooBar>
            {
                new(Id: 1, Name: "Foo"),
                new(Id: 2, Name: "Bar")
            };

            FooBar findFooBarItem = fooList.Find(f => f.Name == "Bar")!;
            WriteLine($"\nfindFooBarItem has value {findFooBarItem}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====                  Null Coalescing (??)              ===="); 
            WriteLine("============================================================");
            WriteLine("... null coalescing operator is used to assign a default value to a nullable type");

            int? nullableInteger = null;

            int nonNullableInteger = nullableInteger ?? 0;

            WriteLine($"\nnonNullableInteger has value {nonNullableInteger}");

            WriteLine("");
            WriteLine("============================================================");
            WriteLine("====                  Null Conditional (?.)             ===="); 
            WriteLine("============================================================");
            WriteLine("... null conditional operator is used to access a property or method of a nullable type");

            FooBar? nullableFooBarInstance2 = new(Id: 1, Name: "Foo");
            string? nullableFooBarName = nullableFooBarInstance2?.Name;
            WriteLine($"\nnullableFooBarName has value {nullableFooBarName}");

            nullableFoobar? nullableFooBarInstance3 = null;
            WriteLine($"\nnullable FooBar instance 3 has value null ... {nullableFooBarInstance3}");
            var nonNullableString = nullableFooBarInstance3?.ToString() ?? "unknown";
            WriteLine($"nonNullableString has value '{nonNullableString}'");

        }
    }
}

record FooBar(int Id, string Name);

record nullableFoobar(int? Id, string? Name);
