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

namespace Data_Binding_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Class01 instance02 = new Class01();
            instance02.Field01 = "Data for instance 2";
            instance02.Field02 = 22;

            Binding binding01 = new Binding();

            binding01.Source = instance02;

            binding01.Path = new PropertyPath("Name");

            StackPanel01.DataContext = instance02;

        }
        
    }

    public class Class01
    {
        public string Field01 { get; set; }
        public int Field02 { get; set; }
    }

}
