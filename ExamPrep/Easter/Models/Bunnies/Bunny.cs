using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            Dyes = new List<IDye>();
        }
        private string name;
        private int energy;

        public string Name
        {
            get { return name; }
            protected set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }
        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = value;
                }
            }
        }
        public ICollection<IDye> Dyes { get; protected set; }

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
            if (Energy <  0)
            {
                Energy = 0;
            }
        }
    }
}
