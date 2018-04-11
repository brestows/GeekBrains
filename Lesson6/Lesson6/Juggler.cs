using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Juggler
    {
        private dbConnector db;
        public Juggler()
        {
            db = new dbConnector();
            db.LoadData();
        }

        public ObservableCollection<Department> Departments => db.ActiveStorage.Departments;

        public void AddDepartments()
        {
            db.ActiveStorage.AddDepartment(new Department("Sales Department"));
        }


    }
}
