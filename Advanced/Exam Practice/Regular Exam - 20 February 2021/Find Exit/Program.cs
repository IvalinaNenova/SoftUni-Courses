using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Exit
{
    internal class Program
    {
        private static int playerRow;
        private static int playerCol;

        private static char[,] maze;

        private const int size = 6;

        private const char ExitSymbol = 'E';
        private const char TrapSymbol = 'T';
        private const char WallSymbol = 'W';
        static void Main(string[] args)
        {
            string[] players = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string firstPlayer = players[0];
            string secondPlayer = players[1];

            Dictionary<string, bool> skips = new Dictionary<string, bool>
            {
                {"Tom", false},
                {"Jerry", false}
            };

            FillMaze();

            while (true)
            {
                string player = firstPlayer;

                string[] coordinates = Console.ReadLine()
                    .Split(new char[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                (playerRow, playerCol) = (int.Parse(coordinates[0]), int.Parse(coordinates[1]));

                if (skips[player] == false)
                {
                    if (maze[playerRow, playerCol] == ExitSymbol)
                    {
                        Console.WriteLine($"{player} found the Exit and wins the game!");
                        break;
                    }
                    else if (maze[playerRow, playerCol] == TrapSymbol)
                    {
                        Console.WriteLine($"{player} is out of the game! The winner is {secondPlayer}.");
                        break;
                    }
                    else if (maze[playerRow, playerCol] == WallSymbol)
                    {
                        Console.WriteLine($"{player} hits a wall and needs to rest.");
                        skips[player] = true;
                    }
                }
                else
                {
                    skips[player] = false;
                }

                (firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);
            }
        }
        public static void FillMaze()
        {
            maze = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowData = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    maze[row, col] = rowData[col];
                }
            }
        }
    }

}
