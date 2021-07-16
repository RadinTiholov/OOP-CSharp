using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public abstract class Employee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public virtual string Information() 
        {
            return Name;
        }
    }
}
