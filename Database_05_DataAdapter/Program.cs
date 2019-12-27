using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace Database_05_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var Customers = new List<Customer>();
            //string connectionString = @"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;Integrated Security=true";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            using (var connection = new SqlConnection(connectionString)) {

                var SqlString = "select * from customers";
                var command = new SqlCommand(SqlString, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new Customer(reader["CustomerID"].ToString(),reader["CompanyName"].ToString(),reader["ContactName"].ToString());
                        Customers.Add(customer);
                    }
                }
                foreach(var customer in Customers)
                {
                    Console.WriteLine(string.Format("Customer {0} with ID {1} lives in {2}",customer.ContactName, customer.CustomerID, customer.CompanyName));
                }
            }
        }
    }

    class Customer
    {
        public string CustomerID;
        public string CompanyName;
        public string ContactName;
        public Customer(string id, string company, string name)
        {
            this.CustomerID = id;
            this.CompanyName = company;
            this.ContactName = name;
        }
    }
}
