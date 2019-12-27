using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Database_13_Select_With_Stored_Procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var command = new SqlCommand("SearchWithinCustomerID", con);
            command.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Enter the search criteria");
            string searchCriteria = Console.ReadLine();
            command.Parameters.AddWithValue("CustomerID",searchCriteria);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["CustomerID"].ToString());
            }
            reader.Close();
            con.Close();
            command.Parameters.Clear();
        }
    }
}
