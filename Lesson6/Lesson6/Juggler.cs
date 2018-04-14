using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lesson6
{
    class Juggler : INotifyPropertyChanged
    {
        private static Juggler instance;
        private Juggler() { }
        private static dbConnector db;

        public event PropertyChangedEventHandler PropertyChanged;

        public static Juggler getInstance()
        {
            if (instance == null)
            {
                instance = new Juggler();
                db = new dbConnector();
                db.LoadData();
            }
            return instance;
        }

        public ObservableCollection<Department> Departments => db.ActiveStorage.Departments;
        //public ObservableCollection<Employee> Employee => db.Employees;
        public ObservableCollection<Employee> Employee { 
            get => db.Employees;
            set {
                db.Employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employee)));
            }
        }
        public int CurrentDepartment => db.CurrentDepartment;
        public Department ActiveDepartment => db.ActiveStorage.Departments[db.CurrentDepartment];

        public void AddDepartments(string name)
        {
            db.ActiveStorage.AddDepartment(new Department(name));

        }

        public void RemoveDepartments(Department dp)
        {
            db.ActiveStorage.RemoveDepartment(dp);
        }

        public void AddEmployee(string depName, string emplName, string emplSalary, int emplAge)
        {
            db.ActiveStorage.AddEmployee(depName, new Employee(emplName, emplSalary, emplAge));
            PropertyChanged?.Invoke(db, new PropertyChangedEventArgs(nameof(db.Employees)));
        }

        public void SaveData() => db.SaveData();

        public void DepartmentChange(object sender, SelectionChangedEventArgs e)
        {
            db.CurrentDepartment = (sender as ListView).SelectedIndex;
            Employee = db.ActiveStorage.Departments[db.CurrentDepartment].Employees;
        }
    }
}
