using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesPolymorphism
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}
