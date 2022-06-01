using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace T10._Radioactive_Mutant_Vampire
{
    internal class Program
    {
        public
        static void Main(string[] args)
        {
            string[] dimensionsAsString = Console.ReadLine().Split(' ');
            int rows = int.Parse(dimensionsAsString[0]);
            int cols = int.Parse(dimensionsAsString[1]);
            char[,] field = new char[rows, cols];

            var playerPosition = FillAndReturnPlayerPosition(field);
            HashSet<(int, int)> bunnyPositions = GetBunnyPositions(field);
            string directions = Console.ReadLine();
            bool playerWon = false;
            bool bunniesWon = false;
            

            while (!playerWon && !bunniesWon)
            {
                foreach (var direction in directions)
                {
                    var newPosition = MovePlayer(playerPosition, direction);
                    field[playerPosition.Item1, playerPosition.Item2] = '.';

                    if (bunnyPositions.Contains(newPosition))
                    {
                        bunniesWon = true;
                        playerPosition = newPosition;

                    }
                    else if (!CheckPosition(newPosition.Item1, newPosition.Item2, field))
                    {
                        playerWon = true;
                    }
                    else
                    {
                        field[newPosition.Item1, newPosition.Item2] = 'P';
                        playerPosition = newPosition;
                    }
                   
                    bunnyPositions.UnionWith(SpreadBunnies(field, bunnyPositions));

                    if (bunnyPositions.Contains(newPosition) && !playerWon)
                    {
                        bunniesWon = true;

                    }

                    if (playerWon || bunniesWon)
                    {
                        break;
                    }
                }
            }

            if (playerWon)
            {
                PrintMatrix(field);
                Console.WriteLine($"won: {playerPosition.Item1} {playerPosition.Item2}");
            }
            else
            {
                PrintMatrix(field);
                Console.WriteLine($"dead: {playerPosition.Item1} {playerPosition.Item2}");
            }
        }

        private static HashSet<(int, int)> GetBunnyPositions(char[,] field)
        {
            HashSet<(int, int)> bunnyPositions = new HashSet<(int, int)>();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        bunnyPositions.Add((row, col));
                    }
                }
            }

            return bunnyPositions;
        }

        private static HashSet<(int, int)> SpreadBunnies(char[,] field, HashSet<(int, int)> bunnyPositions)
        {
            HashSet<(int, int)> newPositions = new HashSet<(int, int)>();
            foreach (var bunnyPosition in bunnyPositions)
            {
                int row = bunnyPosition.Item1;
                int col = bunnyPosition.Item2;

                if (CheckPosition(row - 1, col, field))
                {
                    field[row - 1, col] = 'B';
                    newPositions.Add((row - 1, col));
                }
                if (CheckPosition(row + 1, col, field))
                {
                    field[row + 1, col] = 'B';
                    newPositions.Add((row + 1, col));
                }
                if (CheckPosition(row, col + 1, field))
                {
                    field[row, col + 1] = 'B';
                    newPositions.Add((row, col + 1));
                }
                if (CheckPosition(row, col - 1, field))
                {
                    field[row, col - 1] = 'B';
                    newPositions.Add((row, col - 1));
                }
            }

            return newPositions;
        }
        private static bool CheckPosition(int newRow, int newCol, char[,] field)
        {
            return newRow >= 0 &&
                   newCol >= 0 &&
                   newRow < field.GetLength(0) &&
                   newCol < field.GetLength(1);
        }
        private static (int, int) MovePlayer((int, int) playerPosition, char move)
        {
            var row = playerPosition.Item1;
            var column = playerPosition.Item2;
            if (move == 'U')
            {
                row--;
            }
            else if (move == 'D')
            {
                row++;
            }
            else if (move == 'L')
            {
                column--;
            }
            else if (move == 'R')
            {
                column++;
            }

            return (row, column);
        }

        private static (int, int) FillAndReturnPlayerPosition(char[,] field)
        {
            var playerPosition = (0, 0);

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string matrixLine = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = matrixLine[col];

                    if (field[row, col] == 'P')
                    {
                        playerPosition = (row, col);
                    }
                }
            }

            return playerPosition;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
