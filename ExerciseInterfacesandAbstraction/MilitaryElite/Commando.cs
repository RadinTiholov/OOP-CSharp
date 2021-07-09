using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : ISoldier, ISpecialisedSoldier
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string crop, params string[] missions)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Crop = crop;
            Missions = new List<Mission>();
            for (int i = 0; i < missions.Length; i = i +2)
            {
                string name = missions[i];
                string state = missions[i+1];
                try
                {
                    Missions.Add(new Mission(name, state));
                }
                catch (Exception)
                {

                }
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
        public List<Mission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}\nCorps: {Crop}\nMissions:");
            foreach (var mission in Missions)
            {
                text.AppendLine("  "+mission.ToString());
            }
            return text.ToString().Trim();
        }
    }
}
