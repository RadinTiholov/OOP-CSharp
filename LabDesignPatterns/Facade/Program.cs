using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                .WithColor("Green").WithDoors(5).WithType("Porsh")
                .Address
                .AtAddress("DC, 3234")
                .InCity("Washington").Build();
            Console.WriteLine(car.ToString());
        }
    }
}
