using System;

namespace _02._Re_Volt
{
    internal class Program
    {
        private static int playerRow;
        private static int playerCol;
        private static int previousRow;
        private static int previousCol;
        private static char[,] field;
        private static int size;

        private const char PlayerSymbol = 'f';
        private const char EmptySymbol = '-';
        private const char FinishSymbol = 'F';
        private const char BonusSymbol = 'B';
        private const char TrapSymbol = 'T';
        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());
            FillMatrix();

            bool hasWon = false;
            for (int i = 0; i < numberOfCommands; i++)
            {
                (previousRow, previousCol) = (playerRow, playerCol);

                string direction = Console.ReadLine();

                (playerRow, playerCol) = MovePlayer(direction);

                switch (field[playerRow, playerCol])
                {
                    case TrapSymbol:
                        (playerRow, playerCol) = (previousRow, previousCol);
                        continue;
                    case BonusSymbol:
                        (playerRow, playerCol) = MovePlayer(direction);
                        if (field[playerRow, playerCol] == FinishSymbol)
                        {
                            hasWon = true;
                        }
                        break;
                    case FinishSymbol:
                        hasWon = true;
                        break;
                }

                field[previousRow, previousCol] = EmptySymbol;
                field[playerRow, playerCol] = PlayerSymbol;
                if (hasWon)
                {
                    break;
                }
            }
            PrintOutput(hasWon);
        }

        public static void FillMatrix()
        {
            field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == PlayerSymbol)
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
        public static (int, int) MovePlayer(string direction)
        {
            switch (direction)
            {
                case "up":
                    playerRow = playerRow == 0 ? size - 1 : playerRow - 1;
                    break;
                case "down":
                    playerRow = playerRow == size - 1 ? 0 : playerRow + 1;
                    break;
                case "left":
                    playerCol = playerCol == 0 ? size - 1 : playerCol - 1;
                    break;
                case "right":
                    playerCol = playerCol == size - 1 ? 0 : playerCol + 1;
                    break;
            }
            return (playerRow, playerCol);
        }
        public static void PrintOutput(bool hasWon)
        {
            Console.WriteLine(hasWon ? "Player won!" : "Player lost!");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
