using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    /// <summary>
    /// Класс для работы с данными
    /// </summary>
    class dataStorage : INotifyPropertyChanged
    {
        private static ObservableCollection<Department> departments;
        private static Department currentDepartment=null;

        public event PropertyChangedEventHandler PropertyChanged;

        public dataStorage()
        {
            departments = new ObservableCollection<Department>();
        }

        public void AddDepartment(Department newDepartment)
        {
            if (!departments.Contains(newDepartment))
            {
                departments.Add(newDepartment);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Departments)));
            }
        }

        public Department GetDepartment(string name)
        {
            return departments.Where(d => d.Name == name).FirstOrDefault();
        }

        public ObservableCollection<Department> Departments { get => departments; }
        public ObservableCollection<Employee> Employees { get => currentDepartment.Employees; }
        public Department CurrentDepartment { get => currentDepartment; set => currentDepartment = value; }

        public IEnumerator GetEnumerator()
        {
            foreach (Department dp in departments)
            {
                yield return (Department)dp;
            }
        }

        public void AddEmployee(string depName, Employee employee)
        {
            Department dep = GetDepartment(depName);
            if (departments.Contains(dep))
            {
                dep.AddEmployee(employee);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employees)));
            }
        }
    }
}
