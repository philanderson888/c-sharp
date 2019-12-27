using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entity_01
{
    class Program
    {
        static NorthwindEntities DBContext = new NorthwindEntities();

        static void Main(string[] args)
        {
            
            foreach (Entity_01.Customer customer in DBContext.Customers)
            {
                Console.WriteLine("====");
                Console.WriteLine(customer.Address);
                Console.WriteLine(customer.Country);
                Console.WriteLine(customer.GetName());


            }

            Console.WriteLine("====");
            var customer01 = DBContext.Customers.First(e => e.Country == "Finland");
            if (customer01 != null)
            {
                Console.WriteLine("ID : {0}, name {1} ", customer01.CustomerID, customer01.ContactName);
                var sb = new StringBuilder();
                Random r = new Random();
                sb.Append(Convert.ToChar(r.Next(60,128)));
                sb.Append(Convert.ToChar(r.Next(60, 128)));
                customer01.ContactName = "George Anderson " + sb.ToString();
                Console.WriteLine("ID : {0}, name {1} ", customer01.CustomerID, customer01.ContactName);
            }

            DBContext.SaveChanges();

        }
    }

    public partial class Customer
    {
        public string GetName()
        {
            return ContactName;
        }
    }


}
