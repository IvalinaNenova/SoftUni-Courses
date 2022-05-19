using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace T06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                jaggedArray[row] = new Double[numbers.Length];

                for (int col = 0; col < numbers.Length; col++)
                {
                    jaggedArray[row][col] = numbers[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x * 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x / 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (!CheckCoordinatesValidity(row, column, jaggedArray))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (action == "Add")
                {
                    jaggedArray[row][column] += value;
                }
                else if (action == "Subtract")
                {
                    jaggedArray[row][column] -= value;
                }

                input = Console.ReadLine();
            }


            foreach (var line in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', line));
            }
        }

        private static bool CheckCoordinatesValidity(int row, int column, double[][] jaggedArray)
        {
            return row >= 0 && row < jaggedArray.Length &&
                   column >= 0 && column < jaggedArray[row].Length;
        }
    }
}
