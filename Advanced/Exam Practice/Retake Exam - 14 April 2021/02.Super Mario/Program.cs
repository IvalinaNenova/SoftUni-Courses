using System;
using System.Linq;

namespace _02.Super_Mario
{
    internal class Program
    {
        private static int marioRow;
        private static int marioCol;

        private static int newRow;
        private static int newCol;

        private static char[][] maze;

        private const char MarioSymbol = 'M';
        private const char DeadSymbol = 'X';
        private const char PrincessSymbol = 'P';
        private const char BowserSymbol = 'B';
        private const char EmptySymbol = '-';

        static void Main(string[] args)
        {
            int numberOfLives = int.Parse(Console.ReadLine());
            FillMaze();

            string input = Console.ReadLine();
            bool isOver = false;
            while (!isOver)
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = commands[0];
                maze[int.Parse(commands[1])][int.Parse(commands[2])] = BowserSymbol;

                numberOfLives--;
                maze[marioRow][marioCol] = EmptySymbol;

                (newRow, newCol) = MoveMario(marioRow, marioCol, direction);

                if (HasValidCoordinates(newRow, newCol))
                {
                    (marioRow, marioCol) = (newRow, newCol);
                    switch (maze[marioRow][marioCol])
                    {
                        case PrincessSymbol:
                            isOver = true;
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {numberOfLives}");
                            maze[marioRow][marioCol] = EmptySymbol;
                            break;
                        case BowserSymbol:
                            numberOfLives -= 2;
                            maze[marioRow][marioCol] = EmptySymbol;
                            break;
                    }
                }

                if (!isOver && numberOfLives <= 0)
                {
                    maze[marioRow][marioCol] = DeadSymbol;
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    isOver = true;
                }

                input = Console.ReadLine();
            }

            PrintOutput();
        }
        public static void FillMaze()
        {
            int rows = int.Parse(Console.ReadLine());
            maze = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                maze[row] = new char[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    maze[row][col] = rowData[col];

                    if (maze[row][col] == MarioSymbol)
                    {
                        (marioRow, marioCol) = (row, col);
                    }
                }
            }
        }

        public static (int, int) MoveMario(int row, int col, string direction)
        {
            switch (direction)
            {
                case "W":
                    row--;
                    break;
                case "S":
                    row++;
                    break;
                case "A":
                    col--;
                    break;
                case "D":
                    col++;
                    break;
            }

            return (row, col);
        }

        public static void PrintOutput()
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", maze[row]));
            }
        }

        static bool HasValidCoordinates(int row, int col)
        {
            return row >= 0 && row < maze.GetLength(0) &&
                   col >= 0 && col < maze[row].Length;
        }
    }
}


