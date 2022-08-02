using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders = new List<IBakedFood>();
        private List<IDrink> drinkOrders = new List<IDrink>();
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.tableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public int TableNumber => tableNumber;

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get => pricePerPerson;
            private set => pricePerPerson = value;
        }

        public bool IsReserved => isReserved;

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            isReserved = true;
        }

        public void OrderFood(IBakedFood food) => foodOrders.Add(food);

        public void OrderDrink(IDrink drink) => drinkOrders.Add(drink);

        public decimal GetBill() => foodOrders.Sum(f=> f.Price) + drinkOrders.Sum(d=> d.Price) + Price;
        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            isReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}
