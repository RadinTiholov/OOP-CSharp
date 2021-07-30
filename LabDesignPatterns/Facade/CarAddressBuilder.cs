using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarAddressBuilder:CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            this.Car = car;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }
        public CarAddressBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }
    }
}
