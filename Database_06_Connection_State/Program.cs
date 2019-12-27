using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Database_06_Connection_State
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            var connection = new SqlConnection(connectionString);

            Console.WriteLine(connection.State);

            connection.Open();

            Console.WriteLine(connection.State);

            connection.Close();

            Console.WriteLine(connection.State);

        }
    }
}
