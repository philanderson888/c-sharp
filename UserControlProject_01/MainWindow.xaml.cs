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
using static System.Console;


namespace UserControlProject
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

        private void UserControl01_Loaded(object sender, RoutedEventArgs e)
        {
            WriteLine("User control 01 has loaded");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dothis(object sender, EventArgs e)
        {
            label01.Content = "user control has clicked";
            label01.Content += "\n\nSender object is\n\n";
            label01.Content += sender.ToString();
            label01.Content += "\n\nEventArgs array is \n\n";
            label01.Content += e.ToString();
            label01.Content += e.GetType().ToString();
            label01.Content += e.GetHashCode().ToString();
        }
    }
}
