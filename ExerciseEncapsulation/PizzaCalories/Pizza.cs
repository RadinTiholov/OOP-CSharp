using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            topppings = new List<Topping>();
        }
        private readonly List<Topping> topppings;
        private Dough dough;
        private string name;
        public double TotalCalories 
        {
            get 
            {
                double total = 0;
                total += this.dough.CaloriesPerGram;
                foreach (Topping topping in topppings)
                {
                    total += topping.CaloriesPerGram;
                }
                return total;
            }
        }
        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }

        public int ToppingsCount
        {
            get { return topppings.Count; }
            private set
            {
                if (topppings.Count > 10)
                {
                    throw new Exception("Number of toppings should be in range [0..10].");
                }
            }
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (topppings.Count >= 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            else
            {
                topppings.Add(topping);
            }
        }

    }
}
