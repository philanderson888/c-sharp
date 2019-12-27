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

namespace Lab_40_XAML_with_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities DBContext = new NorthwindEntities();

        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }


        private void PopulateListBox()
        {
            IQueryable<Customer> customers =
                from customer in DBContext.Customers
                orderby customer.ContactName
                select customer;

            listBox01.Items.Add("All Customers");
            listBox01.Items.Add(string.Format("There are {0} customers ", customers.Count()));

            foreach (var customer in customers)
            {
                /// put data on screen !!!
                listBox01.Items.Add(string.Format("{0} from {1}", customer.ContactName, customer.City));
            }
            

            textBox01.Text = "London";

            IQueryable<Customer> customers2 =
            from customer in DBContext.Customers
            where customer.City == textBox01.Text
            select customer;
            listBox02.Items.Add("Customers From City");
            foreach (var customer in customers2)          {
                listBox02.Items.Add(string.Format("{0} from {1}", customer.ContactName, customer.City));
            }



            // CREATE GROUPS BY CITY X HAS Y CUSTOMERS
            IQueryable<Customer> customers3 =
                        from customer in DBContext.Customers
                        orderby customer.City
                        select customer;

            List<string> list01 = new List<string>();

            foreach (var customer in customers3)
            {
                list01.Add(string.Format("{0,-27} - {1}", customer.City, customer.ContactName));
            }
            listBox03.Items.Clear();
            listBox03.ItemsSource = list01;
            
        }

        private void buttonDisplayItems_Click(object sender, RoutedEventArgs e)
        {

            IQueryable<Customer> customers2 =
from customer in DBContext.Customers
where customer.City == textBox01.Text
select customer;
            listBox02.Items.Add("Customers From City");
            foreach (var customer in customers2)
            {
                listBox02.Items.Add(string.Format("{0} from {1}", customer.ContactName, customer.City));
            }


        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }


    }


    public partial class Customer
    {

    }

}
