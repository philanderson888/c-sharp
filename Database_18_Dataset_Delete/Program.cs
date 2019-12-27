using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_18_Dataset_Delete
{
    class Program
    {
        static void Main(string[] args)
        {
            // read into dataset
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var dataset = new DataSet();
                var adapter = new SqlDataAdapter();
                var query = "Select * from customers";
                adapter.SelectCommand = new SqlCommand(query, con);
                adapter.Fill(dataset);
                var table = dataset.Tables[0];
                var sb = new StringBuilder();
                foreach(DataRow row in table.Rows)
                {
                    sb.Append(string.Format("{0,-7}{1,-20}{2,-20}",row["CustomerID"].ToString(),row["ContactName"].ToString(),row["CompanyName"].ToString()));
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }

                Console.WriteLine();
                Console.WriteLine("==choose item to delete==");
                Console.WriteLine("Please choose CustomerID to delete");
                var enteredCustomerID = Console.ReadLine();

                DataRow[] rows = table.Select("CustomerID = '" + enteredCustomerID + "'");

                foreach (DataRow row in rows)
                {
                    Console.WriteLine("About to delete this row");
                    sb.Append(string.Format("{0,-7}{1,-20}{2,-20}", row["CustomerID"].ToString(), row["ContactName"].ToString(), row["CompanyName"].ToString()));
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("==");
                foreach (DataRow row in rows)
                {
                    row.Delete();
                }
                var commandBuilder = new SqlCommandBuilder(adapter);
                adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                adapter.Update(dataset);
                // read data to check item deleted
                var command = new SqlCommand(query, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sb.Append(string.Format("{0,-7}{1,-20}{2,-20}",reader["CustomerID"].ToString(), reader["ContactName"].ToString(), reader["CompanyName"].ToString()));
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }
                reader.Close();
            }
        }
    }
}
