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

namespace XAML_01
{
    /// <summary>
    /// Interaction logic for Window4UserControl1.xaml
    /// </summary>
    public partial class Window4UserControl1 : UserControl
    {
        public Window4UserControl1()
        {
            InitializeComponent();
        }

        private string beverage;
        private string milk;
        private string sugar;
        public string Order
        {
            get
            {
                return String.Format("{0}, {1}, {2}", beverage, milk, sugar);
            }
        }

        public event EventHandler<EventArgs> OrderPlaced;

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrderPlaced != null)  OrderPlaced(this, EventArgs.Empty);
            
        }
        private void radCoffee_Checked(object sender, RoutedEventArgs e)
        {
            beverage = "Coffee";
        }
        private void radTea_Checked(object sender, RoutedEventArgs e) { beverage = "Tea"; }
        private void radMilk_Checked(object sender, RoutedEventArgs e) { milk = "Milk"; }
        private void radNoMilk_Checked(object sender, RoutedEventArgs e) { milk = "No Milk"; }
        private void radSugar_Checked(object sender, RoutedEventArgs e) { sugar = "Sugar"; }
        private void radNoSugar_Checked(object sender, RoutedEventArgs e) { sugar = "No Sugar"; }
    }
}
