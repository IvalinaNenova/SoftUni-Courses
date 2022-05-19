using System;
using System.Linq;

namespace T03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixData = Console.ReadLine().Split(' ');
            int rows = int.Parse(matrixData[0]);
            int cols = int.Parse(matrixData[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] matrixLine = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = matrixLine[col];
                }
            }

            int highestSum = int.MinValue;
            int highestSumRow = 0;
            int highestSumCol = 0;


            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int subMatrixSum = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            subMatrixSum += matrix[row + i, col + j];
                        }
                    }

                    if (subMatrixSum > highestSum)
                    {
                        highestSum = subMatrixSum;
                        highestSumRow = row;
                        highestSumCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = " + highestSum);

            for (int row = highestSumRow; row < highestSumRow + 3; row++)
            {
                for (int col = highestSumCol; col < highestSumCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
