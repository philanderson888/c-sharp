using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace Database_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
        }

        private Northwind ds = new Northwind();

        private NorthwindTableAdapters.ProductsTableAdapter ta = new NorthwindTableAdapters.ProductsTableAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            ta.Fill(ds.Products);
            dataGridView1.DataSource = ds.Products;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rows = ta.Update(ds.Products);
            MessageBox.Show(rows + " were updated.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;" +
                "Initial Catalog=Northwind;Integrated Security=true;");

            connection.Open();

            var command = new SqlCommand("UpdatePriceOfProduct", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("ID", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("NewPrice", decimal.Parse(textBox2.Text));

            int affected = command.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show(affected + " rows were affected");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
