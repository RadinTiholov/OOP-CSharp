using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        public Dough(string flourType, string bakingTecnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTecnique = bakingTecnique;
            this.Weight = weight;
        }
        private string flourType;
        private string bakingTecnique;
        private double weight;

        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    flourType = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }
        public string BakingTecnique
        {
            get { return bakingTecnique; }
            private set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    bakingTecnique = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                else
                {
                    weight = value;
                }
            }
        }
        public double CaloriesPerGram
        {
            get 
            {
                double firstModifier = 0;
                double secondModifier = 0;
                if (FlourType.ToLower() == "white")
                {
                    firstModifier = 1.5;
                }
                else if (FlourType.ToLower() == "wholegrain")
                {
                    firstModifier = 1;
                }
                if (BakingTecnique.ToLower() == "crispy")
                {
                    secondModifier = 0.9;
                }
                else if (BakingTecnique.ToLower() == "chewy")
                {
                    secondModifier = 1.1;
                }
                else if (BakingTecnique.ToLower() == "homemade")
                {
                    secondModifier = 1;
                }
                return (2*Weight)*firstModifier*secondModifier;
            }
        }


    }
}
