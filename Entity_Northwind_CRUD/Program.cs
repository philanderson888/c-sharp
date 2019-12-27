using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entity_Northwind_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            string customerid = "abcde";

            using (var db = new NorthwindEntities1())
            {
                Customer newCustomer = new Customer()
                {
                    CustomerID = customerid,
                    ContactName = "Fred",
                    City = "Berlin",
                    CompanyName = "NULL",
                    Address = "NULL",
                    ContactTitle = "NULL",
                    Region = "NULL",
                    PostalCode = "NULL",
                    Country = "NULL",
                    Phone = "NULL",
                    Fax = "NULL"
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }

            Console.WriteLine("\n\nInsert : check new record is present\n\n");
            using (var db = new NorthwindEntities1())
            {
                var customers = db.Customers.ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-40}{c.City,-20}");
                }
            }

            using (var db = new NorthwindEntities1())
            {
                // obtain your selected customer
                var selectedCustomer = db.Customers.Where(c => c.CustomerID == customerid).FirstOrDefault();
                // now update
                selectedCustomer.City = "Paris";
                // save back to database
                db.SaveChanges();
            }

            Console.WriteLine("\n\nUpdate : Check record has been updated\n\n");
            using (var db = new NorthwindEntities1())
            {
                var customers = db.Customers.ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-40}{c.City,-20}");
                }
            }

            Console.WriteLine("\n\nNow let's delete our record\n");
            using (var db = new NorthwindEntities1())
            {
                // select customer
                var selectedCustomer = db.Customers.Where(c => c.CustomerID == customerid).FirstOrDefault();
                // remove customer from local DbContext copy of database
                db.Customers.Remove(selectedCustomer);
                // update database
                db.SaveChanges();
            }

            Console.WriteLine("\n\nCheck record has been deleted\n\n");
            using (var db = new NorthwindEntities1())
            {
                var customers = db.Customers.ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-40}{c.City,-20}");
                }
            }
        }
    }
}
