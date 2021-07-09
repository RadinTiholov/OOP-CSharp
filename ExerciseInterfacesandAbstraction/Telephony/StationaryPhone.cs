using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public string Call(string number)
        {
            if (number.All(char.IsNumber))
            {
                return $"Dialing... {number}";
            }
            return "Invalid number!";
        }
    }
}
