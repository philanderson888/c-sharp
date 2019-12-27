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
using System.Data;
using System.Data.SqlClient;

namespace Database_19_GridView_Display
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        NorthwindEntities dataset = new NorthwindEntities();
        SqlDataAdapter adapter = new SqlDataAdapter();
        
        

        public MainWindow()
        {
            InitializeComponent();
            var table = dataset.Customers;
            dataGrid.ItemsSource = table.ToList<Customer>();
            comboBox.ItemsSource = table.ToList<Customer>();
            listBox.ItemsSource = table.ToList<Customer>();
            listView.ItemsSource = table.ToList<Customer>();


        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }
    }

    public partial class Customer
    {
        public override string ToString()
        {
            return this.CustomerID.ToString();
        }
    }
}
