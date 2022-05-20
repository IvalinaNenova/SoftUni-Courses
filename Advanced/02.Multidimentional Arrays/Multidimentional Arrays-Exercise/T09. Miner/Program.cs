using System;
using System.Linq;

namespace T09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] moves = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = FillTheMatrix(size);

            int[] startCoordinates = new int[2];
            int numberOfCoals = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startCoordinates[0] = row;
                        startCoordinates[1] = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        numberOfCoals++;
                    }
                }
            }

            int[] position = startCoordinates;
            int coalsCollected = 0;
            bool noMoreMoves = true;

            for (int i = 0; i < moves.Length; i++)
            {
                string move = moves[i];
                position = MoveMiner(move, position, size);

                int currentRow = position[0];
                int currentCol = position[1];

                if (matrix[currentRow, currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    noMoreMoves = false;
                    break;
                }
                else if (matrix[currentRow, currentCol] == 'c')
                {
                    matrix[currentRow, currentCol] = '*';
                    coalsCollected++;
                    numberOfCoals--;
                    if (numberOfCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        noMoreMoves = false;
                        break;
                    }
                }
            }

            if (noMoreMoves)
            {
                Console.WriteLine($"{numberOfCoals} coals left. ({position[0]}, {position[1]})");
            }
        }

        private static char[,] FillTheMatrix(int size)
        {
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] matrixLine = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixLine[col];
                }
            }

            return matrix;
        }

        public static bool CheckPosition(int currentRow, int currentCol, int size)
        {
            return currentRow >= 0 &&
                   currentCol >= 0 &&
                   currentRow < size &&
                   currentCol < size;
        }
        public static int[] MoveMiner(string move, int[] currentPosition, int size)
        {
            int currentRow = currentPosition[0];
            int currentCol = currentPosition[1];
            int[] newPosition = currentPosition;
            if (move == "up")
            {
                if (CheckPosition(currentRow - 1, currentCol, size))
                {
                    newPosition[0] = currentRow - 1;
                    newPosition[1] = currentCol;
                }
            }
            else if (move == "down")
            {
                if (CheckPosition(currentRow + 1, currentCol, size))
                {
                    newPosition[0] = currentRow + 1;
                    newPosition[1] = currentCol;
                }
            }
            else if (move == "right")
            {
                if (CheckPosition(currentRow, currentCol + 1, size))
                {
                    newPosition[0] = currentRow;
                    newPosition[1] = currentCol + 1;
                }
            }
            else if (move == "left")
            {
                if (CheckPosition(currentRow, currentCol - 1, size))
                {
                    newPosition[0] = currentRow;
                    newPosition[1] = currentCol - 1;
                }
            }

            return newPosition;
        }
    }
}
