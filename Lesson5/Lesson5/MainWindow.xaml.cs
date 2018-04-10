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
            foreach(string itm in db.getListDepartment()) {
                ListBoxItem it = new ListBoxItem();
                it.Content = itm;
                it.Selected += lstDepartment_MouseLeftButtonDown;
                lstDepartment.Items.Add(it);
            }
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
            if (lstDepartment.Items.Count > 0 && lstDepartment.SelectedItem.ToString() != String.Empty)
            {
                NewDepartment frm = new NewDepartment(lstDepartment.SelectedItem.ToString());
                frm.ShowDialog();
            }
        }

        private void lstEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstDepartment.Items.Count > 0 && lstDepartment.SelectedItem.ToString() != String.Empty)
            {
                NewEmployee frm = new NewEmployee(lstEmployee.SelectedItem.ToString(), lstDepartment.SelectedItem.ToString());
                frm.ShowDialog();
            }
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (lstDepartment.Items.Count > 0 && lstDepartment.SelectedItem.ToString() != String.Empty)
            {
                NewEmployee frm = new NewEmployee(lstDepartment.SelectedItem.ToString());
                frm.ShowDialog();
            }
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (lstEmployee.SelectedIndex > -1)
            {
                lstEmployee.Items.RemoveAt(lstEmployee.SelectedIndex);
            }
        }

        private void lstDepartment_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            lstEmployee.Items.Clear();
            ListBoxItem lbi = e.Source as ListBoxItem;
            foreach (string itm in db.getListEmployee(lbi.Content.ToString()))
                lstEmployee.Items.Add(itm);

        }
    }
}
