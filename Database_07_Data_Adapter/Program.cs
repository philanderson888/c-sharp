using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Database_07_Data_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerList = new List<Customer>();
            var dataset = new DataSet();
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var query = "select * from customers";
            var con = new SqlConnection(connectionString);
            con.Open();
            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, con);
            adapter.Fill(dataset);

            DataTable datatable = dataset.Tables[0];

            Console.WriteLine("Table name is {0}",datatable.TableName);

            foreach (DataColumn col in datatable.Columns)
            {
                Console.WriteLine(col.ColumnName);
            }

            foreach (DataRow row in datatable.Rows)
            {
                var c = new Customer();
                c.CustomerID = row["customerID"].ToString();
                c.ContactName = row["contactName"].ToString();
                c.CompanyName = row["companyName"].ToString();
                customerList.Add(c);
                
            }


            Console.WriteLine("List has {0} customers",customerList.Count);

            Console.WriteLine("First customer is {0} with ID {1} from company {2}",customerList[0].ContactName,customerList[0].CustomerID,customerList[0].CompanyName);





        }
    }


}
