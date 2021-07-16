using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class Bird:Animal
    {
        public Bird(string name, double  weight, double wingSize):base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; internal set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, { WingSize}, { Weight}, { FoodEaten}]";
        }
    }
}
