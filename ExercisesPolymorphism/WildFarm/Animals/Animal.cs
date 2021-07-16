using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            FoodEaten = 0;
            Name = name;
            Weight = weight;
        }
        public string Name { get; internal set; }
        public double Weight { get; internal set; }
        public int FoodEaten { get; internal set; }
        public virtual void UpdateWeight( int quantity)//override for every class 
        {
            this.Weight += 1 * quantity;
        }
        public void UpdateEatenFood(int quantity)
        {
            this.FoodEaten += quantity;
        }
        public virtual string SayHello() 
        {
            return "hello";
        }
    }
}
