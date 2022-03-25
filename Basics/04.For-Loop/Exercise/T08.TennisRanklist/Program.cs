using System;

namespace T08.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int pointsBeforeStart = int.Parse(Console.ReadLine());
            int totalPoints = pointsBeforeStart;
            int pointsWon = 0;
            int tournamentsWon = 0;

            for (int i = 0; i < numberOfTournaments; i++)
            {
                string tournamentStage = Console.ReadLine();
                if (tournamentStage == "W")
                {
                    totalPoints += 2000;
                    pointsWon += 2000;
                    tournamentsWon += 1;
                }
                else if (tournamentStage == "F")
                {
                    totalPoints += 1200;
                    pointsWon += 1200;
                }
                else if (tournamentStage == "SF")
                {
                    totalPoints += 720;
                    pointsWon += 720;
                }
            }
            double averagePoints = pointsWon / numberOfTournaments;
            double percentOfWins = (tournamentsWon*1.0 / numberOfTournaments) * 100; 
           
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor (averagePoints)}");
            Console.WriteLine($"{percentOfWins:f2}%");
        }
    }
}
