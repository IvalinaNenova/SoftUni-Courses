using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];

            int officerRow = 0;
            int officerCol = 0;

            List<(int, int)> mirrors = new List<(int, int)>();

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = rowData[col];
                    if (armory[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    else if (armory[row, col] == 'M')
                    {
                        mirrors.Add((row, col));
                    }
                }
            }

            string direction = Console.ReadLine();
            bool isOut = false;
            int amount = 0;

            while (amount < 65)
            {
                var newCoordinates = NextPosition(officerRow, officerCol, direction);
                int newRow = newCoordinates.Item1;
                int newCol = newCoordinates.Item2;
                if (!HasValidCoordinates(newCoordinates, size))
                {
                    armory[officerRow, officerCol] = '-';
                    isOut = true;
                    break;
                }

                if (mirrors.Contains(newCoordinates))
                {
                    armory[newRow, newCol] = '-';
                    mirrors.Remove(newCoordinates);
                    newCoordinates = mirrors[0];
                }
                else if (char.IsDigit(armory[newRow, newCol]))
                {
                    amount += int.Parse(armory[newRow, newCol].ToString());
                }
                armory[officerRow, officerCol] = '-';
                newRow = newCoordinates.Item1;
                newCol = newCoordinates.Item2;
                armory[newRow, newCol] = 'A';
                officerRow = newRow;
                officerCol = newCol;

                direction = Console.ReadLine();
            }

            PrintOutput(armory, isOut, amount);

        }
        static bool HasValidCoordinates((int, int) coordinates, int size)
        {
            int row = coordinates.Item1;
            int col = coordinates.Item2;
            return row >= 0 && row < size &&
                   col >= 0 && col < size;
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

        public static void PrintOutput(char[,] armory, bool isOut, int amount)
        {
            Console.WriteLine(isOut ? "I do not need more swords!" : "Very nice swords, I will come back for more!");


            Console.WriteLine($"The king paid {amount} gold coins.");

            for (int i = 0; i < armory.GetLength(0); i++)
            {
                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    Console.Write(armory[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
