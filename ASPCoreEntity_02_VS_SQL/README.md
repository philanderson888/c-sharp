# ASP.NET Core Entity Razor 02

This project attemts to use the built-in Razor Visual Studio 
scaffolding to build a set of pages - 
a pre-built website built by Visual Studio.

Within this I have added just one page `Phil.cstml` and 
its code-behind page `Phil.cshtml.cs` and 
they both use Northwind to put Products on the screen.

It's the most basic example that I can think of!!!

Things to be aware of and learning points

* use DbContext not DBContext

* use non-static methods as we are instantiating 
the class in order to produce the results