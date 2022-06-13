using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealDictionary = new Dictionary<string, int>
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790}
            };
            string[] meals = Console.ReadLine().Split();
            string[] caloriesAsString = Console.ReadLine().Split();
            Queue<string> mealsQueue = new Queue<string>(meals);
            Stack<int> calories = new Stack<int>(caloriesAsString.Select(int.Parse));

            int leftover = 0;
            int mealsEaten = 0;

            while (calories.Any() && mealsQueue.Any())
            {
                int dailyIntake = calories.Pop();

                while (dailyIntake > 0 && mealsQueue.Any())
                {
                    string currentMeal = mealsQueue.Dequeue();
                    mealsEaten++;
                    dailyIntake -= mealDictionary[currentMeal];
                }

                if (dailyIntake == 0)
                {
                    leftover = 0;
                }

                else if (dailyIntake < 0)
                {
                    leftover = dailyIntake;
                    if (calories.Any())
                    {
                        var nextDay = calories.Pop() + leftover;
                        calories.Push(nextDay);
                    }
                }

                if (!mealsQueue.Any() && dailyIntake >0)
                {
                    calories.Push(dailyIntake);
                }
            }

            if (mealsQueue.Count == 0)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else if (calories.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsQueue)}.");
            }
        }
    }
}
