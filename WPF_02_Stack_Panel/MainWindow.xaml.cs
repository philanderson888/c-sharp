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

namespace WPF_02_Stack_Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeToPanel1(object sender, EventArgs e)
        {
            StackPanel01.Visibility = Visibility.Visible;
            StackPanel02.Visibility = Visibility.Hidden;
            StackPanel03.Visibility = Visibility.Hidden;
        }

        private void ChangeToPanel2(object sender, EventArgs e)
        {
            StackPanel01.Visibility = Visibility.Hidden;
            StackPanel02.Visibility = Visibility.Visible;
            StackPanel03.Visibility = Visibility.Hidden;
        }

        private void ChangeToPanel3(object sender, EventArgs e)
        {
            StackPanel01.Visibility = Visibility.Hidden;
            StackPanel02.Visibility = Visibility.Hidden;
            StackPanel03.Visibility = Visibility.Visible;
        }
    }
}
