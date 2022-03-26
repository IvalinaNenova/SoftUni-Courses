using System;
using System.Collections.Generic;

namespace Т01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> countOfChars = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    if (!countOfChars.ContainsKey(input[i]))
                    {
                        countOfChars.Add(input[i], 0);
                    }

                    countOfChars[input[i]]++;
                }
            }

            foreach (var chars in countOfChars)
            {
                Console.WriteLine($"{chars.Key} -> {chars.Value}");
            }
        }
    }
}
