using System;

namespace T03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] numbers = Console.ReadLine().Split(' ');

                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = int.Parse(numbers[col]);
                }
            }

            int diagonalSum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    diagonalSum += matrix[row, row];
                    break;
                }
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
