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

namespace Lesson5
{
    /// <summary>
    /// Логика взаимодействия для NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        private dbCollector db = dbCollector.Init();
        private string oldUserName = String.Empty;
        private string oldDepartment = String.Empty;

        public NewEmployee(string department)
        {
            oldDepartment = department;
            InitializeComponent();
            cmbEmployeeDepartment.ItemsSource = db.getListDepartment();
        }

        public NewEmployee(string user,string department):this()
        {
            oldUserName = user;
            cmbEmployeeDepartment.SelectedItem = department;
            txtNewEmployee.Text = user;
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            db.
        }
    }
}
