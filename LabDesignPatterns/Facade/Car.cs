using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class Car
    {
        public string  Type { get; set; }
        public string  Color { get; set; }
        public int NumberOfDoors { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Type} whit {Color} color, {NumberOfDoors} number of doors. Address => {Address}, {City}.";
        }
    }
}
