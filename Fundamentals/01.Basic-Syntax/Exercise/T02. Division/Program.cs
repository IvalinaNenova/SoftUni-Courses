using System;

namespace T02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int divider = 0;

            if (number % 10 == 0)
            {
                divider = 10;
            }
            else if (number % 7 == 0)
            {
                divider = 7;
            }
            else if (number % 6 == 0)
            {
                divider = 6;
            }
            else if (number % 3 == 0)
            {
                divider = 3;
            }
            else if (number % 2 == 0)
            {
                divider = 2;
            }


            if (divider == 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {divider}");
            }
        }
    }
}
