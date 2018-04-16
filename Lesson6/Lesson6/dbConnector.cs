using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    /// <summary>
    /// Обрабатываем данные ранее сохраненные 
    /// в файл 
    /// </summary>
    class dbConnector : INotifyPropertyChanged
    {
        enum CSV { DEPARTMENT,FIO,AGE,SALARY}
        private readonly string dbFile = "company.csv";
        //Строка подключения к БД
        private readonly string dbStringConnection =
            @"
                Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog=sc_demoLesson7.mdf;
                Integrated Security=True;
            ";
        private dataStorage storage;
        private static int currentIndexDepartment=0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int CurrentDepartment { get => currentIndexDepartment; set => currentIndexDepartment = value; }
        public dataStorage ActiveStorage => this.storage;

        public ObservableCollection<Employee> Employees {
            get => storage.Departments[currentIndexDepartment].Employees;
            set
            {
                storage.Departments[currentIndexDepartment].Employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employees)));
            }
        }

        public dbConnector() {
            storage = new dataStorage();
            currentIndexDepartment = 0;
        }

        public void InitializationDB()
        {
            try
            {
                var tbDepartment = @"CREATE TABLE [dbo].[department]
                                    (
	                                    [id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                                        [department_name] NVARCHAR(250) NOT NULL
                                    )";
                var tbEmployee= @"CREATE TABLE [dbo].[Employee]
                                (
	                                [id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                                    [departmentid] INT NOT NULL, 
                                    [username] NVARCHAR(250) NOT NULL, 
                                    [birthday] DATE NOT NULL, 
                                    [salary] INT NOT NULL, 
                                    CONSTRAINT [FK_Employee_ToDepartment] FOREIGN KEY (departmentid) REFERENCES department (id) 
                                )";

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(dbFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string data = sr.ReadLine();
                        string[] token = data.Split(';');
                        Department tmp = this.storage.GetDepartment(token[(int)CSV.DEPARTMENT]);
                        if (tmp != null)
                        {
                            tmp.AddEmployee(new Employee(
                                                    token[(int)CSV.FIO],
                                                    token[(int)CSV.SALARY],
                                                    Int32.Parse(token[(int)CSV.AGE])
                                                )
                                           );
                        } else
                        {
                            tmp = new Department(token[(int)CSV.DEPARTMENT]);
                            tmp.AddEmployee(new Employee(
                                token[(int)CSV.FIO],
                                token[(int)CSV.SALARY],
                                Int32.Parse(token[(int)CSV.AGE])
                                ));
                        }
                        this.storage.AddDepartment(tmp);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Файл не найден!");
            }
        }

        public void SaveData()
        {
            using (StreamWriter wrt = new StreamWriter(dbFile, false, Encoding.UTF8))
            {
                foreach (Department dp in storage)
                {
                    foreach (Employee emp in dp.Employees)
                    {
                        wrt.WriteLine("{0};{1};{2};{3};",
                            dp.Name,
                            emp.Name,
                            emp.Age,
                            emp.Salary
                            );
                    }
                }
            }
        }
    }
}
