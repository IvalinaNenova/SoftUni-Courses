using System;

namespace Problem2
{
    internal class Program
    {
        private static int VankoRow;
        private static int VankoCol;

        private static int newRow;
        private static int newCol;

        private static char[,] wall;
        private static int size;


        private const char VankoSymbol = 'V';
        private const char HoleSymbol = '*';
        private const char RodsSymbol = 'R';
        private const char CablesSymbol = 'C';


        static void Main(string[] args)
        {
            FillWall();

            int rodsHit = 0;
            int holesMade = 1;
            bool isElectrocuted = false;

            while (true)
            {
                string direction = Console.ReadLine();
                if (direction == "End")
                {
                    break;
                }

                (newRow, newCol) = MoveVanko(VankoRow, VankoCol, direction);
                if (!HasValidCoordinates(newRow, newCol)) continue;

                if (wall[newRow, newCol] == RodsSymbol)
                {
                    rodsHit++;
                    Console.WriteLine("Vanko hit a rod!");
                    continue;
                }

                wall[VankoRow, VankoCol] = HoleSymbol;
                (VankoRow, VankoCol) = (newRow, newCol);

                if (wall[VankoRow, VankoCol] == CablesSymbol)
                {
                    wall[VankoRow, VankoCol] = 'E';
                    holesMade++;
                    isElectrocuted = true;
                    break;
                }
                else if (wall[VankoRow, VankoCol] == HoleSymbol)
                {
                    Console.WriteLine($"The wall is already destroyed at position [{VankoRow}, {VankoCol}]!");
                }
                else
                {
                    holesMade++;
                }

                wall[VankoRow, VankoCol] = VankoSymbol;
            }

            PrintOutput(isElectrocuted, holesMade, rodsHit);
        }

        public static void FillWall()
        {
            size = int.Parse(Console.ReadLine());
            wall = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = rowData[col];

                    if (wall[row, col] == VankoSymbol)
                    {
                        VankoRow = row;
                        VankoCol = col;
                    }
                }
            }
        }

        public static (int, int) MoveVanko(int row, int col, string direction)
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
        public static void PrintOutput(bool isElectrocuted, int holesMade, int rodsHit)
        {
            Console.WriteLine(isElectrocuted
                ? $"Vanko got electrocuted, but he managed to make {holesMade} hole(s)."
                : $"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHit} rod(s).");

            for (int i = 0; i < wall.GetLength(0); i++)
            {
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    Console.Write(wall[i, j]);
                }

                Console.WriteLine();
            }
        }

        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < wall.GetLength(0) &&
                   col >= 0 && col < wall.GetLength(1);
        }
    }
}
