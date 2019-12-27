using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1
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
            RefreshData();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            ListBox01.ItemsSource = null;

            Task.Run(() => {
                Thread.Sleep(2000);
                ListBox01.Dispatcher.Invoke(() => {
                    ListBox01.ItemsSource = GetCustomers().ToList<Customer>();
                });
            });
        }

        private IQueryable<Customer> GetCustomers()
        {

            return
                from customer in DBContext.Customers
                select customer;

        }

        private async void btnAsyncRefresh_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;


            var t1 = Task<IQueryable<Customer>>.Run(() => {
                Thread.Sleep(2000);
                return GetCustomers();
            });

            // non-awaitable execution
            //    ListBox01.ItemsSource = t1.Result.ToList<Customer>();  // will hang the thread
            // Awaitable execution
            var output = await t1; // will not hang the thread
            ListBox01.ItemsSource = output.ToList<Customer>();




        }

        private async void btnCallback_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            await CallBackDemo(DisplayPeople);
        }

        private void DisplayPeople(People obj)
        {
            
        }

        private async Task CallBackDemo(Action<People> callback)
        {



        }

    }


    public class People : List<Customer>
    {
        
    }
}
