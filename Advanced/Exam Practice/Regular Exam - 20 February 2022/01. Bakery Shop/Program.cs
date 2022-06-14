using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var itemsRecipe = new Dictionary<(double, double), string>
            {
                {(50, 50), "Croissant"},
                {(40, 60), "Muffin"},
                {(30, 70), "Baguette"},
                {(20, 80), "Bagel"}
            };
            Dictionary<string, int> bakedGoods = new Dictionary<string, int>
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette", 0},
                {"Bagel", 0}
            };
            double[] waterInput = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] flourInput = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var water = new Queue<double>(waterInput);
            var flour = new Stack<double>(flourInput);

            Bake(water, flour, itemsRecipe, bakedGoods);

            PrintOutput(bakedGoods,water, flour);
        }

        private static void Bake(Queue<double> water, Stack<double> flour, Dictionary<(double, double), string> itemsRecipe, Dictionary<string, int> bakedGoods)
        {
            while (water.Any() && flour.Any())
            {
                var currentProportions = GetCurrentProportions(water, flour);

                if (itemsRecipe.ContainsKey(currentProportions))
                {
                    var itemBaked = itemsRecipe[currentProportions];
                    bakedGoods[itemBaked]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    var waterAmount = water.Dequeue();
                    var flourAmount = flour.Pop();
                    var leftoverFlour = flourAmount - waterAmount;
                    bakedGoods["Croissant"]++;
                    flour.Push(leftoverFlour);
                }
            }
        }

        private static (double, double) GetCurrentProportions(Queue<double> water, Stack<double> flour)
        {
            var currentWater = water.Peek();
            var currentFlour = flour.Peek();
            var total = currentWater + currentFlour;
            var waterPercentage = currentWater * 100 / total;
            var flourPercentage = currentFlour * 100 / total;
            return (waterPercentage, flourPercentage);
        }

        public static void PrintOutput(Dictionary<string, int> bakedGoods, Queue<double> water, Stack<double> flour)
        {
            var filtered = bakedGoods.Where(baked => baked.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var (pastry, amount) in filtered)
            {
                Console.WriteLine($"{pastry}: {amount}");
            }

            if (water.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
