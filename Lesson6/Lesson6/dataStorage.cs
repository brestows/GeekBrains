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
        private Juggler jg = Juggler.getInstance();

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

        internal void RemoveDepartment(Department dp)
        {
            departments.Remove(dp);
            jg.CurrentDepartment--;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Departments)));
        }

        public ObservableCollection<Department> Departments { get => departments; }
        
        public IEnumerator GetEnumerator()
        {
            foreach (Department dp in departments)
            {
                yield return (Department)dp;
            }
        }

        internal void RenameDepartment(string name, string oldName)
        {
            Department dp =  GetDepartment(oldName);
            Console.WriteLine(dp.Name);
        }

        public void AddEmployee(string depName, Employee employee)
        {
            Department dep = GetDepartment(depName);
            if (departments.Contains(dep))
            {
                Console.WriteLine($"Department {dep.Name} is Found");
                dep.AddEmployee(employee);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(dep.Employees)));
                PropertyChanged?.Invoke(jg, new PropertyChangedEventArgs(nameof(jg.Departments)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Departments)));

            }
        }
    }
}
