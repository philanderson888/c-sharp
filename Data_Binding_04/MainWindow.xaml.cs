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
using System.Collections.ObjectModel;

namespace Data_Binding_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            #region x

            InitializeComponent();

            Class01 instanc02 = new Class01("instance 02 data");
            Class01 instanc03 = new Class01("instance 03 data");
            Class01 instanc04 = new Class01("instance 04 data");

            var collection01 = new ObservableCollection<Class01>();
            collection01.Add(instanc02);
            collection01.Add(instanc03);
            collection01.Add(instanc04);

            listBox01.ItemsSource = collection01;


            #endregion x

#if true


#endif

        }
    }

    public class Class01{
        public string Field01 { get; set; }
        public int Field02 { get; set; }
        public Class01(string Field01){
            this.Field01 = Field01;
        }
    }

}
