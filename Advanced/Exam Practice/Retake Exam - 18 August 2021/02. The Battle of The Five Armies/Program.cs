using System;
using System.Collections.Generic;
using System.Data;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static int armor;
        static int armyRow;
        static int armyCol;
        static int newRow;
        static int newCol;
        static void Main(string[] args)
        {
            armor = int.Parse(Console.ReadLine());

            char[][] field = FillMatrix();
            bool hasWon = false;
            while (!hasWon)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];

                field[int.Parse(input[1])][int.Parse(input[2])] = 'O';

                (newRow, newCol) = MoveArmy(armyRow, armyCol, direction);
                field[armyRow][armyCol] = '-';
                armor--;

                if (HasValidCoordinates(newRow, newCol, field))
                {
                    (armyRow, armyCol) = (newRow, newCol);

                    if (field[armyRow][armyCol] == 'O')
                    {
                        armor -= 2;
                        field[armyRow][armyCol] = '-';
                    }
                    else if (field[armyRow][armyCol] == 'M')
                    {
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        field[armyRow][armyCol] = '-';
                        hasWon = true;
                    }
                }

                if (armor <= 0 && !hasWon)
                {
                    field[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    hasWon = true;
                }
            }

            PrintOutput(field);
        }

        private static char[][] FillMatrix()
        {
            int size = int.Parse(Console.ReadLine());
            char[][] field = new char[size][];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                field[row] = new char[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    field[row][col] = rowData[col];

                    if (field[row][col] == 'A')
                    {
                        (armyRow, armyCol) = (row, col);
                    }
                }
            }

            return field;
        }

        public static void PrintOutput(char[][] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }

                Console.WriteLine();
            }
        }

        static bool HasValidCoordinates(int row, int col, char[][] field)
        {
            return row >= 0 && row < field.GetLength(0) &&
                   col >= 0 && col < field[row].Length;
        }
        public static (int, int) MoveArmy(int row, int col, string direction)
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
    }
}
