using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        private static int playerOneShipsCount = 0;
        private static int playerTwoShipsCount = 0;

        private static int totalShipsSunk = 0;

        private static char[,] field;
        private static int size;

        private const char RegularPosition = '*';
        private const char FirstPlayerShip = '<';
        private const char SecondPlayerShip = '>';
        private const char DestroyedSymbol = 'X';
        private const char Mine = '#';

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            FillMatrix();

            string firstPlayer = "One";
            string secondPlayer = "Two";

            bool hasWinner = false;
            string winner = string.Empty;

            foreach (var pair in input)
            {
                int[] coordinates = pair.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                (int row, int col) = (coordinates[0], coordinates[1]);

                if (HasValidCoordinates(row, col))
                {
                    Battle(row, col);
                    if (playerOneShipsCount == 0)
                    {
                        winner = secondPlayer;
                        hasWinner = true;
                        break;
                    }
                    else if (playerTwoShipsCount == 0)
                    {
                        winner = firstPlayer;
                        hasWinner = true;
                        break;
                    }
                }
            }

            Console.WriteLine(hasWinner
                ? $"Player {winner} has won the game! {totalShipsSunk} ships have been sunk in the battle."
                : $"It's a draw! Player One has {playerOneShipsCount} ships left. Player Two has {playerTwoShipsCount} ships left.");
        }

        public static void Battle(int attackedRow, int attackedCol)
        {
            switch (field[attackedRow, attackedCol])
            {
                case FirstPlayerShip:
                    playerOneShipsCount--;
                    field[attackedRow, attackedCol] = DestroyedSymbol;
                    totalShipsSunk++;
                    break;
                case SecondPlayerShip:
                    playerTwoShipsCount--;
                    field[attackedRow, attackedCol] = DestroyedSymbol;
                    totalShipsSunk++;
                    break;
                case Mine:
                    TriggerMine(attackedRow, attackedCol);
                    break;
            }
        }
        public static void TriggerMine(int row, int col)
        {
            int[] rowOffset = { 1, 1, 0, -1, -1, -1, 0, 1 };
            int[] colOffset = { 0, 1, 1, 1, 0, -1, -1, -1 };

            for (int i = 0; i < rowOffset.Length; i++)
            {
                int newRow = row + rowOffset[i];
                int newCol = col + colOffset[i];

                if (!HasValidCoordinates(newRow, newCol)) continue;
                if (field[newRow, newCol] == RegularPosition) continue;

                switch (field[newRow, newCol])
                {
                    case FirstPlayerShip:
                        playerOneShipsCount--;
                        totalShipsSunk++;
                        break;
                    case SecondPlayerShip:
                        playerTwoShipsCount--;
                        totalShipsSunk++;
                        break;
                }
                field[newRow, newCol] = DestroyedSymbol;
            }
        }
        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) &&
                   col >= 0 && col < field.GetLength(1);
        }
        public static void FillMatrix()
        {
            field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];

                    switch (field[row, col])
                    {
                        case FirstPlayerShip:
                            playerOneShipsCount++;
                            break;
                        case SecondPlayerShip:
                            playerTwoShipsCount++;
                            break;
                    }
                }
            }
        }
    }
}
