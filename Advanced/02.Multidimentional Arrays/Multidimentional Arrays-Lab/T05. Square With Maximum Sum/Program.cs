using System;

namespace T05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixParameters = Console.ReadLine().Split(", ");
            int rows = int.Parse(matrixParameters[0]);
            int cols = int.Parse(matrixParameters[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] numbers = Console.ReadLine().Split(", ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            int highestSum = int.MinValue;
            int highestSumRow = 0;
            int highestSumCol = 0;
            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    int subMatrixSum = matrix[i, j] + matrix[i,j+1] +
                                        matrix[i+1,j] + matrix[i+1,j+1];

                    if (subMatrixSum > highestSum)
                    {
                        highestSum = subMatrixSum;
                        highestSumRow = i;
                        highestSumCol = j;
                    }
                }
            }

            for (int row = highestSumRow; row < highestSumRow+2; row++)
            {
                for (int col = highestSumCol; col < highestSumCol+2; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(highestSum);
        }
    }
}
