using System;

namespace Т09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                Console.WriteLine(CheckIfPalindrome(command)); 

                command = Console.ReadLine();
            }
        }

        private static bool CheckIfPalindrome(string command)
        {
            int number = int.Parse(command);
            int tempValue = number;
            int reversedNumber = 0;
            bool IsPalindrome = false;

            while (tempValue > 0)
            {
                reversedNumber = reversedNumber * 10 + tempValue % 10;
                tempValue /= 10;
            }

            if (reversedNumber == number)
            {
                IsPalindrome = true;
            }

            return IsPalindrome;
        }
    }
}
