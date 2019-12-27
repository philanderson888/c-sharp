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
using System.Collections;
using System.Data.Services.Client;


namespace Lab_17_GUI_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // first pull in ENTITY
        // pull in DB : DECLARE DB HERE (STATIC)
        static NorthwindEntities DBContext = new NorthwindEntities();
   //     List<Customer> customers = new List<Customer>();

        Customer c;

        public MainWindow()
        {
            InitializeComponent();
            foreach(Customer c in DBContext.Customers)
            {
                ListBox01.Items.Add(String.Format("{0} is {1} who lives in {2}", c.CustomerID, c.ContactName, c.City));
            }
            ListBox02.DisplayMemberPath = "ContactName";
            ListBox02.ItemsSource = DBContext.Customers.ToList<Customer>();
            Button03.IsEnabled = false;
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            // FOREACH (CUSTOMERS)
            // POPULATE LIST BOX

            // LINQ QUERY
            // POPULATE LIST BOX

            // SELECT ONE PERSON FROM FINLAND
            // CREATE AN 'UPDATE' BUTTON ==> CLICK ==> PUSH FROM TEXTBOX HIS NEW NAME

            // var customers = LINQ QUERY

            // DB BINDING
            // ListBox01.ItemsSource = customers.ContactName;
        }

        private void ListBox02_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            c = ListBox02.SelectedItem as Customer;

            c.ContactName += "9";
            DBContext.SaveChanges();

            ListBox01.Items.Add(c.ContactName);

            Button03.IsEnabled = true;
            ListBox02.Items.Refresh();


        }

        private void Button03_Click(object sender, RoutedEventArgs e)
        {

            DBContext.Customers.Remove(c);
            DBContext.SaveChanges();
            Button03.IsEnabled = false;
            ListBox02.Items.Refresh();
        }

        private void ButtonInsert_Click(object sender, RoutedEventArgs e)
        {


            string newCustomerId = "ALFKe";

            var newCustomer = new Customer()
            {
                CustomerID = newCustomerId,
                Address = "NULL",
                City = "berlin",
                CompanyName = "NULL",
                ContactName = newCustomerId,
                ContactTitle = "NULL",
                Region = "NULL",
                PostalCode = "NULL",
                Country = "NULL",
                Phone = "NULL",
                Fax = "NULL"
            };

            DBContext.Customers.Add(newCustomer);
            DBContext.SaveChanges(); 
        }
    }
}
