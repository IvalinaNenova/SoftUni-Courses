using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace T08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] matrixLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixLine[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split(' ');

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] bombLocation = coordinates[i].Split(",").Select(int.Parse).ToArray();
                int bombRow = bombLocation[0];
                int bombCol = bombLocation[1];
                int bombValue = matrix[bombRow, bombCol];

                if (bombValue > 0)
                {
                    List<int[]> validCoordinates = GetValidCoordinates(bombRow, bombCol, matrix, size);

                    foreach (var pairCoordinate in validCoordinates)
                    {
                        int row = pairCoordinate[0];
                        int col = pairCoordinate[1];

                        matrix[row, col] -= bombValue;
                    }

                    matrix[bombRow, bombCol] = 0;
                }

            }

            int aliveCells = 0;
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool CheckIfValidCoordinates(int row, int col, int size)
        {
            return row >= 0 &&
                   row < size &&
                   col >= 0 &&
                   col < size;
        }

        private static List<int[]> GetValidCoordinates(int bombRow, int bombCol, int[,] matrix, int size)
        {
            List<int[]> coordinates = new List<int[]>();

            if (CheckIfValidCoordinates(bombRow - 1, bombCol - 1, size) && matrix[bombRow - 1, bombCol - 1] > 0)
            {
                coordinates.Add(new[] { bombRow - 1, bombCol - 1 });
            }
            if (CheckIfValidCoordinates(bombRow - 1, bombCol, size) && matrix[bombRow - 1, bombCol] > 0)
            {
                coordinates.Add(new[] { bombRow - 1, bombCol });
            }
            if (CheckIfValidCoordinates(bombRow - 1, bombCol + 1, size) && matrix[bombRow - 1, bombCol + 1] > 0)
            {
                coordinates.Add(new[] { bombRow - 1, bombCol + 1 });
            }
            if (CheckIfValidCoordinates(bombRow, bombCol - 1, size) && matrix[bombRow, bombCol - 1] > 0)
            {
                coordinates.Add(new[] { bombRow, bombCol - 1 });
            }
            if (CheckIfValidCoordinates(bombRow, bombCol + 1, size) && matrix[bombRow, bombCol + 1] > 0)
            {
                coordinates.Add(new[] { bombRow, bombCol + 1 });
            }
            if (CheckIfValidCoordinates(bombRow + 1, bombCol - 1, size) && matrix[bombRow + 1, bombCol - 1] > 0)
            {
                coordinates.Add(new[] { bombRow + 1, bombCol - 1 });
            }
            if (CheckIfValidCoordinates(bombRow + 1, bombCol, size) && matrix[bombRow + 1, bombCol] > 0)
            {
                coordinates.Add(new[] { bombRow + 1, bombCol });
            }
            if (CheckIfValidCoordinates(bombRow + 1, bombCol + 1, size) && matrix[bombRow + 1, bombCol + 1] > 0)
            {
                coordinates.Add(new[] { bombRow + 1, bombCol + 1 });
            }

            return coordinates;
        }
    }
}
