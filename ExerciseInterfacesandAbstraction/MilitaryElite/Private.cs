using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : ISoldier
    {
        public Private(int id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
        }
    }
}
