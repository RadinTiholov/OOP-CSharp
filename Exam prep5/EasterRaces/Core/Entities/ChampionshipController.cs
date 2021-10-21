using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController: IChampionshipController
    {
        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driveRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IDriver> driveRepository;
        private readonly IRepository<IRace> raceRepository;
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driveRepository.GetByName(driverName);
            ICar car = this.carRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);

        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = driveRepository.GetByName(driverName);
            IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return $"Driver {driver.Name} added in {race.Name} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (carRepository.GetAll().ToList().Contains(car))
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            else
            {
                carRepository.Add(car);
                return $"{car.GetType().Name} {model} is created.";
            }
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (driveRepository.GetAll().ToList().Contains(driver))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            else
            {
                driveRepository.Add(driver);
                return $"Driver {driverName} is created.";
            }
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (raceRepository.GetAll().ToList().Contains(race))
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            else
            {
                raceRepository.Add(race);
                return $"Race {name} is created.";
            }
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetAll().ToList().Any(x => x.Name == raceName) == false)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IRace race = raceRepository.GetByName(raceName);
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            List<IDriver> secondCollection = driveRepository.GetAll().OrderByDescending(x => x.Car.CubicCentimeters).Where(x => x.CanParticipate).ToList();
            IDriver firstDriver = secondCollection[0];
            IDriver secondDriver = secondCollection[1];
            IDriver thirdDriver = secondCollection[2];

            driveRepository.Remove(firstDriver);
            firstDriver.WinRace();
            driveRepository.Add(firstDriver);

            raceRepository.Remove(race);

            StringBuilder text = new StringBuilder();
            text.AppendLine($"Driver {firstDriver.Name} wins {raceName} race.");
            text.AppendLine($"Driver {secondDriver.Name} is second in {raceName} race.");
            text.AppendLine($"Driver {thirdDriver.Name} is third in {raceName} race.");
            return text.ToString().Trim();
        }
    }
}
