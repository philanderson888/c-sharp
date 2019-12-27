using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;

namespace Entity_07_Categories_Of_Product
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {

                var categories =
                    (from c in db.Categories
                    select c).ToList<Category>();

                Console.WriteLine("=========Categories=========");
                foreach (Category c in categories)
                {

                    WriteLine($"\t{c.CategoryID} : {c.CategoryName} has {c.Products.Count} products");

                    Console.WriteLine("\t\t=======Products======");

                    foreach (Product p in c.Products)
                    {
                        WriteLine($"\t\t{p.ProductID} has name {p.ProductName}");
                    }
                }

            }


        }
    }
}
