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

namespace to_do_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeScreen();
        }
        void InitializeScreen()
        {
            using (var db = new PhilEntities())
            {
                var todos = db.Todoes.ToList<Todo>();
                foreach (var todo in todos)
                {
                    switch (todo.TaskID)
                    {
                        case 1:
                            LabelTask01.Content = todo.Task;
                            CheckBox01.IsChecked = todo.Done;
                            DatePicker01.SelectedDate = todo.DoneDate;
                            break;
                        case 2:
                            CheckBox02.IsChecked = todo.Done;
                            DatePicker02.SelectedDate = todo.DoneDate;
                            break;
                        case 3:
                            CheckBox03.IsChecked = todo.Done;
                            DatePicker03.SelectedDate = todo.DoneDate;
                            break;
                        case 4:
                            CheckBox04.IsChecked = todo.Done;
                            DatePicker04.SelectedDate = todo.DoneDate;
                            break;
                        case 5:
                            CheckBox05.IsChecked = todo.Done;
                            DatePicker05.SelectedDate = todo.DoneDate;
                            break;
                    }
                }
            }
        }

        private void CheckBox01_Checked(object sender, RoutedEventArgs e)
        {
            using (var db = new PhilEntities())
            {
                var task = db.Todoes.Where(t => t.TaskID == 1).FirstOrDefault();
                task.Done = !task.Done;
                db.SaveChanges();
            }
        }

        private void CheckBox02_Checked(object sender, RoutedEventArgs e)
        {
            using (var db = new PhilEntities())
            {
                var task = db.Todoes.Where(t => t.TaskID == 2).FirstOrDefault();
                task.Done = !task.Done;
                db.SaveChanges();
            }
        }

        private void CheckBox03_Checked(object sender, RoutedEventArgs e)
        {
            using (var db = new PhilEntities())
            {
                var task = db.Todoes.Where(t => t.TaskID == 3).FirstOrDefault();
                task.Done = !task.Done;
                db.SaveChanges();
            }
        }

        private void CheckBox04_Checked(object sender, RoutedEventArgs e)
        {
            using (var db = new PhilEntities())
            {
                var task = db.Todoes.Where(t => t.TaskID == 4).FirstOrDefault();
                task.Done = !task.Done;
                db.SaveChanges();
            }
        }

        private void CheckBox05_Checked(object sender, RoutedEventArgs e)
        {
            using (var db = new PhilEntities())
            {
                var task = db.Todoes.Where(t => t.TaskID == 5).FirstOrDefault();
                task.Done = !task.Done;
                db.SaveChanges();
            }
        }
    }
}
