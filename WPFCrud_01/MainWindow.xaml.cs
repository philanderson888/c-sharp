using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace WPFCrud_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities DBContext = new NorthwindEntities();
        List<Customer> customerList = new List<Customer>();


        public MainWindow()
        {
            InitializeComponent();
            CustomerName.Text = "Fred";
            CustomerCity.Text = "London";
            LoadCustomers();
            
        }

        private void LoadItems_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
        }

        private void ListBox01_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine(e.OriginalSource);
            if (e.OriginalSource != DeleteItem)
            {
                Trace.WriteLine(ListBox01.SelectedIndex);
                Debug.WriteLine("hi");
                Trace.WriteLine("hi");
                if(ListBox01.SelectedIndex != -1)
                {
                    var selectedCustomer = customerList[ListBox01.SelectedIndex];
                    CustomerIndex.Text = ListBox01.SelectedIndex.ToString(); ;
                    CustomerID.Text = selectedCustomer.CustomerID;
                    CustomerName.Text = selectedCustomer.ContactName;
                    CustomerCity.Text = selectedCustomer.City;
                }

            }



        }

        private void LoadCustomers()
        {
            customerList =
                 (from customer in DBContext.Customers
                 select customer).ToList<Customer>();
            ListBox01.ItemsSource = customerList;
            ListBox02.Items.Clear();
            ListBox02.Items.Add("Index");
            ListBox02.Items.Add("CustomerID");
            ListBox02.Items.Add("ContactName");
            ListBox02.Items.Add("City");
            CustomerID.IsReadOnly = true;

            ListBox04.ItemsSource = customerList;

        }

        private void ClearItems_Click(object sender, RoutedEventArgs e)
        {
            ClearItemsNow();
        }

        private void NewItem_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (CustomerID.Text != null && !DBContext.Customers.Any(customer=>customer.CustomerID == CustomerID.Text)){
                    var newCustomer = new Customer();
                    newCustomer.ContactName = CustomerName.Text;
                    newCustomer.City = CustomerCity.Text;
                    newCustomer.CustomerID = CustomerID.Text;
                    newCustomer.CompanyName = "Burger King";
                    DBContext.Customers.Add(newCustomer);
                    DBContext.SaveChanges();
                    LoadCustomers();
                    CustomerID.IsReadOnly = true;
                }

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                   Trace.WriteLine("Entity of type "  + eve.Entry.Entity.GetType().Name + " in state \"{1}\" has the following validation errors:" + eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                // throw;
                ListBox02.Items.Add("Customer ID is required");
            }





        }

        private void UpdateItems_Click(object sender, RoutedEventArgs e)
        {
            var customerToUpdate = DBContext.Customers.First(customer => customer.CustomerID == CustomerID.Text);
            customerToUpdate.ContactName = CustomerName.Text;
            customerToUpdate.City = CustomerCity.Text;
            DBContext.SaveChanges();
            LoadCustomers();

        }

        private void DeleteItems_Click(object sender, RoutedEventArgs e)
        {
            var customerToDelete = DBContext.Customers.First(customer => customer.CustomerID == CustomerID.Text);
            DBContext.Customers.Remove(customerToDelete);
            DBContext.SaveChanges();
            LoadCustomers();
            ClearItemsNow();

        }

        private void ClearItemsNow()
        {
            CustomerIndex.Text = null;
            CustomerID.Text = null;
            CustomerName.Text = null;
            CustomerCity.Text = null;
            CustomerID.IsReadOnly = false;
        }

        private void ListBox04_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = customerList[ListBox04.SelectedIndex];
            CustomerIndex.Text = ListBox04.SelectedIndex.ToString(); ;
            CustomerID.Text = selectedCustomer.CustomerID;
            CustomerName.Text = selectedCustomer.ContactName;
            CustomerCity.Text = selectedCustomer.City;
        }
    }


}
