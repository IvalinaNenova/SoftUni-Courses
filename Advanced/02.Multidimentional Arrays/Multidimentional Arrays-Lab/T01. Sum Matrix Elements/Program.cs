using System;

namespace T01._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(", ");
            int rows = int.Parse(parameters[0]);
            int cols = int.Parse(parameters[1]);
            int[,] matrix = new int[rows, cols];
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                string[] numbers = Console.ReadLine().Split(", ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                    sum += int.Parse(numbers[col]);
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
