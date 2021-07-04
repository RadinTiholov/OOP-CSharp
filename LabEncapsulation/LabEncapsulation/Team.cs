using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();

        }
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

       
        public string Name { get; private set; }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            return $"First team have {this.firstTeam.Count} players\nReserve team have {this.reserveTeam.Count} players";
        }

    }
}
