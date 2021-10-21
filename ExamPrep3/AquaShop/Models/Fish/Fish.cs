using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }
        private string name;
        private string species;
        private decimal price;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                name = value;
            }
        }
        public string Species
        {
            get { return species; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }
                species = value;
            }
        }
        public int Size { get; protected set; }
        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }
                price = value;
            }
        }

        public abstract void Eat();
    }
}
