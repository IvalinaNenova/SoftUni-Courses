using System;

namespace T04._Refactoring_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());

            for (int number = 2; number <= rangeEnd; number++)
            {
                string isPrime = "true";

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = "false";
                        break;
                    }
                }
                Console.WriteLine($"{number} -> {isPrime}");
            }

        }
    }
}
