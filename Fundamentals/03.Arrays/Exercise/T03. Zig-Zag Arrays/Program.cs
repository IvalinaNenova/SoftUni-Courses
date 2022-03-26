using System;
using System.Globalization;
using System.Linq;

namespace T03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array1 = new int[n];
            int[] array2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 != 0)
                {
                    array1[i] = numbers[0];
                    array2[i] = numbers[1];
                }
                else
                {
                    array2[i] = numbers[0];
                    array1[i] = numbers[1];
                }
            }

            Console.WriteLine(string.Join(" ", array2));
            Console.WriteLine(string.Join(" ", array1));
        }
    }
}
