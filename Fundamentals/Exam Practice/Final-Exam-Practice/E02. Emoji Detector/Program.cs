using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace E02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            long coolTreshold = 1;

            foreach (char symbol in input.Where(symbol => char.IsDigit(symbol)))
            {
                coolTreshold *= int.Parse(symbol.ToString());
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");

            MatchCollection matches = Regex.Matches(input, @"(:{2}|\*{2})(?<emojis>[A-Z][a-z]{2,})\1");

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matches)
            {
                int coolness = 0;

                foreach (var symbol in match.Groups["emojis"].Value)
                {
                    coolness += symbol;
                }

                if (coolness > coolTreshold)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
