using System;

namespace T07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                }
            }

            int knightsRemoved = 0;
            int rowAttacked = 0;
            int colAttacked = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int attacks = 0;

                        if (board[row, col] == 'K')
                        {
                            attacks = GetNumberOfAttacks(board, row, col);

                            if (attacks > maxAttacks)
                            {
                                maxAttacks = attacks;
                                rowAttacked = row;
                                colAttacked = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    board[rowAttacked, colAttacked] = '0';
                    knightsRemoved++;
                }
                else
                {
                    Console.WriteLine(knightsRemoved);
                    break;
                }
            }
        }

        private static bool CheckIfValidCoordinates(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                   col >= 0 && col < board.GetLength(1);
        }
        private static int GetNumberOfAttacks(char[,] board, int row, int col)
        {
            int attacks = 0;

            if (CheckIfValidCoordinates(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
            {
                attacks++;
            }
            if (CheckIfValidCoordinates(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
            {
                attacks++;
            }
            if (CheckIfValidCoordinates(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
            {
                attacks++;
            }
            if (CheckIfValidCoordinates(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
            {
                attacks++;
            }
            if (CheckIfValidCoordinates(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
            {
                attacks++;
            }
            if (CheckIfValidCoordinates(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
            {
                attacks++;
            }
            if (CheckIfValidCoordinates(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
            {
                attacks++;
            }
            if (CheckIfValidCoordinates(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }
    }
}
