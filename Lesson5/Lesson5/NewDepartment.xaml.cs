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
    /// Логика взаимодействия для NewDepartment.xaml
    /// </summary>
    public partial class NewDepartment : Window
    {
        private dbCollector db = dbCollector.Init();
        private bool editor = false;
        private string rename = String.Empty;
        public NewDepartment()
        {
            InitializeComponent();
            dbCollector db = dbCollector.Init();
            db.itsOK += Close;
        }

        public NewDepartment(string name):this()
        {
            rename = name;
            txtNewDepartment.Text = name;
            btnNewDepartment.Content = "Сохранить";
            editor = true;
        }

        private void btnNewDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewDepartment.Text != String.Empty) {
                if (editor)
                {
                    db.DeaprtmentRepalce(rename, txtNewDepartment.Text);
                }
                else
                {
                    db.DepartmentAdd(txtNewDepartment.Text);
                }
            }
        }
    }
}
