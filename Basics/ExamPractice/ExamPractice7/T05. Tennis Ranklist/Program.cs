using System;

namespace T05._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int points = 0;
            int wins = 0;

            for (int i = 0; i < numberOfTournaments; i++)
            {
                string result = Console.ReadLine();
                if (result == "W")
                {
                    wins++;
                    points += 2000;
                }
                else if (result == "F")
                {
                    points += 1200;
                }
                else if (result == "SF")
                {
                    points += 720;
                }
            }
            int totalPoints = points + startingPoints;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor((double)points/numberOfTournaments)}");
            Console.WriteLine($"{(double)wins/numberOfTournaments*100:f2}%");
        }
    }
}
