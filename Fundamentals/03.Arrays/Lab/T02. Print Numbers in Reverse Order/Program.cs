using System;

namespace T02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            //for (int i = numbers.Length-1; i >= 0; i--)
            //{
            //    Console.Write(numbers[i] + " ");
            //}

            //int[] reversedNumbers = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    reversedNumbers[i] = numbers[numbers.Length - i - 1];
            //    Console.Write(reversedNumbers[i] + " ");
            //}

            //for (int i = 0; i < n/2; i++)
            //{
            //    int temp = numbers[i];
            //    numbers[i] = numbers[numbers.Length - i - 1];
            //    numbers[numbers.Length - i - 1] = temp;
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(numbers[i] + " ");

            //}

            Array.Reverse(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
