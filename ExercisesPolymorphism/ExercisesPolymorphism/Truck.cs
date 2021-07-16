using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesPolymorphism
{
    public class Truck:Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) :base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }
            else if (liters + FuelQuantity > TankCapacity)
            {
                throw new Exception($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                liters = liters * 0.95;
                this.FuelQuantity += liters;
            }
        }
    }
}
