using System;
using System.Data;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        private static char[][] beach;
        private static int playerRow;
        private static int playerCol;
        private static int collectedTokens;
        private static int opponentsTokens;
        static void Main(string[] args)
        {
            FillBeach();

            string input = Console.ReadLine();

            while (input != "Gong")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commands[0];
                (playerRow, playerCol) = (int.Parse(commands[1]), int.Parse(commands[2]));

                if (!HasValidCoordinates(playerRow, playerCol))
                {
                    input = Console.ReadLine();
                    continue;
                }
                switch (action)
                {
                    case "Find":
                        if (beach[playerRow][playerCol] == 'T')
                        {
                            collectedTokens++;
                            beach[playerRow][playerCol] = '-';
                        }
                        break;
                    case "Opponent":
                        MoveOpponent(commands[3]);
                        break;
                }

                input = Console.ReadLine();
            }
            PrintOutput();

        }

        public static void MoveOpponent(string direction)
        {
            if (beach[playerRow][playerCol] == 'T')
            {
                opponentsTokens++;
                beach[playerRow][playerCol] = '-';
            }
            for (int i = 0; i < 3; i++)
            {
                (playerRow, playerCol) = GetNextCoordinates(direction);
                if (HasValidCoordinates(playerRow, playerCol))
                {
                    if (beach[playerRow][playerCol] == 'T')
                    {
                        opponentsTokens++;
                        beach[playerRow][playerCol] = '-';
                    }
                }
            }
        }

        public static (int, int) GetNextCoordinates(string direction)
        {
            switch (direction)
            {
                case "up":
                    playerRow--;
                    break;
                case "down":
                    playerRow++;
                    break;
                case "left":
                    playerCol--;
                    break;
                case "right":
                    playerCol++;
                    break;
            }
            return (playerRow, playerCol);
        }
        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < beach.GetLength(0) &&
                   col >= 0 && col < beach[row].Length;
        }
        public static void FillBeach()
        {
            int rows = int.Parse(Console.ReadLine());
            beach = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[row] = rowData;
            }
        }

        public static void PrintOutput()
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write(beach[row][col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
        }
    }
}
