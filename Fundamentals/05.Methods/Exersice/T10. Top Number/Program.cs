using System;

namespace T10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
               bool isTop = CheckConditions(i);

                if (isTop)
                {
                    Console.WriteLine(i);
                }

            }
        }

        private static bool CheckConditions(int number)
        {
           
            int sum = 0;

            bool hasOddDigit = false;
            bool isDivisibleBy8 = false;
            bool isTopNumber = false;

            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                sum += digit;

                if (digit % 2 == 1)
                {
                   hasOddDigit = true;
                }
            }

            if (sum % 8 == 0)
            {
                isDivisibleBy8 = true;
            }

            if (isDivisibleBy8 && hasOddDigit)
            {
                return isTopNumber = true;
            }

            return isTopNumber;
        }
    }
}
