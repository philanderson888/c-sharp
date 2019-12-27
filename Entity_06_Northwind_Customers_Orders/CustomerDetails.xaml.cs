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
using System.Windows.Shapes;
using _Project_02_Entity_CRUD_MultiWindow;

namespace _Project_02_Entity_CRUD_MultiWindow
{

    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : Window
    {
        static NorthwindEntities DBContext = new NorthwindEntities();
        public static Order orderSelected;
        public CustomerDetails()
        {
            InitializeComponent();

            var customer = MainWindow.customerInformation;
            NameLabel.Content = customer.ContactName;
            ListBox01.DisplayMemberPath = "OrderID";
            CustomerOrders(customer.CustomerID);
        }

        private void CustomerOrders(string customerID)
        {
            var customerOrders =
                from o in DBContext.Orders
                where o.CustomerID == customerID
                select o;

            ListBox01.ItemsSource = customerOrders.ToList<Order>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderSelected = ListBox01.SelectedItem as Order;
            OrderProducts mainWindow = new OrderProducts();
            mainWindow.Show();
        }
    }
}
