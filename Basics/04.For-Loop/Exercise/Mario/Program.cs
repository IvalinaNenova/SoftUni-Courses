using System;

namespace xxx
{
    class xxx
    {
        static void Main()
        {
            const int F = 1200;
            const int W = 2000;
            const int SF = 720;


            int numOfTour = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int points = 0;
            double average = 0;
            double percent = 0;
            int numOfWinTour = 0;
            points = startPoints;

            for (int i = 0; i < numOfTour; i++)
            {
                string rank = Console.ReadLine();
                if (rank == "F")
                {
                    points += F;
                }
                else if (rank == "W")
                {
                    points += W;
                    numOfWinTour++;
                }
                else if (rank == "SF")
                {
                    points += SF;
                }
            }
            average = (points - startPoints) / numOfTour;
            percent = ((double)numOfWinTour / numOfTour) * 100;
            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(average)}");
            Console.WriteLine($"{percent:f2}%");
        }
    }
}


