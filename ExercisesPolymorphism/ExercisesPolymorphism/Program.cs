using System;

namespace ExercisesPolymorphism
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carCommands = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carCommands[1]), double.Parse(carCommands[2]), double.Parse(carCommands[3]));
            string[] truckCommands = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckCommands[1]), double.Parse(truckCommands[2]), double.Parse(truckCommands[3]));
            string[] busCommands = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(busCommands[1]), double.Parse(busCommands[2]), double.Parse(busCommands[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                double comm = double.Parse(input[2]);
                if (input[0] == "Drive")
                {
                    if (input[1] == "Car")
                    {
                        try
                        {
                            car.Drive(comm);
                            Console.WriteLine($"Car travelled {comm} km");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (input[1] == "Truck")
                    {
                        try
                        {
                            truck.Drive(comm);
                            Console.WriteLine($"Truck travelled {comm} km");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                    else if (input[1] == "Bus")
                    {
                        try
                        {
                            bus.Drive(comm);
                            Console.WriteLine($"Bus travelled {comm} km");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                else if (input[0] == "Refuel")
                {
                    if (input[1] == "Car")
                    {
                        try
                        {
                            car.Refuel(comm);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (input[1] == "Truck")
                    {
                        try
                        {
                            truck.Refuel(comm);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (input[1] == "Bus")
                    {
                        try
                        {
                            bus.Refuel(comm);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (input[0] == "DriveEmpty")
                {
                    try
                    {
                        bus.DriveEmpty(comm);
                        Console.WriteLine($"Bus travelled {comm} km");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Bus needs refueling");
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
