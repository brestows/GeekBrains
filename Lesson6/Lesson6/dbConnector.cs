using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class dbConnector
    {
        enum CSV { DEPARTMENT,FIO,AGE,SALARY}
        private readonly string dbFile = "company.csv";
        private dataStorage storage;
        private static int currentDepartment=0;
        public int CurrentDepartment { get => currentDepartment; set => currentDepartment = value; }
        public dataStorage ActiveStorage => this.storage;
        public ObservableCollection<Employee> Employees { get => storage.Departments[currentDepartment].Employees; }

        public dbConnector() {
            storage = new dataStorage();
            currentDepartment = 0;
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
