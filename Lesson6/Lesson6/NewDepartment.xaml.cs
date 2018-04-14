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
    /// Логика взаимодействия для NewDepartment.xaml
    /// </summary>
    public partial class NewDepartment : Window
    {
        private Juggler jg;
        private bool edit = false;
        private string oldName = String.Empty;
        public NewDepartment(bool edit=false)
        {
            InitializeComponent();
            jg = Juggler.getInstance();
            if (edit)
            {
                Console.WriteLine("edit data");
                this.edit = edit;
                txtNewDepartment.DataContext = jg.ActiveDepartment;
                this.Activated += NewDepartment_Activated;
                this.oldName = txtNewDepartment.Text;
                this.Title = "Переименовать";
                btnNewDepartment.Content = "Сохранить";
            }
        }

        private void NewDepartment_Activated(object sender, EventArgs e)
        {
            this.oldName = txtNewDepartment.Text;
        }

        private void btnNewDepartment_Click(object sender, RoutedEventArgs e)
        {
            jg.AddDepartments(txtNewDepartment.Text);
            Close();
        }
    }
}
