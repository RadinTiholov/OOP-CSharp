using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;
        private IMap map;
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.Models.FirstOrDefault(x => x.VIN == carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            IRacer racer = null;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            racers.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            IRacer racerTwo = racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);
            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            //foreach (var item in racers.Models)
            //{
            //    if (item.Username == racerOneUsername)
            //    {
            //        racerOne = item;
            //    }
            //    else if (item.Username == racerTwoUsername)
            //    {
            //        racerTwo = item;
            //    }
            //}
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();
            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                text.AppendLine(racer.ToString());
            }
            return text.ToString().Trim();
        }
    }
}
