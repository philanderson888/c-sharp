using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Database_12_Select_With_Params
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var adapter = new SqlDataAdapter();
            var query = "Select * from Customers where CustomerID LIKE '%' + @Name + '%'";
            var command = new SqlCommand(query, con);
            
           command.Parameters.Add(new SqlParameter("Name", "Phil"));
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString());
            }
            command.Parameters.Clear();
            reader.Close();
            string inputCriteria = null;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter new search name");
                inputCriteria = Console.ReadLine();
                command.Parameters.Add(new SqlParameter("Name", inputCriteria));
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString());
                }
                command.Parameters.Clear();
                reader.Close();
            }
        }
    }
}