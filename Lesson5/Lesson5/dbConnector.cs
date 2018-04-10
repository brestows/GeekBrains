using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    /// <summary>
    /// Класс своего рода хранитель данных 
    /// о сотрудниках и отделах компании
    /// для обучения используем патерн Singlton
    /// </summary>
    class dbCollector
    {
        private static dbCollector instance = null;
        private static Dictionary<string, List<Emplayee>> dicDepartment = new Dictionary<string, List<Emplayee>>();
        public  event Action itsOK;
        public  event Action< string> evDepartmentAdd;
        protected dbCollector() { }

        public static dbCollector Init()
        {
            if (instance == null)
            {
                instance = new dbCollector();
            }
            return instance;
        }

        /// <summary>
        /// Добавление нового департамента
        /// </summary>
        /// <param name="name">Название департамента.</param>
        public void DepartmentAdd(string name)
        {
            if (!dicDepartment.ContainsKey(name))
            {
                dicDepartment.Add(name, new List<Emplayee>());
                itsOK();
                evDepartmentAdd(name);
            }   
        }

        public void DeaprtmentRemove(string name)
        {
            dicDepartment.Remove(name);
        }

        public void DeaprtmentRepalce(string old, string _new)
        {
            if (dicDepartment.ContainsKey(old))
            {
                dicDepartment.Add(_new, dicDepartment[old]);
                dicDepartment.Remove(old);
                evDepartmentAdd(_new);
                itsOK();
            }
        }


        public void DepartmentAddEmployee(string departmentID, Emplayee obj)
        {
            if (dicDepartment.ContainsKey(departmentID))
            {
                dicDepartment[departmentID].Add(obj);
                itsOK();
            }
        }

        public List<string> getListDepartment()
        {
            return dicDepartment.Keys.ToList();
        }

        public List<string> getListEmployee()
        {
            return dicDepartment.Keys.ToList();
        }
    }
}
