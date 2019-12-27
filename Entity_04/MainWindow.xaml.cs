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

namespace Entity_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities DBContext = new NorthwindEntities();
        List<Customer> customerList = new List<Customer>();
        List<string> customerNameList = new List<string>();
        Dictionary<int, Customer> customerDictionaryList = new Dictionary<int, Customer>();

        int refreshCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
            populateListBox();
        }



        private void button01_Click(object sender, RoutedEventArgs e)
        {
            listBox01.Items.Clear();
            listBox01.Items.Add(refreshCounter.ToString());
            populateListBox();
            refreshCounter++;
        }



        private void button02_Click(object sender, RoutedEventArgs e)
        {
            filterByCity(textBox02.Text);
        }


        void populateListBox()
        {
            //create list of customers
            customerList =
                (from customer in DBContext.Customers
                select customer).ToList<Customer>();

            // create dictionary index of customers also so can easily 
            // find customer by the selected index of a list box selection
            // in listbox01 
            int index = 0;

            foreach(Customer c in customerList)
            {
                customerNameList.Insert(customerNameList.Count, c.ContactName);
                customerDictionaryList.Add(index, c);
                index++;
            }


            listBox01.ItemsSource = customerNameList;
                        
        }

        void filterByCity(string cityName)
        {
            listBox02.Items.Clear();
            if (cityName == "")
            {

                listBox02.Items.Add("City Name Must Not Be Blank");
            }
            else if (cityName == "Filter By City")
            {
                listBox02.Items.Add("Please enter city name in text box above");
                textBox02.Text = "";
            }
            else
            {
                var customers =
                from customer in DBContext.Customers
                where customer.City == cityName
                select customer;

                listBox02.Items.Add(string.Format("Customer List For City {0}", cityName));

                foreach (var customer in customers)
                {
                    listBox02.Items.Add(string.Format("{0} is from {1}", customer.ContactName, customer.City));
                }
            }

        }

        private void listBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox03.Text = listBox01.SelectedIndex.ToString();

            listBox03.Items.Clear();

            //find customer
            Customer selectedCustomer = customerDictionaryList[listBox01.SelectedIndex];

            listBox03.Items.Add(selectedCustomer.CustomerID);
            listBox03.Items.Add(selectedCustomer.ContactName);
            listBox03.Items.Add(selectedCustomer.Address);
            listBox03.Items.Add(selectedCustomer.City);
            listBox03.Items.Add(selectedCustomer.Country);


        }

        private void button03_Click(object sender, RoutedEventArgs e)
        {
            populateListBox();
        }
    }
}
