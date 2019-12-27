using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Database_10_Insert_DataSet_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var adapter = new SqlDataAdapter();
            var sql = "INSERT INTO Customers (CustomerID, ContactName, CompanyName) VALUES ('Phi99','Phil','Phils Company')";
            var command = new SqlCommand(sql, con);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            DataSet dataset = new DataSet();
            var query = "Select * from Customers where CustomerID LIKE 'Phi%'";
            command = new SqlCommand(query, con);
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            var datatable = dataset.Tables[0];
            foreach(DataRow row in datatable.Rows)
            {
                Console.WriteLine("{0} has name {1} and company {2}",row["CustomerID"].ToString(),row["ContactName"].ToString(),row["CompanyName"].ToString());
            }


        }
    }
}
