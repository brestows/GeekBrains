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
using System.Windows.Shapes;

namespace Lesson6
{
    /// <summary>
    /// Логика взаимодействия для NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        private Juggler jg;
        public NewEmployee()
        {
            InitializeComponent();
            jg = Juggler.getInstance();
            cmbEmployeeDepartment.ItemsSource = jg.Departments;
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            jg.AddEmployee(cmbEmployeeDepartment.Text.ToString(), txtNewEmployee.Text, txtSalary.Text, Int32.Parse(txtAge.Text));
            Close();
        }
    }
}
