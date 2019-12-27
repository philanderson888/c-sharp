using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Database_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadData();
        }

        private void ReadData()
        {
            var Customers = new List<Customer>();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;" +
                "Initial Catalog=Northwind;Integrated Security=true;"))
            {

                connection.Open();

                using (var command = new SqlCommand("select * from customers", connection))
                {

                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader["CustomerID"].ToString());
                        Console.WriteLine(myReader["CompanyName"].ToString());
                        Console.WriteLine(myReader["ContactName"].ToString());
                        Console.WriteLine(myReader["City"].ToString());
                        Console.WriteLine(myReader["Region"].ToString());
                        var customer = new Customer(myReader["CustomerID"].ToString(), myReader["CompanyName"].ToString(), myReader["ContactName"].ToString());
                        Customers.Add(customer);
                    }

                    foreach (var customer in Customers)
                    {
                        Console.WriteLine("{2} from {1} has ID {0}", customer.CustomerID, customer.CompanyName, customer.ContactName);
                    }
                }
            }

            dataGridView1.DataSource = Customers;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

    class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public Customer(string customerID, string companyName, string contactName)
        {
            this.CustomerID = customerID;
            this.CompanyName = companyName;
            this.ContactName = contactName;
        }
    }


}
