using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_15_SP_Update
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var query = "select * from customers";
            var command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            var sb = new StringBuilder();
            while (reader.Read())
            {
                sb.Append(string.Format("{0,20}", reader["CustomerID"].ToString()));
                sb.Append(string.Format("{0,30}", reader["ContactName"].ToString()));
                sb.Append(string.Format("{0,30}", reader["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            command.Parameters.Clear();
            reader.Close();
            Console.WriteLine("Choose ID");
            string CustomerIDChosen = Console.ReadLine();
            Console.WriteLine("Choose New Name");
            string CustomerNewName = Console.ReadLine();
            command = new SqlCommand("UpdateCustomer", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("CustomerID", CustomerIDChosen);
            command.Parameters.AddWithValue("ContactName", CustomerNewName);
            command.ExecuteNonQuery();

            query = "Select * from customers where CustomerID = @CustomerID";
            command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("CustomerID", CustomerIDChosen);
            reader = command.ExecuteReader();
            Console.WriteLine("==");
            while (reader.Read())
            {
                sb.Append(string.Format("{0,10}",reader["CustomerID"].ToString()));
                sb.Append(string.Format("{0,20}", reader["ContactName"].ToString()));
                sb.Append(string.Format("{0,20}", reader["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            reader.Close();
            con.Close();
        }
    }
}
