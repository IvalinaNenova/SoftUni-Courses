using System;

namespace T06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int tempNum = num;
            int sum = 0;

            while (tempNum > 0)
            {
                int digit = tempNum % 10;
                tempNum /= 10;

                int factorial = 1;

                for (int i = digit; i > 0; i--)
                {
                    factorial *= i;
                }

                sum += factorial;
            }

            if (sum == num)
            {
                Console.WriteLine("yes");

            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
