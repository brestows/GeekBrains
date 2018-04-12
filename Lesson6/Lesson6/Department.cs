using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Department: IEquatable<Department>
    {
        private ObservableCollection<Employee> employees;
        public string Name { get; set; }
        public Department(string name) {
            this.Name = name;
            employees = new ObservableCollection<Employee>();
        }

        public int Count  => this.employees.Count;

        public ObservableCollection<Employee> Employees{ get => this.employees; }

        public void AddEmployee(Employee employee)
        {
            if (!this.employees.Contains(employee))
            {
                this.employees.Add(employee);
            }
        }

        public bool Equals(Department other)
        {
            return this.Name == other.Name;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Employee empl in employees)
            {
                yield return (Employee)empl;
            }
        }
    }
}
