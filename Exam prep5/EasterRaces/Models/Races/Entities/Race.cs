using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            Drivers = new List<IDriver>();
        }
        private string name;
        private int laps;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }
        public int Laps
        {
            get { return laps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers { get; private set; }

        public void AddDriver(IDriver driver)
        {

            List<IDriver> secondCollection = Drivers.ToList();
            if (driver.Equals(null))
            {
                throw new ArgumentException("Driver cannot be null.");
            }
            if (driver.CanParticipate == false)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }
            if (secondCollection.Contains(driver))
            {
                throw new ArgumentNullException($"Driver {driver.Name} is already added in {name} race.");
            }
            secondCollection.Add(driver);
            Drivers = secondCollection;
        }
    }
}
