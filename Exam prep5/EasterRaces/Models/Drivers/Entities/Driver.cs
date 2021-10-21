using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        public Driver(string name)
        {
            Name = name;
            Car = null;
            NumberOfWins = 0;
            CanParticipate = false;
        }

        private string name;
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

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get 
            { 
                return Car!= null;
            }
            private set {}
        }


        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("Car cannot be null.");
            }
            this.Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
