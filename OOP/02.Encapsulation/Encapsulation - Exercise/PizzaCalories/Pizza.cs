using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int ToppingsCapacity = 10;

        private string name;
        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public IReadOnlyCollection<Topping> Toppings => toppings; 
        public Dough Dough
        {
            get => dough;
            private set => dough = value;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 1 || value.Length > 15 )
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public void AddToppings(Topping topping)
        {
            if (toppings.Count == ToppingsCapacity)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double result = dough.Calories + toppings.Sum(x=>x.Calories);
            
            return result;
        }
    }
}
