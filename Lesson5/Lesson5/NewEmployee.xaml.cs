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
        private bool isRename = false;
        public NewEmployee(string department)
        {
            oldDepartment = department;
            InitializeComponent();
            cmbEmployeeDepartment.ItemsSource = db.getListDepartment();
            db.itsOK += Close;
        }

        public NewEmployee(string user,string department):this(department)
        {
            oldUserName = user;
            isRename = true;
            cmbEmployeeDepartment.SelectedItem = department;
            txtNewEmployee.Text = user;
            btnNewEmployee.Content = "Сохранить";
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (isRename)
            {
                db.DeaprtmentRepalce(oldDepartment, cmbEmployeeDepartment.SelectedItem.ToString());
            }
            else
            {
                db.EmployeeAdd(cmbEmployeeDepartment.Text, txtNewEmployee.Text);
            }
        }
    }
}
