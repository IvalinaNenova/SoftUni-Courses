using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace T10._Radioactive_Mutant_Vampire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            int rows = int.Parse(dimensions[0]);
            int columns = int.Parse(dimensions[1]);

            char[,] field = new char[rows, columns];

            int[] playerPosition = FillAndReturnPlayerPosition(rows, columns, field);
            int playerRow = playerPosition[0];
            int playerColumn = playerPosition[1];
            int[] newPosition = new int[2];


            string moves = Console.ReadLine();
            bool isDead = false;
            bool hasWon = false;
            bool isKilledByBunny = false;


            while (!hasWon && !isDead && !isKilledByBunny)
            {
                foreach (char move in moves)
                {
                    field[playerRow, playerColumn] = '.';
                    newPosition = MovePlayer(playerRow, playerColumn, move);
                    int newRow = newPosition[0];
                    int newCol = newPosition[1];

                    if (!CheckPosition(newRow, newCol, rows, columns))
                    {
                        hasWon = true;
                    }
                    else if (field[newRow,newCol] == 'B')
                    {
                        isDead = true;
                    }

                    if (!isDead && !hasWon)
                    {
                        playerRow = newPosition[0];
                        playerColumn = newPosition[1];
                        field[playerRow, playerColumn] = 'P';
                    }

                    Queue<int> bunnyPositions = GetBunnyPositions(rows, columns, field);

                    while (bunnyPositions.Count > 0)
                    {
                        int row = bunnyPositions.Dequeue();
                        int col = bunnyPositions.Dequeue();

                        isKilledByBunny = SpreadBunnies(field, row, col, hasWon);
                    }

                    if (isDead || hasWon || isKilledByBunny)
                    {
                        break;
                    }
                }
            }

            if (hasWon)
            {
                PrintMatrix(field);
                Console.WriteLine($"won: {playerRow} {playerColumn}");
            }
            else if (isDead)
            {
                PrintMatrix(field);
                Console.WriteLine($"dead: {newPosition[0]} {newPosition[1]}");
            }
            else if (isKilledByBunny)
            {
                PrintMatrix(field);
                Console.WriteLine($"dead: {newPosition[0]} {newPosition[1]}");
            }
        }

        private static Queue<int> GetBunnyPositions(int rows, int columns, char[,] field)
        {
            Queue<int> bunnyPositions = new Queue<int>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (field[row, col] == 'B')
                    {
                        bunnyPositions.Enqueue(row);
                        bunnyPositions.Enqueue(col);
                    }
                }
            }

            return bunnyPositions;
        }

        private static bool SpreadBunnies(char[,] field, int row, int col, bool hasWon)
        {
            int maxRowLength = field.GetLength(0);
            int maxColLength = field.GetLength(1);
            bool isOver = false;

            if (CheckPosition(row - 1, col, maxRowLength, maxColLength ))
            {
                if (field[row, col] == 'P' && !hasWon)
                {
                    isOver = true;
                }
                field[row - 1, col] = 'B';
            }
            if (CheckPosition(row + 1, col, maxRowLength, maxColLength))
            {
                if (field[row, col] == 'P' && !hasWon)
                {
                    isOver = true;
                }
                field[row + 1, col] = 'B';
            }
            if (CheckPosition(row, col + 1, maxRowLength, maxColLength))
            {
                if (field[row, col] == 'P' && !hasWon)
                {
                    isOver = true;
                }
                field[row, col + 1] = 'B';
            }
            if (CheckPosition(row, col - 1, maxRowLength, maxColLength))
            {
                if (field[row, col] == 'P' && !hasWon)
                {
                    isOver = true;
                }
                field[row, col - 1] = 'B';
            }

            return isOver;
        }
        private static bool CheckPosition(int newRow, int newCol, int rows, int cols)
        {
            return newRow >= 0 &&
                   newCol >= 0 &&
                   newRow < rows &&
                   newCol < cols;
        }
        private static int[] MovePlayer(int row, int column, char move)
        {
            if (move == 'U')
            {
                row--;
            }
            else if (move == 'D')
            {
                row++;
            }
            else if (move == 'L')
            {
                column--;
            }
            else if (move == 'R')
            {
                column++;
            }
            int[] newPosition = new int[] { row, column };

            return newPosition;
        }

        private static int[] FillAndReturnPlayerPosition(int rows, int cols, char[,] field)
        {
            int[] playerPosition = new int[2];

            for (int row = 0; row < rows; row++)
            {
                string matrixLine = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = matrixLine[col];
                    if (field[row, col] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }

            return playerPosition;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
