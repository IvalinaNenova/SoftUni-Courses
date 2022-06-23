using System;
using System.Collections.Generic;

namespace _02._Snake
{
    internal class Program
    {
        private static int snakeRow;
        private static int snakeCol;

        private static int newRow;
        private static int newCol;

        private static char[,] territory;
        private static int size;

        private static List<(int, int)> burrows = new List<(int, int)>();
        private const char SnakeSymbol = 'S';
        private const char EmptySymbol = '-';
        private const char FoodSymbol = '*';
        private const char BurrowSymbol = 'B';
        private const char SnakeTrail = '.';

        static void Main(string[] args)
        {
            FillMatrix();
            int foodQuantity = 0;
            bool isGameOver = false;
            while (foodQuantity < 10)
            {
                string direction = Console.ReadLine();
                territory[snakeRow, snakeCol] = SnakeTrail;

                MoveSnake(direction);
                if (!HasValidCoordinates(snakeRow, snakeCol))
                {
                    isGameOver = true;
                    break;
                }

                switch (territory[snakeRow, snakeCol])
                {
                    case FoodSymbol:
                        foodQuantity++;
                        break;
                    case BurrowSymbol:
                        territory[snakeRow, snakeCol] = SnakeTrail;
                        burrows.Remove((snakeRow, snakeCol));
                        (snakeRow, snakeCol) = burrows[0];
                        break;
                }
                territory[snakeRow, snakeCol] = SnakeSymbol;
            }

            PrintOutput(isGameOver, foodQuantity);
        }

        public static void FillMatrix()
        {
            size = int.Parse(Console.ReadLine());
            territory = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = rowData[col];

                    if (territory[row, col] == SnakeSymbol)
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (territory[row, col] == BurrowSymbol)
                    {
                        burrows.Add((row, col));
                    }
                }
            }
        }

        public static void MoveSnake(string direction)
        {
            switch (direction)
            {
                case "up":
                    snakeRow--;
                    break;
                case "down":
                    snakeRow++;
                    break;
                case "left":
                    snakeCol--;
                    break;
                case "right":
                    snakeCol++;
                    break;
            }
        }
        public static void PrintOutput(bool isGameOver, int foodQuantity)
        {
            Console.WriteLine(isGameOver ? "Game over!" : "You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int i = 0; i < territory.GetLength(0); i++)
            {
                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    Console.Write(territory[i, j]);
                }

                Console.WriteLine();
            }
        }

        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < territory.GetLength(0) &&
                   col >= 0 && col < territory.GetLength(1);
        }
    }
}


