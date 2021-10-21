using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            IsReserved = false;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }
        public int TableNumber { get;}

        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }
        private int numberOfPeople;

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get;}

        public bool IsReserved { get; private set; }

        public decimal Price => foodOrders.Select(f => f.Price).Sum()
            + drinkOrders.Select(f => f.Price).Sum()
            + this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();
            IsReserved = false;
            Capacity = 0;
        }

        public decimal GetBill()
        {
            return Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Table: {TableNumber}");
            text.AppendLine($"Type: {this.GetType().Name}");
            text.AppendLine($"Capacity: {Capacity}");
            text.AppendLine($"Price per Person: {PricePerPerson}");
            return text.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
