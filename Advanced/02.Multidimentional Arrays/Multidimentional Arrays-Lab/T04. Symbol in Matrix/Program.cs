using System;

namespace T04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string text = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = text[col];
                }
            }

            char symbolToLookFor = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == symbolToLookFor)
                    {
                        isFound = true;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbolToLookFor} does not occur in the matrix");
            }
        }
    }
}
