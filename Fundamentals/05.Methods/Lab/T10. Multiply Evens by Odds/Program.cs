using System;

namespace T10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            GetMultipleOfEvenAndOdds(GetSumOfOddDigits(number), GetSumOfEvenDigits(number));

        }

        static int GetSumOfOddDigits(int number)
        {
            int oddNumbersSum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 1)
                {
                    oddNumbersSum += digit;
                }
                number /= 10;
            }
            return oddNumbersSum;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenDigitsSum = 0;

            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    evenDigitsSum += digit;
                }
                number /= 10;
            }
            return evenDigitsSum;
        }
        static void GetMultipleOfEvenAndOdds(int evenDigitSum, int oddDigitSum)
        {
            int result = evenDigitSum * oddDigitSum;

            Console.WriteLine(result);
        }
    }
}
