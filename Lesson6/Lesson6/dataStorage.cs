using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    /// <summary>
    /// Класс для работы с данными
    /// </summary>
    class dataStorage
    {
        private ObservableCollection<Department> departments;

        public dataStorage()
        {
            departments = new ObservableCollection<Department>();
        }

        public void AddDepartment(Department newDepartment)
        {
            if (!departments.Contains(newDepartment))
            {
                departments.Add(newDepartment);
            }
        }

        public ObservableCollection<Department> Departments { get => this.departments; }
    }
}
