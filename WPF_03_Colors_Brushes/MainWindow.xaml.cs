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

namespace WPF_03_Colors_Brushes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        void Initialise()
        {
            Button01.Background = Brushes.AliceBlue;
            Button02.Background = (SolidColorBrush)Brushes.Aqua;
            Button03.Background = Brushes.LightSteelBlue;
        }

        private void any_button_click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            byte R;
            byte G;
            byte B;

            R = (byte)random.Next(255);
            G = (byte)random.Next(255);
            B = (byte)random.Next(255);
            var button01RandomBrush = new SolidColorBrush(Color.FromArgb(255, R,G,B));
            R = (byte)random.Next(255);
            G = (byte)random.Next(255);
            B = (byte)random.Next(255);
            var button02RandomBrush = new SolidColorBrush(Color.FromArgb(255, R, G, B));
            R = (byte)random.Next(255);
            G = (byte)random.Next(255);
            B = (byte)random.Next(255);
            var button03RandomBrush = new SolidColorBrush(Color.FromArgb(255, R, G, B));

            Button01.Background = button01RandomBrush;
            Button02.Background = button02RandomBrush;
            Button03.Background = button03RandomBrush;

        }

        
    }
}
