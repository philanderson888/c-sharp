using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_07_Deferred
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities DBContext = new NorthwindEntities();

            var FinlandCustomer = DBContext.Customers.First(customer => customer.Country == "Finland");
            if (FinlandCustomer != null)
            {
                var r = new Random();
                FinlandCustomer.ContactName = r.Next(100).ToString();
                Console.WriteLine("New name {0}", FinlandCustomer.ContactName);
            }

            var customers =
                from cust in DBContext.Customers
                where cust.Country == "Finland"
                select new { Name = cust.ContactName , Country = cust.Country };


            FinlandCustomer = DBContext.Customers.First(customer => customer.Country == "Finland");

            if (FinlandCustomer != null)
            {
                var r = new Random();
                FinlandCustomer.ContactName = r.Next(100).ToString();
                Console.WriteLine("New name {0}", FinlandCustomer.ContactName);
            }

            customers.ToList().ForEach(item => { Console.WriteLine($"{item.Name},{item.Country}"); });

        }
    }
}
