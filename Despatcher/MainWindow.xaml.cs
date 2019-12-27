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
using System.IO;

namespace Despatcher
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

        private async void Method01()
        {
            

            Label01.Content = "Label01 updated from Method01";
        }
        public void button01_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {

                Label01.Dispatcher.BeginInvoke(new Action(()=>Method01()));

            });

          //  await long running operation here
            //Task[] tasks = new Task[30];
            //for (int i = 0; i < tasks.Length - 1; i++)
            //{
            //    tasks[i] = Task.Run(() =>
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //        Label02.Content = i;
            //    });
            //}
            //tasks[29] = Task.Run(() =>
            //{

            //    int counter = 0;
            //    while (counter < 100)
            //    {
            //        Label02.Content = counter.ToString();
            //        counter++;
            //        System.Threading.Thread.Sleep(100);
            //    }
            //});

            //Task.WaitAny(tasks);



        }


    }
}
