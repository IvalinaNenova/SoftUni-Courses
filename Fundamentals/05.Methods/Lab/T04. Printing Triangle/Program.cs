using System;

namespace T04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTriangle(n);
        }

        static void PrintTriangle(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintingCollumn(row);
            }

            for (int row = n - 1; row >= 1; row--)
            {
                PrintingCollumn(row);
            }
        }

        private static void PrintingCollumn(int row)
        {
            for (int i = 1; i <= row; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
