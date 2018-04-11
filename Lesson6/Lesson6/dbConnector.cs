using System;
using System.Collections.Generic;
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
        enum CSV {
            DEPARTMENT,
            FIO,
            AGE,
            SALARY
        }
        private readonly string dbFile = "company.csv";
        private dataStorage storage;

        public dataStorage ActiveStorage => this.storage;

        public dbConnector() {
            storage = new dataStorage();
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
                        Department tmp = new Department(token[(int)CSV.DEPARTMENT]);

                        this.storage.AddDepartment(tmp);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Нет БД");
            }
        }

        public void SaveData()
        {

        }
    }
}
