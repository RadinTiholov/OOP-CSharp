using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarInfoBuilder:CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            this.Car = car;
        }

        public CarInfoBuilder WithType(string type) 
        {
            Car.Type = type;
            return this;
        }
        public CarInfoBuilder WithColor(string color)
        {
            Car.Color = color;
            return this;

        }
        public CarInfoBuilder WithDoors(int numberOfDoors)
        {
            Car.NumberOfDoors = numberOfDoors;
            return this;
        }
    }
}
