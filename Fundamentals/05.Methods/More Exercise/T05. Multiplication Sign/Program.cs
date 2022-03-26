using System;
using System.Collections.Generic;

namespace T05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int counter = 0;

            if (IsNumNegative(num1))
            {
                counter++;
            }
            if (IsNumNegative(num2))
            {
                counter++;
            }
            if (IsNumNegative(num3))
            {
                counter++;
            }

            if (counter % 2 == 1 && num1 != 0 && num2 != 0 && num3 != 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }

        private static bool IsNumNegative(int num)
        {
            if (num < 0)
            {
                return true;
            }
            return false;
        }
    }
}
