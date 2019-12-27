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
using System.Collections.Generic;

namespace Entity_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities DBContext = new NorthwindEntities();
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
            var customers =
                (from customer in DBContext.Customers
                 select customer).ToList<Customer>();

            listBox01.Items.Add("Customer List");

            foreach (var customer in customers)
            {
                listBox01.Items.Add(string.Format("{0} is from {1}", customer.ContactName, customer.City));
            }
        }

        void filterByCity(string cityName)
        {
            listBox02.Items.Clear();
            if (cityName=="") {
                
                listBox02.Items.Add("City Name Must Not Be Blank");
            }
            else if (cityName=="Filter By City"){
                listBox02.Items.Add("Please enter city name in text box above");
                textBox02.Text = "";
            }
            else
            {
                var customers =
                    (from customer in DBContext.Customers
                        where customer.City == cityName
                        select customer).ToList<Customer>();

                listBox02.Items.Add(string.Format("Customer List For City {0}", cityName));

                foreach (var customer in customers)
                {
                    listBox02.Items.Add(string.Format("{0} is from {1}", customer.ContactName, customer.City));
                }
            }

        }

        private void listBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = listBox01.SelectedItem;
            
        }
    }
}
