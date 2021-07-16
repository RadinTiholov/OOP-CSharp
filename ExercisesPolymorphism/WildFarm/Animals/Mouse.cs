using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Mouse:Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        private const double weightPerByte = 0.10;
        public override string SayHello()
        {
            return "Squeak";
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
