using System;
using System.Collections.Generic;

namespace _02._Selling
{
    using System;


    internal class Program
    {
        private static int myRow;
        private static int myCol;

        private static int newRow;
        private static int newCol;

        private static char[,] field;
        private static int size;
        private static List<(int, int)> pillars;
        private const char MySymbol = 'S';
        private const char Pillar = 'O';
        private const char EmptySpace = '-';


        static void Main(string[] args)
        {
            int totalIncome = 0;
            FillMatrix();
            while (totalIncome < 50)
            {
                field[myRow, myCol] = EmptySpace;

                string direction = Console.ReadLine();
                (newRow, newCol) = NextPosition(myRow, myCol, direction);
                if (HasValidCoordinates(newRow, newCol))
                {
                    if (field[newRow, newCol] == Pillar)
                    {
                        field[newRow, newCol] = EmptySpace;
                        pillars.Remove((newRow, newCol));
                        (newRow, newCol) = pillars[0];
                    }
                    else if (char.IsDigit(field[newRow, newCol]))
                    {
                        string digitAsString = field[newRow, newCol].ToString();
                        totalIncome += int.Parse(digitAsString);
                    }
                }
                else
                {
                    break;
                }

                (myRow, myCol) = (newRow, newCol);
                field[myRow, myCol] = MySymbol;
            }

            Console.WriteLine(totalIncome >= 50
                ? "Good news! You succeeded in collecting enough money!"
                : "Bad news, you are out of the bakery.");
            Console.WriteLine($"Money: {totalIncome}");

            PrintOutput();
        }

        public static void FillMatrix()
        {
            size = int.Parse(Console.ReadLine());
            field = new char[size, size];
            pillars = new List<(int, int)>();
            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == MySymbol)
                    {
                        myRow = row;
                        myCol = col;
                    }
                    else if (field[row, col] == Pillar)
                    {
                        pillars.Add((row, col));
                    }
                }
            }
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
        public static void PrintOutput()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }
        }

        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) &&
                   col >= 0 && col < field.GetLength(1);
        }
    }
}
