using System;

namespace T02._Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string result1 = Console.ReadLine();
            string result2 = Console.ReadLine();
            string result3 = Console.ReadLine();
            int gamesWon = 0;
            int gamesLost = 0;
            int gamesTied = 0;

            if (result1[0] > result1[2])
            {
                gamesWon++;
            }
            else if (result1[0] < result1[2])
            {
                gamesLost++;
            }
            else if (result1[0] == result1[2])
            {
                gamesTied++;
            }
            if (result2[0] > result2[2])
            {
                gamesWon++;
            }
            else if (result2[0] < result2[2])
            {
                gamesLost++;
            }
            else if (result2[0] == result2[2])
            {
                gamesTied++;
            }
            if (result3[0] > result3[2])
            {
                gamesWon++;
            }
            else if (result3[0] < result3[2])
            {
                gamesLost++;
            }
            else if (result3[0] == result3[2])
            {
                gamesTied++;
            }

            Console.WriteLine($"Team won {gamesWon} games.");
            Console.WriteLine($"Team lost {gamesLost} games.");
            Console.WriteLine($"Drawn games: {gamesTied}");
        }
    }
}
