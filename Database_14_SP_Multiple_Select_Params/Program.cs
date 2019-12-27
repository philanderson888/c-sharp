using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_14_SP_Multiple_Select_Params
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var command = new SqlCommand("SearchWithMultipleParameters", con);
            command.CommandType = CommandType.StoredProcedure;
            string searchID = "P";
            string searchName = "P";
            command.Parameters.AddWithValue("CustomerID", searchID);
            command.Parameters.AddWithValue("ContactName", searchName);
            var reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
               
                sb.Append(string.Format("{0,5}", reader["CustomerID"].ToString()));  
                sb.Append(string.Format("{0,20}", reader["ContactName"].ToString())); 
                sb.Append(string.Format("{0,30}", reader["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();

            }

            con.Close();
        }
    }
}
