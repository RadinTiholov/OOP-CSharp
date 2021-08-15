using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            var multiplierOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var multiplierTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            var racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * multiplierOne;
            var racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * multiplierTwo;
            racerOne.Race();
            racerTwo.Race();

            if (racerOneChance > racerTwoChance)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }

        }
    }
}