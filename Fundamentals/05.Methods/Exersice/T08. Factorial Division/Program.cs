using System;

namespace T08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = Math.Abs(int.Parse(Console.ReadLine()));
            int secondNumber = Math.Abs(int.Parse(Console.ReadLine()));

            double factorialOfFirst = GetFactorial(firstNumber);
            double factorialOfSecond = GetFactorial(secondNumber);

            double result =factorialOfFirst / factorialOfSecond;

            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorial(int n)
        {
            double factorial = n;

            for (int i = n - 1; i > 0; i--)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
