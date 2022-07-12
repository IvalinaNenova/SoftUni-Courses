using System;

namespace _01._Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int number = int.Parse(Console.ReadLine());

                double result = GetSqrt(number);
                Console.WriteLine(result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public static double GetSqrt(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }

            return Math.Sqrt(number);
        }
    }
}
