using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral:ISoldier
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, params Private[] idsOfPrivates)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Privates = new List<Private>(idsOfPrivates);
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public decimal Salary { get; private set; }
        public List<Private> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}\nPrivates:");
            foreach (var privateA in Privates)
            {
                text.AppendLine("  "+ privateA.ToString());
            }
            return text.ToString().Trim();
        }


    }
}
