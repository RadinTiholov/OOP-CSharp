using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private Stack<Item> itemPool;
		public WarController()
		{
			party = new List<Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			if (characterType == "Warrior" || characterType == "Priest")
			{
				switch (characterType)
				{
					case ("Warrior"):
						party.Add(new Warrior(name));
						break;
					case ("Priest"):
						party.Add(new Priest(name));
						break;
				}

				return $"{name} joined the party!";
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
			}
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			if (itemName == "FirePotion" || itemName == "HealthPotion")
            {
				switch (itemName)
				{
					case ("FirePotion"):
						itemPool.Push(new FirePotion());
						break;
					case ("HealthPotion"):
						itemPool.Push(new HealthPotion());
						break;
				}

				return $"{itemName} added to pool.";
			}
            else
            {
				throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
            }
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
            if (party.Any(x => x.Name == characterName))
            {
                if (itemPool.Count > 0)
                {
					int index = 0;
                    for (int i = 0; i < party.Count; i++)
                    {
                        if (party[i].Name == characterName)
                        {
							index = i;
                        }
                    }
					string itemName = itemPool.Peek().GetType().Name;
					party[index].Bag.AddItem(itemPool.Pop());

					return $"{characterName} picked up {itemName}!";
				}
                else
                {
					throw new ArgumentException(ExceptionMessages.ItemPoolEmpty);
                }
            }
            else
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			if (party.Any(x => x.Name == characterName))
			{
                if (itemName == "FirePotion" || itemName == "HealthPotion")
                {
					Item item = null;
					switch (itemName)
					{
						case ("FirePotion"):
							item = new FirePotion();
							break;
						case ("HealthPotion"):
							item = new HealthPotion();
							break;
					}

					foreach (var character in party)
					{
						if (character.Name == characterName)
						{
							character.UseItem(item);
						}
					}
					return $"{characterName} used {itemName}.";
				}
                else
                {
					throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
                }
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
			}
		}

		public string GetStats()
		{
			StringBuilder text = new StringBuilder();
            foreach (var character in party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
				string aliveOrDead = "";
                if (character.IsAlive)
                {
					aliveOrDead = "Alive";
                }
                else
                {
					aliveOrDead = "Dead";
                }
				text.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {aliveOrDead}");
            }
			return text.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string recieverName = args[1];
            if (attackerName == recieverName)
            {
				throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
			}
            if (party.Any(x => x.Name == attackerName))
            {
				if (party.Any(x => x.Name == recieverName))
				{
					Character attacker = null;
					Character reciever = null;
					int attackerIndex = 0;
					int receiverIndex = 0;
                    for (int i = 0; i < party.Count; i++)
                    {
                        if (party[i].Name == attackerName)
                        {
							attacker = party[i];
							attackerIndex = i;
                        }
                        else if(party[i].Name == recieverName)
                        {
							reciever = party[i];
							receiverIndex = i;
                        }
                    }
                    if (attacker.GetType().Name == "Warrior")
                    {
						Warrior warrior = attacker as Warrior;
						warrior.Attack(reciever);
						attacker = warrior;
						party[attackerIndex] = attacker;
						party[receiverIndex] = reciever;

						StringBuilder output = new StringBuilder();
						output.AppendLine($"{attackerName} attacks {recieverName} for {attacker.AbilityPoints} hit points! {recieverName} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!");
                        if (!reciever.IsAlive)
                        {
							output.AppendLine($"{recieverName} is dead!");
                        }
						return output.ToString().Trim();
                    }
                    else
                    {
						throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
                    }
				}
				else
				{
					throw new ArgumentException(ExceptionMessages.CharacterNotInParty, recieverName);
				}
			}
            else
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
			}
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healerRecieverName = args[1];

			if (party.Any(x => x.Name == healerName))
			{
				if (party.Any(x => x.Name == healerRecieverName))
				{
					Character healer = null;
					Character receiver = null;
					int healerIndex = 0;
					int receiverIndex = 0;
					for (int i = 0; i < party.Count; i++)
					{
						if (party[i].Name == healerName)
						{
							healer = party[i];
							healerIndex = i;
						}
						else if (party[i].Name == healerRecieverName)
						{
							receiver = party[i];
							receiverIndex = i;
						}
					}
					if (healer.GetType().Name == "Priest")
					{
						Priest priest = healer as Priest;
						priest.Heal(receiver);
						healer = priest;
						party[healerIndex] = healer;
						party[receiverIndex] = receiver;

						StringBuilder output = new StringBuilder();
						output.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");
						
						return output.ToString().Trim();
					}
					else
					{
						throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
					}
				}
				else
				{
					throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerRecieverName);
				}
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
			}
		}
	}
}
