using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Owl:Bird
    {
        public Owl(string name, double weight, double wingSize):base(name, weight, wingSize)
        {

        }

        private const double weightPerByte = 0.25;
        public override string SayHello()
        {
            return "Hoot Hoot";
        }

        public override void UpdateWeight(int quantity)
        {
            this.Weight += weightPerByte * quantity;
        }
    }
}
