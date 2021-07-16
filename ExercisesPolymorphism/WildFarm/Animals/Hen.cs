using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Hen:Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        private const double weightPerByte = 0.35;
        public override string SayHello()
        {
            return "Cluck";
        }
        public override void UpdateWeight(int quantity)
        {
            this.Weight += weightPerByte * quantity;
        }
    }
}
