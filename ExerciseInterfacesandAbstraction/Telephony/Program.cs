using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");
            string[] webSites = Console.ReadLine().Split(" ");
            var smartPhone = new Smartphone();
            var statPhone = new StationaryPhone();
            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    Console.WriteLine(statPhone.Call(number));
                }
                else if (number.Length == 10)
                {
                    Console.WriteLine(smartPhone.Call(number));
                }
            }
            foreach (var site in webSites)
            {
                Console.WriteLine(smartPhone.SurfTheWeb(site));
            }
        }
    }
}
