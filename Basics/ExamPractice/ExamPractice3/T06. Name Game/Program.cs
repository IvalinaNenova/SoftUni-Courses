using System;

namespace T06._Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            string winner = "";
            int mostPoints = 0;

            while (playerName != "Stop")
            {
                int points = 0;
                int numberOfEntries = playerName.Length;

                for (int i = 0; i < numberOfEntries; i++)
                {
                    char letter = Convert.ToChar(playerName[i]);
                    int letterValue = Convert.ToInt32(letter);
                    int num = int.Parse(Console.ReadLine());

                    if (letterValue == num)
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }

                    if (points >= mostPoints)
                    {
                        mostPoints = points;
                        winner = playerName;
                    }
                }
                playerName = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {winner} with {mostPoints} points!");
        }
    }
}
