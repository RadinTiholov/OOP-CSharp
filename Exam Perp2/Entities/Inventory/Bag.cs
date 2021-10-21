using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        public Bag(int capacity)
        {
            Capacity = capacity;
        }
        public int Capacity { get; set; } = 100;
        public int Load
        {
            get { return Items.Sum(x => x.Weight); }
        }

        public IReadOnlyCollection<Item> Items { get; private set; }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            List<Item> items = (List<Item>)Items;
            items.Add(item);
            this.Items = items;
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            foreach (Item item in Items)
            {
                if (item.GetType().Name == name)
                {
                    List<Item> items = (List<Item>)Items;
                    items.Remove(item);
                    this.Items = items;
                    return item;
                }
            }
            throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
        }
    }
}
