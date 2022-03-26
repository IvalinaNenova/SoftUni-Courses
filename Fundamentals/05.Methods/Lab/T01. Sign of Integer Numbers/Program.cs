using System;

namespace T01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            PrintTSignOfNumber(inputNumber);
        }

        static void PrintTSignOfNumber(int number)
        {
            
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number<0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else
            {
                Console.WriteLine($"The number 0 is zero.");
            }
        }
    }
}
