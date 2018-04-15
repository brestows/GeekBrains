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
            lstDepartmentView.SelectionChanged += jg.DepartmentChange;
            lstEmployeeView.ItemsSource = jg.Employee;
            this.Closing += delegate { jg.SaveData(); };
        }

        private void RemoveDepartment(object sender, RoutedEventArgs e)
        {
            jg.RemoveDepartments(lstDepartmentView.SelectedItem as Department);
        }

        private void RemoveEmployee(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Try remove employee");
            jg.RemoveEmployee(lstEmployeeView.SelectedItem as Employee);
        }


        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            NewEmployee employee = new NewEmployee();
            employee.ShowDialog();
        }

        private void btnNewDepartment_Click(object sender, RoutedEventArgs e)
        {
            NewDepartment department = new NewDepartment();
            department.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewDepartment department = new NewDepartment(true);
            department.ShowDialog();
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            jg.ActiveEmployee = lstEmployeeView.SelectedItem as Employee;
            NewEmployee employee = new NewEmployee(true);
            employee.ShowDialog();
        }
    }
}
