using System;
using System.Linq;

namespace T04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixData = Console.ReadLine().Split(' ');
            int rows = int.Parse(matrixData[0]);
            int cols = int.Parse(matrixData[1]);

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] matrixLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = matrixLine[col];
                }
            }

            string[] commandLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (!commandLine.Contains("END"))
            {
                if (CheckIfValidCommand(commandLine) && CheckIfValidIndices(rows, cols, commandLine))
                {
                    int row1 = int.Parse(commandLine[1]);
                    int col1 = int.Parse(commandLine[2]);
                    int row2 = int.Parse(commandLine[3]);
                    int col2 = int.Parse(commandLine[4]);

                    (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    commandLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }

                    Console.WriteLine();
                }

                commandLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static bool CheckIfValidCommand(string[] command)
        {
            if (command.Contains("swap") && command.Length == 5)
            {
                return true;
            }

            return false;
        }

        public static bool CheckIfValidIndices(int rows, int cols, string[] command)
        {
            int row1 = int.Parse(command[1]);
            int col1 = int.Parse(command[2]);
            int row2 = int.Parse(command[3]);
            int col2 = int.Parse(command[4]);

            if (row1 >= 0 && row1 < rows &&
                row2 >= 0 && row2 < rows &&
                col1 >= 0 && col1 < cols &&
                col2 >= 0 && col2 < cols)
            {
                return true;
            }

            return false;
        }
    }
}
