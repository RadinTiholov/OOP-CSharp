using System;
using System.Collections.Generic;
using WildFarm.Animals;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string animalInput = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (animalInput != "End")
            {
                Animal animal = null;
                var splittedAnimal = animalInput.Split();
                string type = splittedAnimal[0];
                List<string> foods = null;
                if (type == "Owl")
                {
                    animal = new Owl(splittedAnimal[1], double.Parse(splittedAnimal[2]),double.Parse(splittedAnimal[3]));
                    foods = new List<string>() { "Meat" };
                }
                else if (type == "Hen")
                {
                    animal = new Hen(splittedAnimal[1], double.Parse(splittedAnimal[2]), double.Parse(splittedAnimal[3]));
                    foods = new List<string>() { "Vegetable", "Fruit", "Meat", "Seeds" };
                }
                else if (type == "Mouse")
                {
                    animal = new Mouse(splittedAnimal[1], double.Parse(splittedAnimal[2]), splittedAnimal[3]);
                    foods = new List<string>() { "Vegetable", "Fruit" };
                }
                else if (type == "Dog")
                {
                    animal = new Dog(splittedAnimal[1], double.Parse(splittedAnimal[2]), splittedAnimal[3]);
                    foods = new List<string>() { "Meat" };
                }
                else if (type == "Cat")
                {
                    animal = new Cat(splittedAnimal[1], double.Parse(splittedAnimal[2]), splittedAnimal[3], splittedAnimal[4]);
                    foods = new List<string>() { "Vegetable", "Meat"};
                }
                else if (type == "Tiger")
                {
                    animal = new Tiger(splittedAnimal[1], double.Parse(splittedAnimal[2]), splittedAnimal[3], splittedAnimal[4]);
                    foods = new List<string>() { "Meat" };
                }
                Console.WriteLine(animal.SayHello());
                
                //
                string[] splittedFood = Console.ReadLine().Split();
                string foodType = splittedFood[0];
                int quantuty = int.Parse(splittedFood[1]);
                if (foods.Contains(foodType))
                {
                    animal.UpdateWeight(quantuty);
                    animal.UpdateEatenFood(quantuty);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                }
                animals.Add(animal);
                animalInput = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
