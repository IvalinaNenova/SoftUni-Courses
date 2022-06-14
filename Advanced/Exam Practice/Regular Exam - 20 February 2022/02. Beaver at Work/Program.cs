using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Beaver_at_Work
{
    public class Program
    {

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] pond = new char[size, size];
            int beaverRow = 0;
            int beaverCol = 0;
            int countBranches = 0;

            for (int row = 0; row < size; row++)
            {
                char[] rowData = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = rowData[col];
                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(pond[row, col]))
                    {
                        countBranches++;
                    }
                }
            }

            string direction = Console.ReadLine();
            Stack<char> collectedBranches = new Stack<char>();

            while (direction != "end")
            {
                var newPosition = NextPosition(beaverRow, beaverCol, direction);
                int newRow = newPosition.Item1;
                int newCol = newPosition.Item2;

                if (!IsValidCoordinates(newRow, newCol, size))
                {
                    if (collectedBranches.Any())
                    {
                        collectedBranches.Pop();
                    }
                    direction = Console.ReadLine();
                    continue;
                }

                pond[beaverRow, beaverCol] = '-';
                beaverRow = newRow;
                beaverCol = newCol;

                if (pond[beaverRow, beaverCol] == 'F')
                {
                    pond[beaverRow, beaverCol] = '-';
                    newPosition = Swim(beaverRow, beaverCol, direction, size);
                    beaverRow = newPosition.Item1;
                    beaverCol = newPosition.Item2;
                }

                if (char.IsLower(pond[beaverRow, beaverCol]))
                {
                    collectedBranches.Push(pond[beaverRow, beaverCol]);
                    countBranches--;
                }

                pond[beaverRow, beaverCol] = 'B';

                if (countBranches == 0)
                {
                    break;
                }

                direction = Console.ReadLine();
            }

            if (countBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countBranches} branches left.");
            }

            PrintPond(pond);
        }

        public static void PrintPond(char[,] pond)
        {
            for (int i = 0; i < pond.GetLength(0); i++)
            {
                for (int j = 0; j < pond.GetLength(1); j++)
                {
                    Console.Write(pond[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
        public static (int, int) Swim(int row, int col, string direction, int size)
        {
            switch (direction)
            {
                case "up":
                    row = row == 0 ? size - 1 : 0;
                    break;
                case "down":
                    row = row != size - 1 ? size - 1 : 0;
                    break;
                case "right":
                    col = col == size - 1 ? 0 : size - 1;
                    break;
                case "left":
                    col = col == 0 ? size - 1 : 0;
                    break;
            }
            return (row, col);
        }
        public static (int, int) NextPosition(int row, int col, string direction)
        {
            switch (direction)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
            }
            return (row, col);
        }
        public static bool IsValidCoordinates(int row, int col, int size)
        {
            return row >= 0 &&
                   col >= 0 &&
                   row < size &&
                   col < size;
        }
    }
}
