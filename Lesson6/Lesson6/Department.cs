using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Department: IEquatable<Department>
    {
        private ObservableCollection<Emplayee> Emplayees;
        public string Name { get; set; }
        public Department(string name) {
            this.Name = name;
            Emplayees = new ObservableCollection<Emplayee>();
        }

        public int Count  => this.Emplayees.Count;

        public bool Equals(Department other)
        {
            return this.Name == other.Name;
        }
    }
}
