using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_11_Insert_With_Params
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var adapter = new SqlDataAdapter();
            var query = "INSERT INTO Customers (CustomerID, ContactName, CompanyName) values (@CustomerID, @ContactName, @CompanyName)";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerID", "Phif2");
            command.Parameters.AddWithValue("@ContactName", "Philip");
            command.Parameters.AddWithValue("@CompanyName", "PhilCo");

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            
        }
    }
}
