using System;
using System.Linq;

namespace T06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] arrays = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                arrays[i] = new int[numbers.Length];

                for (int j = 0; j < numbers.Length; j++)
                {
                    arrays[i][j] = numbers[j];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split(' ');
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);

                if (row < 0 || row > arrays.Length - 1 ||
                    col < 0 || col > arrays[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }
                string action = commands[0];
                int value = int.Parse(commands[3]);

                if (action == "Add")
                {
                    arrays[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    arrays[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            foreach (int[] array in arrays)
            {
                Console.WriteLine(string.Join(' ', array));
            }
        }
    }
}
