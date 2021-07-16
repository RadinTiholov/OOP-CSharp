using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Dog:Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        private const double weightPerByte = 0.40;
        public override string SayHello()
        {
            return "Woof!";
        }
        public override void UpdateWeight(int quantity)
        {
            this.Weight += weightPerByte * quantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
