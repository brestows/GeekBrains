using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    /// <summary>
    /// Класс описывающий сотрудника 
    /// </summary>
    class Employee
    {
        public string Name { get; set; }
        public string Salary { get; set; }
        public int Age { get; set; }
        private Employee() { }
        public Employee(string name, string salary, int age) {
            this.Name = name;
            this.Age = age;
            this.Salary = salary;
        }
    }
}
