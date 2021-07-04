using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string[] doughInput = Console.ReadLine().Split();

            Dough dough = null;
            try
            {
                dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Pizza pizza = null;
            try
            {
                pizza = new Pizza(pizzaInput[1], dough);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                var spliteted = input.Split();
                if (spliteted[0] == "Topping")
                {
                    Topping toping = null;
                    try
                    {
                        toping = new Topping(spliteted[1], double.Parse(spliteted[2]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    try
                    {
                        pizza.AddTopping(toping);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
        }
    }
}
