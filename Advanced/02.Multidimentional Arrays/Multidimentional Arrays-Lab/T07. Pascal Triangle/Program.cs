using System;
using System.Numerics;

namespace T07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                pascalTriangle[i] = new long[i + 1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][pascalTriangle[i].Length-1] = 1;

                for (int j = 1; j < pascalTriangle[i].Length-1; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i-1][j-1] + pascalTriangle[i-1][j];
                }
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
