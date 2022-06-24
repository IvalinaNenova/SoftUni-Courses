using System;

namespace Problem2
{
    internal class Program
    {
        private static int playerRow;
        private static int playerCol;

        private static int newRow;
        private static int newCol;

        private static char[,] field;
        private static int size;

        private const char MySymbol = ' ';
        private const char MySymbol = ' ';
        private const char MySymbol = ' ';
        private const char MySymbol = ' ';
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void FillMatrix()
        {
            size = int.Parse(Console.ReadLine());
            field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == ' ')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
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
