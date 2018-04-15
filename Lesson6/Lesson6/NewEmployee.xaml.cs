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
        private bool edit = false;
        /// <summary>
        /// Тут храним данные до редактирования
        /// </summary>
        private Employee tmp;

        private string oldDepartment = String.Empty;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="edit">True если формаоткрыта для 
        /// редактирования сотрудника, иначе false</param>
        public NewEmployee(bool edit = false)
        {
            InitializeComponent();
            jg = Juggler.getInstance();
            cmbEmployeeDepartment.ItemsSource = jg.Departments;
            if (edit)
            {
                this.edit = edit;
                txtAge.DataContext = jg.ActiveEmployee;
                txtNewEmployee.DataContext = jg.ActiveEmployee;
                txtSalary.DataContext = jg.ActiveEmployee;
                cmbEmployeeDepartment.SelectedItem = jg.ActiveDepartment;
                this.Title = "Изменение сотрудника";
                btnNewEmployee.Content = "Сохранить";
                this.Activated += NewEmployee_Activated;
             

            }
        }
        /// <summary>
        /// Сохраняем данные о сотруднике до 
        /// их изменения
        /// </summary>
        /// <param name="sender">Отправитель сигнала</param>
        /// <param name="e">Данные события</param>
        private void NewEmployee_Activated(object sender, EventArgs e)
        {
            tmp = new Employee(txtNewEmployee.Text, txtSalary.Text, Int32.Parse(txtAge.Text));
            oldDepartment = cmbEmployeeDepartment.Text.ToString();
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {

            if (!edit)
            {
                jg.AddEmployee(
                    cmbEmployeeDepartment.Text.ToString(), 
                    txtNewEmployee.Text, 
                    txtSalary.Text, 
                    Int32.Parse(txtAge.Text));
            } else
            {
                if (oldDepartment != cmbEmployeeDepartment.Text.ToString())
                {
                    Employee newEmployee = new Employee(txtNewEmployee.Text, txtSalary.Text, Int32.Parse(txtAge.Text));
                    if (tmp.Equals(newEmployee)) {
                        jg.MoveEmployee(cmbEmployeeDepartment.Text.ToString(),tmp);
                    } else
                    {
                        jg.MoveEmployee(cmbEmployeeDepartment.Text.ToString(),newEmployee);
                    }
                }
            }
            Close();
        }
    }
}
