using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database_20_GridView_Display
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    

        public MainWindow()
        {
            InitializeComponent();
            InitializeGridview();
           
        }

        
        protected void InitializeGridview()
        {
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
          
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "Select * from Customers";
                var command = new SqlCommand(query, con);
                adapter.SelectCommand = command;
                adapter.Fill(dataset);
                var datatable = dataset.Tables[0];

                DataGrid01.ItemsSource = datatable.AsDataView();

                con.Close();
            }
                
        }

        private void DataGrid01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
