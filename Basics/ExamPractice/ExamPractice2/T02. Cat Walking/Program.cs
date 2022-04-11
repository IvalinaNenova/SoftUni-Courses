using System;

namespace T02._Cat_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesPerWalk = int.Parse(Console.ReadLine());
            int walks = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            int totalMinutes = minutesPerWalk * walks;
            int caloriesBurnt = totalMinutes * 5;

            if (caloriesBurnt >= calories / 2)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurnt}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurnt}.");
            }

            
        }
    }
}
