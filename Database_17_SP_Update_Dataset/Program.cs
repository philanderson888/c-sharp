using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_17_SP_Update_Dataset
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var query = "Select * from Customers";
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, con);
            adapter.Fill(dataset);
            var table = dataset.Tables[0];
            var sb = new StringBuilder();
            foreach ( DataRow row in table.Rows)
            {
                sb.Append(string.Format("{0,-7}",row["CustomerID"].ToString()));
                sb.Append(string.Format("{0,-30}", row["ContactName"].ToString()));
                sb.Append(string.Format("{0,-30}", row["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }

            Console.WriteLine();
            Console.WriteLine("==choose row to update==");
            Console.WriteLine("Please select a row to update");
            var updateCustomerID = Console.ReadLine();

            DataRow[] selectedRows = table.Select("CustomerID = '" + updateCustomerID + "'");

            Console.WriteLine();
            Console.WriteLine("--displaying data--");
            foreach(DataRow row in selectedRows)
            {
                sb.Append(string.Format("{0,-7}", row["CustomerID"].ToString()));
                sb.Append(string.Format("{0,-30}", row["ContactName"].ToString()));
                sb.Append(string.Format("{0,-30}", row["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }

            Console.WriteLine();
            Console.WriteLine("==updating data==");
            Console.WriteLine("Please enter the new company name");
            var updateCompanyName = Console.ReadLine();

            foreach (DataRow row in selectedRows)
            {
                row["CompanyName"] = updateCompanyName;
            }

            var commandBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter.Update(dataset);

            Console.WriteLine();
            Console.WriteLine("== read from scratch ==");
            query = "Select * from customers";
            var command = new SqlCommand(query, con);
            var reader = command.ExecuteReader();
          
            while (reader.Read())
            {
                sb.Append(string.Format("{0,-7}",reader["CustomerId"].ToString()));
                sb.Append(string.Format("{0,-25}", reader["ContactName"].ToString()));
                sb.Append(string.Format("{0,-25}", reader["CompanyName"].ToString()));
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            con.Close();
        }
    }
}
