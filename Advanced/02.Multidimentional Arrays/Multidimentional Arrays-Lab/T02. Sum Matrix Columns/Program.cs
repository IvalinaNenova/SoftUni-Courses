using System;

namespace T02._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixParams = Console.ReadLine().Split(", ");
            int rows = int.Parse(matrixParams[0]);
            int cols = int.Parse(matrixParams[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] numbers = Console.ReadLine().Split(" ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int colSum = 0;

                for (int row = 0; row < rows; row++)
                {
                    colSum+= matrix[row, col];
                }

                Console.WriteLine(colSum);
            }
        }
    }
}
