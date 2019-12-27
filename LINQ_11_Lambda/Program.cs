using System;
using System.Linq;

namespace LINQ_11_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\nAll Customers\n");
            using (var db = new NorthwindEntities())
            {
                var customers =
                    db.Customers.Where(c => c.CustomerID != null);

                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName,-35} has id {c.CustomerID,-10} and lives in {c.City}");
                }
            }

            Console.WriteLine("\n\n\nCustomers In London\n");
            using (var db = new NorthwindEntities())
            {

                var customers =
                    db.Customers.Where(c => c.CustomerID != null)
                    .Where(c=>c.City=="London");

                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName,-35} has id {c.CustomerID,-10} and lives in {c.City}");
                }
            }



            Console.WriteLine("\n\n\nCustomers In London Sorted\n");
            using (var db = new NorthwindEntities())
            {
                var customers =
                    db.Customers.Where(c => c.CustomerID != null)
                    .Where(c => c.City == "London")
                    .OrderBy(c => c.ContactName);


                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName,-35} has id {c.CustomerID,-10} and lives in {c.City}");
                }
            }


            Console.WriteLine("\n\n\nCustomers In London Reverse Sorted\n");
            using (var db = new NorthwindEntities())
            {
                var customers =
                    db.Customers.Where(c => c.CustomerID != null)
                    .Where(c => c.City == "London")
                    .OrderByDescending(c => c.ContactName);


                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName,-35} has id {c.CustomerID,-10} and lives in {c.City}");
                }
            }

            Console.WriteLine("\n\n\nFirst Customer In London\n");
            using (var db = new NorthwindEntities())
            {
                var firstCustomer =
                    db.Customers.Where(c => c.CustomerID != null)
                    .Where(c => c.City == "London")
                    .OrderBy(c => c.ContactName)
                    .FirstOrDefault();
                Console.WriteLine($"{firstCustomer.ContactName,-35} has id {firstCustomer.CustomerID,-10} and lives in {firstCustomer.City}");
            }

            Console.WriteLine("\n\n\nLast Customer In London Alphabetically\n");
            using (var db = new NorthwindEntities())
            {
                var lastCustomer =
                    db.Customers.Where(c => c.CustomerID != null)
                    .Where(c => c.City == "London")
                    .OrderByDescending(c => c.ContactName)
                    .FirstOrDefault();
                Console.WriteLine($"{lastCustomer.ContactName,-35} has id {lastCustomer.CustomerID,-10} and lives in {lastCustomer.City}");
            }



            Console.WriteLine("\n\n\nCustomers Sorted By City Then ContactName\n");
            using (var db = new NorthwindEntities())
            {
                var customers =
                    db.Customers.Where(c => c.CustomerID != null)
                    .OrderBy(c => c.City).
                    ThenBy(c => c.ContactName);
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName,-35} has id {c.CustomerID,-10} and lives in {c.City}");
                }
            }

            Console.WriteLine("\n\n\nCustomer Count, Average, Max, Min\n");
            using (var db = new NorthwindEntities())
            {
                
                Console.WriteLine($"There are {db.Customers.Count()} customers");

                Console.WriteLine($"There are {db.Products.Count()} products");

                Console.WriteLine($"The maximum product price is {db.Products.Max(p=>p.UnitPrice)}");

                Console.WriteLine($"The minimum product price is {db.Products.Min(p => p.UnitPrice)}");

                Console.WriteLine($"The average product price is {db.Products.Average(p=>p.UnitPrice)}");


                var productWithMaxPrice = db.Products.ToList<Product>().Aggregate((p, q) => p.UnitPrice > q.UnitPrice ? p : q);

                Console.WriteLine($"The product with max price of {productWithMaxPrice.UnitPrice} is {productWithMaxPrice.ProductName}");



                var productWithMaxPrice2 = db.Products.OrderByDescending(p => p.UnitPrice).FirstOrDefault();

                Console.WriteLine($"The product with max price of {productWithMaxPrice2.UnitPrice} is {productWithMaxPrice2.ProductName}");

            }

            Console.WriteLine("\n\n\n\n\n");
        }
    }
}
