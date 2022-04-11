using System;

namespace T02._Movie_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalShootTime = int.Parse(Console.ReadLine());
            int numberOfScenes = int.Parse(Console.ReadLine());
            int sceneShootTime = int.Parse(Console.ReadLine());

            double preparationTime = (double)totalShootTime * 0.15;
            int totalScenesTime = numberOfScenes * sceneShootTime;
            double timeNeeded = totalScenesTime + preparationTime;



            if (timeNeeded<=totalShootTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(totalShootTime-timeNeeded)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {timeNeeded-totalShootTime} minutes.");
            }
        }
    }
}
