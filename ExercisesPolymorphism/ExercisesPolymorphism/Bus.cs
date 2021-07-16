using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesPolymorphism
{
    public class Bus:Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption => base.FuelConsumption + 1.4;
        
        public void DriveEmpty(double distance)
        {
            if (CanDrive(distance))
            {
                this.FuelQuantity -= distance * (FuelConsumption - 1.4);
            }
            else
            {
                throw new Exception("It doesn't have enough fuel!");
            }
        }
    }
}
