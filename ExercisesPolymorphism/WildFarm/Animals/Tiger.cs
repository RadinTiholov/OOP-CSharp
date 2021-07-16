using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Tiger:Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        private const double weightPerByte = 1.00;
        public override string SayHello()
        {
            return "ROAR!!!";
        }
        public override void UpdateWeight(int quantity)
        {
            this.Weight += weightPerByte * quantity;
        }
    }
}
