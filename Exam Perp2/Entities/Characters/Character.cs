using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public double BaseHealth { get; private set; }
        public double Health { get; set; }
        public double BaseArmor { get; private set; }
        public double Armor { get; private set; }
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; private set; }
        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
        public void TakeDamage(double hitPoints)
        {
            if (IsAlive || Health > 0)
            {
                if (hitPoints >= Armor)
                {
                    Health -= hitPoints - Armor;
                    Armor = 0;
                    if (Health <= 0)
                    {
                        Health = 0;
                        IsAlive = false;
                    }
                }
                else
                {
                    Armor -= hitPoints;
                }
            }
        }
        public void UseItem(Item item) 
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

    }
}