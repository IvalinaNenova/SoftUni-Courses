using System;
using System.Text;

namespace T08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string text = input[i];
                char leftLetter = text[0];
                char rightLetter = text[text.Length-1];

                StringBuilder digit = new StringBuilder();

                for (int j = 1; j < text.Length - 1; j++)
                {
                    digit.Append(text[j]);
                }

                result = GetResult(leftLetter, result, digit, rightLetter);
            }

            Console.WriteLine($"{result:f2}");
        }

        private static decimal GetResult(char leftLetter, decimal result, StringBuilder digit, char rightLetter)
        {
            int position = 0;

            if (leftLetter >= 'a' && leftLetter <= 'z')
            {
                position = leftLetter - 'a' + 1;
                result += decimal.Parse(digit.ToString()) * position;
            }
            else if (leftLetter >= 'A' && leftLetter <= 'Z')
            {
                position = leftLetter - 'A' + 1;
                result += decimal.Parse(digit.ToString()) / position;
            }

            if (rightLetter >= 'a' && rightLetter <= 'z')
            {
                position = rightLetter - 'a' + 1;
                result += position;
            }
            else if (rightLetter >= 'A' && rightLetter <= 'Z')
            {
                position = rightLetter - 'A' + 1;
                result -= position;
            }

            return result;
        }
    }
}
