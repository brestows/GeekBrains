using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Juggler 
    {
        private static Juggler instance;
        private Juggler() { }
        private static dbConnector db;

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
        public ObservableCollection<Employee> Employee => db.ActiveStorage.Employees;

        public void AddDepartments()
        {
            db.ActiveStorage.AddDepartment(new Department("Sales Department"));
        }

        public void AddEmployee(string depName, string emplName, string emplSalary, int emplAge)
        {
            db.ActiveStorage.AddEmployee(depName, new Employee(emplName, emplSalary, emplAge));
        }

        public void SaveData() => db.SaveData();

    }
}
