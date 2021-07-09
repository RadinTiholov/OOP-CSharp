using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer:ISoldier, ISpecialisedSoldier
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string crop, params string[] repairs)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Crop = crop;
            Repairs = new List<Repairs>();
            for (int i = 0; i < repairs.Length; i = i + 2)
            {
                string name = repairs[i];
                int hours = int.Parse(repairs[i + 1]);
                Repairs.Add(new Repairs(name, hours));
            }
        }
        private string crop;

        public string Crop
        {
            get { return crop; }
            private set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    crop = value;
                }
                else
                {
                    throw new Exception();
                }

            }
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public decimal Salary { get; private set; }
        public List<Repairs> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}\nCorps: {Crop}\nRepairs:");
            foreach (var repair in Repairs)
            {
                text.AppendLine("  " + repair.ToString());
            }
            return text.ToString().Trim();
        }
    }
}
