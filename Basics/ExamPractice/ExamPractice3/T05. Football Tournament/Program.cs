using System;

namespace T05._Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int gamesPlayed = int.Parse(Console.ReadLine());
            int points = 0;
            int gamesWon = 0;
            int gamesTied = 0;
            int gamesLost = 0;

            if (gamesPlayed == 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
            }
            else
            {
                for (int i = 1; i <= gamesPlayed; i++)
                {
                    string result = Console.ReadLine();

                    if (result == "W")
                    {
                        points += 3;
                        gamesWon++;
                    }
                    else if (result == "D")
                    {
                        points++;
                        gamesTied++;
                    }
                    else if (result == "L")
                    {
                        gamesLost++;
                    }
                }

            }
            if (gamesPlayed > 0)
            {
                Console.WriteLine($"{teamName} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {gamesWon}");
                Console.WriteLine($"## D: {gamesTied}");
                Console.WriteLine($"## L: {gamesLost}");
                Console.WriteLine($"Win rate: {(double)gamesWon / gamesPlayed * 100:f2}%");
            }

        }
    }
}
