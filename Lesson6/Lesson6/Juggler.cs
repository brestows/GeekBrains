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
    /// <summary>
    /// Класс для обработки запросов то 
    /// GUI пользователя.
    /// </summary>
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

        /// <summary>
        /// Актуальный список отделов
        /// </summary>
        public ObservableCollection<Department> Departments => db.ActiveStorage.Departments;
        /// <summary>
        /// Актуальный список сотруднгиков активного отдела
        /// </summary>
        public ObservableCollection<Employee> Employee { 
            get => db.Employees;
            set {
                db.Employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employee)));
            }
        }
        /// <summary>
        /// Индекс активного отдела
        /// </summary>
        public int CurrentDepartment { get => db.CurrentDepartment; set => db.CurrentDepartment = value; }
        /// <summary>
        /// Удаляем сотрудника из отедла
        /// </summary>
        /// <param name="employee">Сотрудник которого надо удалить</param>
        internal void RemoveEmployee(Employee employee)
        {
            ActiveDepartment.RemoveEmployee(employee);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Departments)));
        }
        /// <summary>
        /// Активный отдел
        /// </summary>
        public Department ActiveDepartment => db.ActiveStorage.Departments[db.CurrentDepartment];
        /// <summary>
        /// Активный сотрудник
        /// </summary>
        public Employee ActiveEmployee { get; set; }
        /// <summary>
        /// Добавляем новый отдел
        /// </summary>
        /// <param name="name">Название нового отдела</param>
        public void AddDepartments(string name)
        {
            db.ActiveStorage.AddDepartment(new Department(name));

        }
        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="dp">Отдел который надо удалить</param>
        public void RemoveDepartments(Department dp)
        {
            db.ActiveStorage.RemoveDepartment(dp);
        }

        /// <summary>
        /// Добавляем новго сотрудника в отдел
        /// </summary>
        /// <param name="depName">Название отдела</param>
        /// <param name="emplName">ФИО сотрудника</param>
        /// <param name="emplSalary">Зарабатная плата</param>
        /// <param name="emplAge">Возраст</param>
        public void AddEmployee(string depName, string emplName, string emplSalary, int emplAge)
        {
            db.ActiveStorage.AddEmployee(depName, new Employee(emplName, emplSalary, emplAge));
            PropertyChanged?.Invoke(db, new PropertyChangedEventArgs(nameof(db.Employees)));
        }
        /// <summary>
        /// Добавляем новго сотрудника в отдел
        /// </summary>
        /// <param name="depName">Название отдела</param>
        /// <param name="newEmpl">Новый сотрудник сотрудника</param>
        public void AddEmployee(string depName, Employee newEmpl)
        {
            db.ActiveStorage.AddEmployee(depName, newEmpl);
            PropertyChanged?.Invoke(db, new PropertyChangedEventArgs(nameof(db.Employees)));
        }
        /// <summary>
        /// Сохраняем все данные на диск
        /// </summary>
        public void SaveData() => db.SaveData();
        /// <summary>
        /// Смена активного отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DepartmentChange(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndex > -1) {
                db.CurrentDepartment = (sender as ListView).SelectedIndex;
                Employee = db.ActiveStorage.Departments[db.CurrentDepartment].Employees;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employee)));
            }
        }
        /// <summary>
        /// Переносим пользователя из одного департамента в другой
        /// </summary>
        /// <param name="newDepartment">название нового департамента</param>
        /// <param name="newEmployee">Новые данные сотрудника</param>
        internal void MoveEmployee( string newDepartment, Employee newEmployee)
        {
            RemoveEmployee(newEmployee);
            AddEmployee(newDepartment, newEmployee);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Departments)));
        }
    }
}
