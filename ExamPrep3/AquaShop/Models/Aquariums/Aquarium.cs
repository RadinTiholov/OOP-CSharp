using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }
        private string name; 
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get;} 

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count < Capacity)
            {
                Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            if (Fish.Count == 0)
            {
                return "none";
            }
            else
            {
                StringBuilder text = new StringBuilder();
                text.AppendLine($"{ Name} ({this.GetType().Name}):");
                text.AppendLine($"Fish: ");
                if (Fish.Count > 0)
                {
                    int count = 0;
                    foreach (var fish in Fish)
                    {
                        if (count == 0)
                        {
                            text.Append($"{fish.Name}");
                        }
                        else
                        {
                            text.Append($", {fish.Name}");
                        }
                        count++;
                    }
                }
                else
                {
                    text.Append("none");
                }
                
                text.AppendLine($"Decorations: {Decorations.Count}");
                text.AppendLine($"Comfort: {Comfort}");
                return text.ToString().Trim();
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }

    }
}
