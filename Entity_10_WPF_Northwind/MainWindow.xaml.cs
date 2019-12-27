using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Entity_10_WPF_Northwind
{
    public partial class MainWindow : Window
    {
        // use this to hold the selected customer when manipulating
        Customer customer;

        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox01.SelectedItem != null)
            {
                // selected item is an object which we cast to Customer
                customer = (Customer)ListBox01.SelectedItem;
                // set the screen IDs
                TextId.Text = customer.CustomerID;
                TextName.Text = customer.ContactName;
                TextCity.Text = customer.City;
                // update and delete buttons now enabled
                ButtonUpdate.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
            }
        }

        private void PopulateListBox()
        {
            using (var db = new NorthwindEntities())
            {
                ListBox01.ItemsSource = db.Customers.ToList<Customer>();
            }
            ButtonUpdate.IsEnabled = false;
            ButtonDelete.IsEnabled = false;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                customer = db.Customers.Where(c => c.CustomerID == TextId.Text).FirstOrDefault();
                customer.ContactName = TextName.Text;
                customer.City = TextCity.Text;
                // write changes to database
                db.SaveChanges();
                // now clear out the screen items 
                ListBox01.SelectedItem = null;
                TextId.Text = null;
                TextName.Text = null;
                TextCity.Text = null;
                // refresh the list box
                ListBox01.ItemsSource = null;
                PopulateListBox();
                // put back the screen data
                ListBox01.SelectedItem = customer;
                TextId.Text = customer.CustomerID;
                TextName.Text = customer.ContactName;
                TextCity.Text = customer.City;
            }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                customer = db.Customers.Where(c => c.CustomerID == TextId.Text).FirstOrDefault();
                // remove customer from local copy of database
                db.Customers.Remove(customer);
                // write changes to database
                db.SaveChangesAsync();
                // refresh screen items
                ListBox01.SelectedItem = null;
                TextId.Text = null;
                TextName.Text = null;
                TextCity.Text = null;
                ListBox01.ItemsSource = null;
                PopulateListBox();
            }
        }
    }
}
