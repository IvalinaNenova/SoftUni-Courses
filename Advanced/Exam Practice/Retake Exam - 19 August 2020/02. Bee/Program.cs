using System;

namespace _02._Warships
{
    internal class Program
    {
        private static int beeRow;
        private static int beeCol;

        private static int newRow;
        private static int newCol;

        private static char[,] garden;
        private static int size;
        private static int polinatedFlowers = 0;

        private const char Bee = 'B';
        private const char Bonus = 'O';
        private const char Flower = 'f';
        private const char EmptySymbol = '.';

        private const int flowersNeeded = 5;

        static void Main(string[] args)
        {
            FillGarden();
            bool gotLost = false;
            string direction = Console.ReadLine();
            while (direction != "End")
            {
                garden[beeRow, beeCol] = EmptySymbol;

                MoveBee(direction);

                if (!HasValidCoordinates(beeRow, beeCol))
                {
                    gotLost = true;
                    break;
                }

                switch (garden[beeRow, beeCol])
                {
                    case Flower:
                        polinatedFlowers++;
                        break;
                    case Bonus:
                        garden[beeRow, beeCol] = EmptySymbol;
                        MoveBee(direction);
                        if (garden[beeRow, beeCol] == Flower)
                        {
                            polinatedFlowers++;
                        }
                        break;
                }

                garden[beeRow, beeCol] = Bee;

                direction = Console.ReadLine();
            }

            if (gotLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            Console.WriteLine(polinatedFlowers >= flowersNeeded
                ? $"Great job, the bee managed to pollinate {polinatedFlowers} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {flowersNeeded - polinatedFlowers} flowers more");

            PrintOutput();
        }

        public static void FillGarden()
        {
            size = int.Parse(Console.ReadLine());
            garden = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    garden[row, col] = rowData[col];

                    if (garden[row, col] == Bee)
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
        }

        public static void MoveBee(string direction)
        {
            switch (direction)
            {
                case "up":
                    beeRow--;
                    break;
                case "down":
                    beeRow++;
                    break;
                case "left":
                    beeCol--;
                    break;
                case "right":
                    beeCol++;
                    break;
            }
        }
        public static void PrintOutput()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(garden[i, j]);
                }

                Console.WriteLine();
            }
        }

        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < size &&
                   col >= 0 && col < size;
        }
    }
}
