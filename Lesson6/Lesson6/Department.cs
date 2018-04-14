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
    class Department: IEquatable<Department>, INotifyPropertyChanged
    {
        private ObservableCollection<Employee> employees;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public Department(string name) {
            this.Name = name;
            employees = new ObservableCollection<Employee>();
        }

        public int Count  => this.employees.Count;

        public ObservableCollection<Employee> Employees{
            get => this.employees;
            set
            {
                Juggler jg = Juggler.getInstance();
                employees = value;
                PropertyChanged?.Invoke(jg, new PropertyChangedEventArgs(nameof(this.Employees )));
            }
        }

        public void AddEmployee(Employee employee)
        {
            if (!this.employees.Contains(employee))
            {
                Console.WriteLine("user is write");
                this.employees.Add(employee);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employees)));
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

        public override string ToString()
        {
            return Name;
        }
    }
}
