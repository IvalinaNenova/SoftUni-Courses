using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dishes = new Dictionary<int, string>
            {
                {150, "Dipping sauce"},
                {250, "Green salad"},
                {300, "Chocolate cake"},
                {400, "Lobster"},
            };

            int[] ingredientsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] freshnessInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var ingredients = new Queue<int>(ingredientsInput);
            var freshness = new Stack<int>(freshnessInput);

            var completedDishes = new Dictionary<string, int>
            {
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}

            };
            while (ingredients.Any() && freshness.Any())
            {
                int ingredient = ingredients.Peek();
                if (ingredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int freshnessValue = freshness.Pop();

                int totalFreshness = ingredient * freshnessValue;


                if (dishes.ContainsKey(totalFreshness))
                {
                    string completedDish = dishes[totalFreshness];
                    completedDishes[completedDish]++;
                    ingredients.Dequeue();
                }
                else
                {
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            bool hasFailed = completedDishes.Any(dish => dish.Value == 0);
            Console.WriteLine(!hasFailed
                ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (ingredients.Any())
            {
                Console.WriteLine($" Ingredients left: {ingredients.Sum()}");
            }

            var filtered = completedDishes.Where(dish => dish.Value > 0).OrderBy(dish => dish.Key);
            foreach (var (dish, amount) in filtered)
            {
                Console.WriteLine($" # {dish} --> {amount}");
            }
        }
    }
}
