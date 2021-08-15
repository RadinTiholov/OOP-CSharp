using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        public string Username
        {
            get { return username; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value;
            }
        }

        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value;
            }
        }

        public ICar Car
        {
            get { return car; }
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            }
        }


        public bool IsAvailable()
        {
            return Car.FuelAvailable >= Car.FuelConsumptionPerRace;
        }

        public abstract void Race();
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"{this.GetType().Name}: {Username}");
            text.AppendLine($"--Driving behavior: {RacingBehavior}");
            text.AppendLine($"--Driving experience: {DrivingExperience}");
            text.AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");
            return text.ToString().Trim();
        }
    }
}
