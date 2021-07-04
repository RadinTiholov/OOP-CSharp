using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        private string type;
        private double weight;

        public double Weight
        {
            get { return weight; }
            private set 
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }


        public string Type
        {
            get { return type; }
            private set 
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    type = value;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                double modifier = 0;
                if (Type.ToLower() == "meat")
                {
                    modifier = 1.2;
                }
                else if (Type.ToLower() == "veggies")
                {
                    modifier = 0.8;
                }
                else if (Type.ToLower() == "cheese")
                {
                    modifier = 1.1;
                }
                else if (Type.ToLower() == "sauce")
                {
                    modifier = 0.9;
                }
                return modifier*2*Weight;
            }
        }

    }
}
