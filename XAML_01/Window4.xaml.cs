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

namespace XAML_01
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            
        }

        private static int orderCount = 0;

        private void UserControl1_OrderPlaced(object sender, EventArgs e)
        {
            orderCount++;
            lblResult.Content = string.Format("Order {0} Has Been Placed",orderCount);

        }

        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
