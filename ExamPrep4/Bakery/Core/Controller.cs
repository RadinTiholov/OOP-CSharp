using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            bakedFoods = new List<BakedFood>();
            drinks = new List<Drink>();
            tables = new List<Table>();
        }
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal totalBill;
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                Drink drink = new Tea(name, portion, brand);
                drinks.Add(drink);
                return $"Added {name} ({brand}) to the drink menu";
            }
            else if (type == "Water")
            {
                Drink drink = new Water(name, portion, brand);
                drinks.Add(drink);
                return $"Added {name} ({brand}) to the drink menu";
            }
            return null;
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Cake")
            {
                BakedFood food = new Cake(name, price);
                bakedFoods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }
            else if (type == "Bread")
            {
                BakedFood food = new Bread(name, price);
                bakedFoods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }
            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                Table table = new InsideTable(tableNumber, capacity);
                tables.Add(table);
                return $"Added table number {tableNumber} in the bakery";
            }
            else if (type == "OutsideTable")
            {
                Table table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
                return $"Added table number {tableNumber} in the bakery";
            }
            return null;
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder text = new StringBuilder();
            foreach (var table in tables)
            {
                if (table.IsReserved == false)
                {
                    text.AppendLine(table.GetFreeTableInfo());
                }
            }
            return text.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalBill:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            foreach (var table in tables)
            {
                if (table.TableNumber == tableNumber)
                {
                    decimal bill = table.GetBill();

                    totalBill += bill;

                    table.Clear();
                    StringBuilder text = new StringBuilder();
                    text.AppendLine($"Table: {tableNumber}");
                    text.AppendLine($"Bill: {bill:f2}");
                    return text.ToString().Trim();
                }
            }
            return null;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (tables.Any(x => x.TableNumber == tableNumber))
            {
                if (drinks.Any(x => x.Name == drinkName && x.Brand == drinkBrand))
                {
                    Drink drink = null;
                    int tableIndex = 0;
                    for (int i = 0; i < drinks.Count; i++)
                    {
                        if (drinks[i].Name == drinkName && drinks[i].Brand == drinkBrand)
                        {
                            drink = drinks[i];
                        }
                    }
                    for (int i = 0; i < tables.Count; i++)
                    {
                        if (tables[i].TableNumber == tableNumber)
                        {
                            tableIndex = i;
                        }
                    }
                    tables[tableIndex].OrderDrink(drink);

                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
                else
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
            }
            else
            {
                return $"Could not find table {tableNumber}";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (tables.Any(x => x.TableNumber == tableNumber))
            {
                if (bakedFoods.Any(x => x.Name == foodName))
                {
                    int tableIndex = 0;
                    BakedFood food = null;
                    foreach (var item in bakedFoods)
                    {
                        if (item.Name == foodName)
                        {
                            food = item;
                        }
                    }
                    for (int i = 0; i < tables.Count; i++)
                    {
                        if (tables[i].TableNumber == tableNumber)
                        {
                            tableIndex = i;
                        }
                    }
                    tables[tableIndex].OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
                else 
                {
                    return $"No {foodName} in the menu";
                }
            }
            else
            {
                return $"Could not find table {tableNumber}";
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            if (tables.Any(x=>x.IsReserved == false && x.Capacity >= numberOfPeople))
            {
                int number = 0;
                foreach (var table in tables)
                {
                    if (!table.IsReserved && table.Capacity >= numberOfPeople)
                    {
                        table.Reserve(numberOfPeople);
                        number = table.TableNumber;
                        break;
                    }
                }
                return $"Table {number} has been reserved for {numberOfPeople} people";
            }
            else
            {
                return $"No available table for {numberOfPeople} people";
            }
        }
    }
}
