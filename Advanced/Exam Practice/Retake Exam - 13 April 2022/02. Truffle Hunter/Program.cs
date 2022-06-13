using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var forest = FillTheForest();

            string input = Console.ReadLine();
            var peterTruffles = new Dictionary<char, int>
            {
                {'B', 0},
                {'S',0},
                {'W',0}
            };
            int boarTruffleCount = 0;
            
            while (input != "Stop the hunt")
            {
                string[] commands = input.Split(' ');
                string action = commands[0];

                switch (action)
                {
                    case "Collect":
                      GetPeterTruffles(commands,peterTruffles, forest);
                        break;
                    case "Wild_Boar":
                        boarTruffleCount += GetBoarsTruffles(commands, forest);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {peterTruffles['B']} black, {peterTruffles['S']} summer, and {peterTruffles['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffleCount} truffles.");

            printForest(forest);
        }

        public static void GetPeterTruffles(string[] commands,Dictionary<char, int> peterTruffles, char[,] forest)
        {
            int playerRow = int.Parse(commands[1]);
            int playerCol = int.Parse(commands[2]);

            if (forest[playerRow, playerCol] != '-')
            {
                char typeOfTruffle = forest[playerRow, playerCol];
                peterTruffles[typeOfTruffle]++;
                forest[playerRow, playerCol] = '-';
            }
        }
        public static int GetBoarsTruffles(string[] commands, char[,] forest)
        {
            int row = int.Parse(commands[1]);
            int col = int.Parse(commands[2]);
            int boarTruffleCount = 0;
            string direction = commands[3];

            if (forest[row,col] != '-')
            {
                boarTruffleCount++;
                forest[row, col] = '-';
            }

            while (true)
            {
                switch (direction)
                {
                    case "up":
                        row -= 2;
                        break;
                    case "down":
                        row += 2;
                        break;
                    case "left":
                        col -= 2;
                        break;
                    case "right":
                        col += 2;
                        break;
                }
                if (!IsValidPosition(row, col, forest))
                {
                    break;
                }
                else if(forest[row, col] != '-')
                {
                    forest[row,col] = '-';
                    boarTruffleCount++;
                }
            }
            return boarTruffleCount;
        }

        public static bool IsValidPosition(int row, int col, char[,] forest)
        {
            return row >= 0 &&
                   col >= 0 &&
                   row < forest.GetLength(0) &&
                   col < forest.GetLength(1);
        }
        private static char[,] FillTheForest()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] rowData = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = rowData[col];
                }
            }

            return forest;
        }

        public static void printForest(char[,] forest)
        {
            for (int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    Console.Write(forest[i,j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
