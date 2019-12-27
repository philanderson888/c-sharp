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

namespace UserControlProject
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button01_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder(this, EventArgs.Empty);
        }
        public string x;
        public string Order
        {
            get { return x; }
            set { x = value; }

        }
        public event EventHandler<EventArgs> PlaceOrder;
    }
}
