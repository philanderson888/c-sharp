using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Database_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            var Customers = new List<Customer>();

            using (var connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=SA;Password=Passw0rd2018"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                var FixedCustomer = new Customer("Blog5", "Company5", "Joe Bloggs5");

                string sqlstring = "INSERT INTO CUSTOMERS (CustomerID,CompanyName,ContactName) VALUES ('Blog4', 'Company4', 'Joe Bloggs4')";

                Console.WriteLine(sqlstring);

                string sqlstring2 = String.Format("INSERT INTO CUSTOMERS (CustomerID,CompanyName,ContactName) VALUES ('{0}', '{1}', '{2}')", FixedCustomer.CustomerID, FixedCustomer.CompanyName, FixedCustomer.ContactName);

                Console.WriteLine(sqlstring2);

                using (var command = new SqlCommand(sqlstring2, connection))
                {
                    // if success this should equal 1
                    int affected = command.ExecuteNonQuery();
                }



                // update
                string sqlupdatestring = String.Format("UPDATE CUSTOMERS SET City='Berlin' WHERE CustomerId='{0}'", FixedCustomer.CustomerID);

                using (var command = new SqlCommand(sqlupdatestring, connection))
                {
                    // if success this should equal 1
                    int affected = command.ExecuteNonQuery();
                }



                // update with stored procedure

                // SQL command is built with the named stored procedure 'UpdateCustomer'
                using (var updatecustomercommand = new SqlCommand("UpdateCustomer", connection))
                {
                    // Using System.Data;
                    updatecustomercommand.CommandType = CommandType.StoredProcedure;
                    // add parameters
                    updatecustomercommand.Parameters.AddWithValue("ID", FixedCustomer.CustomerID);
                    updatecustomercommand.Parameters.AddWithValue("NewName", "Joe Bloggs Updated Name2");
                    // run the update
                    int affected = updatecustomercommand.ExecuteNonQuery();
                }



                using (var command = new SqlCommand("select * from customers", connection))
                {
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        string CustomerID = myReader["CustomerID"].ToString();
                        string CompanyName = myReader["CompanyName"].ToString();
                        string ContactName = myReader["ContactName"].ToString();

                        Console.WriteLine(myReader["CustomerID"].ToString());
                        Console.WriteLine(myReader["CompanyName"].ToString());
                        Console.WriteLine(myReader["ContactName"].ToString());
                        Console.WriteLine(myReader["City"].ToString());
                        Console.WriteLine(myReader["Region"].ToString());
                        var customer = new Customer(CustomerID, CompanyName, ContactName);
                        Customers.Add(customer);
                    }

                    myReader.Close();

                    foreach (var customer in Customers)
                    {
                        Console.WriteLine("{2} from {1} has ID {0}", customer.CustomerID, customer.CompanyName, customer.ContactName);
                    }
                }

                string sqldeletestring = String.Format("DELETE FROM CUSTOMERS WHERE CustomerId = '{0}'", FixedCustomer.CustomerID);

                using (var command = new SqlCommand(sqldeletestring, connection))
                {
                    // if success this should equal 1
                    int affected = command.ExecuteNonQuery();
                }


                using (var command = new SqlCommand("select * from customers", connection))
                {
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        string CustomerID = myReader["CustomerID"].ToString();
                        string CompanyName = myReader["CompanyName"].ToString();
                        string ContactName = myReader["ContactName"].ToString();

                        Console.WriteLine(myReader["CustomerID"].ToString());
                        Console.WriteLine(myReader["CompanyName"].ToString());
                        Console.WriteLine(myReader["ContactName"].ToString());
                        Console.WriteLine(myReader["City"].ToString());
                        Console.WriteLine(myReader["Region"].ToString());
                        var customer = new Customer(CustomerID, CompanyName, ContactName);
                        Customers.Add(customer);
                    }

                    foreach (var customer in Customers)
                    {
                        Console.WriteLine("{2} from {1} has ID {0}", customer.CustomerID, customer.CompanyName, customer.ContactName);
                    }

                    myReader.Close();
                }




            }
        }
    }

    class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public Customer(string customerID, string companyName, string contactName)
        {
            this.CustomerID = customerID;
            this.CompanyName = companyName;
            this.ContactName = contactName;
        }
    }

}
