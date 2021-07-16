using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesPolymorphism
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            internal set 
            {
                if (value <= TankCapacity && value > 0)
                {
                    fuelQuantity = value;
                }
                else
                {
                    fuelQuantity = 0;
                }
            }
        }

       
        public double TankCapacity { get; internal set; }

        public virtual double FuelConsumption  { get; }
        public virtual void Refuel(double liters) 
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
                this.FuelQuantity += liters;
            }
        }
        public void Drive(double distance) 
        {
            if (CanDrive(distance))
            {
                this.FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                throw new Exception("It doesn't have enough fuel!");
            }
        }

        internal bool CanDrive(double distance)
        {
            if (distance * FuelConsumption <= FuelQuantity)
            {
                return true;
            }
            return false;
        }
    }
}
