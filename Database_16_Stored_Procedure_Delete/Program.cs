using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_16_Stored_Procedure_Delete
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var query = "SELECT * FROM CUSTOMERS";
            var command = new SqlCommand(query, con);
            var reader = command.ExecuteReader();
            var sb = new StringBuilder();
            Console.WriteLine("==LISTING ALL ITEMS==");
            while (reader.Read())
            {
                sb.Append(string.Format("{0,7}",reader["CustomerID"].ToString()));
                sb.Append(string.Format("{0,20}", reader["ContactName"].ToString()));
                sb.Append(string.Format("{0,20}", reader["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            reader.Close();
            Console.WriteLine();
            Console.WriteLine("==Deleting==");
            Console.WriteLine("Which ID do you wish to delete");
            string inputCustomerID = Console.ReadLine();
            command = new SqlCommand("DeleteCustomer", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("CustomerID", inputCustomerID);
            command.ExecuteNonQuery();

            // Re-display items
            command = new SqlCommand(query, con);
            reader = command.ExecuteReader();
            sb = new StringBuilder();
            Console.WriteLine("==LISTING ALL ITEMS==");
            while (reader.Read())
            {
                sb.Append(string.Format("{0,7}", reader["CustomerID"].ToString()));
                sb.Append(string.Format("{0,20}", reader["ContactName"].ToString()));
                sb.Append(string.Format("{0,20}", reader["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            reader.Close();
            command.Parameters.Clear();
            Console.WriteLine();

            //Add in item again
            //command = new SqlCommand("InsertCustomer", con);
            //command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("CustomerID", inputCustomerID);
            //command.Parameters.AddWithValue("ContactName", "test");
            //command.Parameters.AddWithValue("CompanyName", "Company02");
            //command.ExecuteNonQuery();

            //Re-display items
            command = new SqlCommand(query, con);
            reader = command.ExecuteReader();
            sb = new StringBuilder();
            while (reader.Read())
            {
                sb.Append(string.Format("{0,5}",reader["CustomerID"].ToString()));
                sb.Append(string.Format("{0,15}", reader["ContactName"].ToString()));
                sb.Append(string.Format("{0,15}", reader["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            con.Close();
        }
    }
}
