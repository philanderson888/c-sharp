using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_09_DataSet_Insert_New_Row
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            var query = "select * from Customers";
            adapter.SelectCommand = new SqlCommand(query, con);
            adapter.Fill(dataset);
            var datatable = dataset.Tables[0];

            var newRow = datatable.NewRow();
            newRow["CustomerID"] = "Phill";
            newRow["ContactName"] = "Philip";
            newRow["CompanyName"] = "MyCompany";

            datatable.Rows.Add(newRow);

            var builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(dataset);

            dataset.Clear();
            datatable.Clear();
            query = "select * from Customers where CustomerID LIKE 'Phil%'";
            adapter.SelectCommand = new SqlCommand(query, con);
            adapter.Fill(dataset);
            datatable = dataset.Tables[0];
            foreach (DataRow row in datatable.Rows)
            {
                Console.WriteLine(row["CustomerID"].ToString());
                Console.WriteLine(row["ContactName"].ToString());
                Console.WriteLine(row["CompanyName"].ToString());

            }




        }
    }
}
