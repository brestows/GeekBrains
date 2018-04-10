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

namespace Lesson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private dbCollector db = dbCollector.Init();
        public MainWindow()
        {
            InitializeComponent();
            db.evDepartmentAdd += UpdateListDepartment;
        }

        private void UpdateListDepartment(string obj)
        {
            lstDepartment.Items.Clear();
            foreach(string itm in db.getListDepartment())
                lstDepartment.Items.Add(itm);
        }

        private void btnDeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
           if (lstDepartment.SelectedIndex > -1)
            {
                lstDepartment.Items.RemoveAt(lstDepartment.SelectedIndex);
            }
        }
        /// <summary>
        /// Обработка события добавления нового отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewDepartment_Click(object sender, RoutedEventArgs e)
        {
            NewDepartment frm = new NewDepartment();
            frm.ShowDialog();
        }

        private void lstDepartment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NewDepartment frm = new NewDepartment(lstDepartment.SelectedItem.ToString());
            frm.ShowDialog();
        }

        private void lstEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NewEmployee frm = new NewEmployee(lstEmployee.SelectedItem.ToString(), lstDepartment.SelectedItem.ToString());
            frm.ShowDialog();
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            NewEmployee frm = new NewEmployee();
            frm.ShowDialog();
        }
    }
}
