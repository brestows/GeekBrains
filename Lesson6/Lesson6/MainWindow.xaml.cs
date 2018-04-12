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

namespace Lesson6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Juggler jg;
        public MainWindow()
        {
            InitializeComponent();
            jg = Juggler.getInstance();
            lstDepartmentView.ItemsSource = jg.Departments;
            lstEmployeeView.ItemsSource = jg.Employee;
            this.Closing += delegate { jg.SaveData(); };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            jg.AddDepartments();
        }

        private void RemoveDepartment(object sender, RoutedEventArgs e)
        {
            lstDepartmentView.Items.RemoveAt(lstDepartmentView.SelectedIndex);
            //lstDepartmentView.ItemsSource
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            NewEmployee employee = new NewEmployee();
            employee.ShowDialog();
        }
    }
}
