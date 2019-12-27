using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace Database_08_Data_Adapter_Update
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerList = new List<Customer>();
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var query = "select * from customers";
            var dataset = new DataSet();
            var con = new SqlConnection(connectionString);
            con.Open();
            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, con);
            adapter.Fill(dataset);
            var datatable = dataset.Tables[0];
            foreach(DataRow row in datatable.Rows)
            {
                var customer = new Customer();
                customer.CustomerID = row["CustomerID"].ToString();
                customer.ContactName = row["ContactName"].ToString();
                customer.CompanyName = row["CompanyName"].ToString();
                customerList.Add(customer);
            }

            DataRow[] selectedRows = datatable.Select("CustomerID = 'ALFKI'");

            foreach (DataRow row in selectedRows)
            {
                Console.WriteLine(row["CustomerID"].ToString());
                Console.WriteLine(row["ContactName"].ToString());
                Console.WriteLine(row["CompanyName"].ToString());                
            }

            // update dataset

            foreach (DataRow row in selectedRows)
            {
                row["ContactName"] = "Phil9";
            }

            foreach (DataRow row in selectedRows)
            {
                Console.WriteLine(row["CustomerID"].ToString());
                Console.WriteLine(row["ContactName"].ToString());
                Console.WriteLine(row["CompanyName"].ToString());
            }

            // add event handler
            adapter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
            

            // confirm to database
            var builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(dataset);


        }

        private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            Console.WriteLine("Row updated ");
        }

    }
}
