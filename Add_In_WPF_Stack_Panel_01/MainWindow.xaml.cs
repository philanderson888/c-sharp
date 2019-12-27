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

namespace lab_15_panels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Tracks which panel we are on
        int index;


        

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize() {
            index = 1;
            displayPanel(index);
        }
        private void ButtonChangePanel_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index == 4)
            {
                index = 1;
            }
            displayPanel(index);
        }
        void displayPanel(int index)
        {
            switch (index)
            {
                case 1:
                    StackPanel01.Visibility = Visibility.Visible;
                    StackPanel02.Visibility = Visibility.Collapsed;
                    StackPanel03.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    StackPanel01.Visibility = Visibility.Collapsed;
                    StackPanel02.Visibility = Visibility.Visible;
                    StackPanel03.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    StackPanel01.Visibility = Visibility.Collapsed;
                    StackPanel02.Visibility = Visibility.Collapsed;
                    StackPanel03.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ButtonChangeTab_Click(object sender, RoutedEventArgs e)
        {
            if (TabControl01.SelectedIndex < TabControl01.Items.Count-1)
            {
                TabControl01.SelectedIndex++;
            }
            else
            {
                TabControl01.SelectedIndex = 0;
            }
        }

        // enum is structure which maps names to numbers  
        // days of week   0=sunday 6=saturday
        // months 0=january
        // enum automatically sets first=0, second=1, third=2 (same as TabIndex)
        enum tabs
        {
            First,
            Second,
            Third
        }

        private void ButtonChangeTabByName_Click(object sender, RoutedEventArgs e)
        {
            ChangeTabByName((TabControl01.SelectedItem as TabItem).Header.ToString());
        }

        void ChangeTabByName(string headerName)
        {
            switch (headerName)
            {
                // if index is 0 ('first' tab) then change it to index = 1 ('second' tab)
                case "First":
                    TabControl01.SelectedIndex = (int)tabs.Second;
                    break;
                case "Second":
                    TabControl01.SelectedIndex = (int)tabs.Third;
                    break;
                case "Third":
                    TabControl01.SelectedIndex = (int)tabs.First;
                    break;
            }
        }
    }
}
