using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : IPhone, INetSurfable
    {
        public string Call(string number)
        {
            if (number.All(char.IsNumber))
            {
                return $"Calling... {number}";
            }
            return "Invalid number!";
        }

        public string SurfTheWeb(string site)
        {
            if (site.Any(char.IsDigit))
            {
                return "Invalid URL!";
            }
            if (site.All(char.IsWhiteSpace))
            {
                return $"Browsing:!";
            }
            return $"Browsing:{" " + site}!";
        }
    }
}
