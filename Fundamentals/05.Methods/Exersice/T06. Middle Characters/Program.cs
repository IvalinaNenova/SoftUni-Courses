using System;

namespace T06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string middle = GetMiddle(input);
            Console.WriteLine(middle);
        }

        static string GetMiddle(string input)
        {
            if (input.Length % 2 == 0)
            {
                return $"{input[input.Length / 2 - 1]}{ input[input.Length / 2]}";
            }

            return $"{input[(input.Length-1)/2]}";
        }
    }
}
