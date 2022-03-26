using System;
using System.Linq;

namespace T08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lenght = numbers.Length - 1;

            if (numbers.Length != 1)
            {
                for (int i = 0; i < lenght; i++)
                {
                    int[] condensedNumbers = new int[numbers.Length - 1];

                    for (int j = 0; j < condensedNumbers.Length; j++)
                    {
                        condensedNumbers[j] = numbers[j] + numbers[j + 1];
                    }
                    numbers = condensedNumbers;
                }
            }
                Console.WriteLine(numbers[0]);
        }
    }
}
