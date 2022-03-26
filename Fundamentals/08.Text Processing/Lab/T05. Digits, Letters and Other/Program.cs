using System;

namespace T05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string other = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    digits += input[i];
                }
                else if (Char.IsLetter(input[i]))
                {
                    letters += input[i];
                }
                else
                {
                    other += input[i];
                }
            }

            Console.WriteLine($"{digits}\n{letters}\n{other}");
        }
    }
}
