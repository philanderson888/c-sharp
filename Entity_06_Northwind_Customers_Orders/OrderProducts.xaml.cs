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
    /// Interaction logic for OrderProducts.xaml
    /// </summary>
    public partial class OrderProducts : Window
    {
        static NorthwindEntities DBContext = new NorthwindEntities();
        public OrderProducts()
        {
            InitializeComponent();
            ListBox01.DisplayMemberPath = "ProductName";
            CustomerProducts(CustomerDetails.orderSelected.OrderID);
        }

        private void CustomerProducts(int orderID)
        {
            var customerOrders =
                from p in DBContext.Products
                join od in DBContext.Order_Details on p.ProductID equals od.ProductID
                join o in DBContext.Orders on od.OrderID equals o.OrderID
                where o.OrderID == orderID
                select p;

            ListBox01.ItemsSource = customerOrders.ToList<Product>();
        }
    }
}
