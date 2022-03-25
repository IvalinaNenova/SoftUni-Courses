using System;

namespace ExamProblem5
{
    class Program
    {
        static void Main(string[] args)
        {
            int killosOfFood = int.Parse(Console.ReadLine());
            int dogFoodInGrams = killosOfFood * 1000;
            string command = Console.ReadLine();
            double totalFoodConsumed = 0;

            while (command != "Adopted")
            {
                int gramsFoodEaten = int.Parse(command);

                totalFoodConsumed += gramsFoodEaten;

                command = Console.ReadLine();
            }

            double difference = Math.Abs(totalFoodConsumed - dogFoodInGrams);

            if (totalFoodConsumed <= dogFoodInGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {difference} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {difference} grams more.");
            }
        }
    }
}
