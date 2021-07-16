using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Cat:Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        private const double weightPerByte = 0.30;
        public override string SayHello()
        {
            return "Meow";
        }
        public override void UpdateWeight(int quantity)
        {
            this.Weight += weightPerByte * quantity;
        }
    }
}
