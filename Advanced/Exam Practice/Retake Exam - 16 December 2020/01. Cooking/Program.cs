using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> recipe = new Dictionary<int, string>
            {
                {25, "Bread"},
                {50, "Cake"},
                { 75, "Pastry"},
                {100, "Fruit Pie"}
            };
            Dictionary<string, int> bakedGoods = new Dictionary<string, int>
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Fruit Pie", 0},
                {"Pastry", 0}

            };
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var liquids = new Queue<int>(input1);
            var ingredients = new Stack<int>(input2);

            while (liquids.Any() && ingredients.Any())
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();
                int total = currentLiquid + currentIngredient;

                if (recipe.ContainsKey(total))
                {
                    string item = recipe[total];
                    bakedGoods[item]++;
                }
                else
                {
                    ingredients.Push(currentIngredient + 3);
                }
            }

            Console.WriteLine(!bakedGoods.ContainsValue(0)
                ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine(liquids.Any()
                ? $"Liquids left: {string.Join(", ", liquids)}"
                : "Liquids left: none");

            Console.WriteLine(ingredients.Any()
                ? $"Ingredients left: {string.Join(", ", ingredients)}"
                : "Ingredients left: none");

            foreach (var (item, amount) in bakedGoods)
            {
                Console.WriteLine($"{item}: {amount}");
            }
        }
    }
}
