using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace C02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(@|#)(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);
            List<string[]> mirrorWords = new List<string[]>();

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            foreach (Match match in matches)
            {
                string word1 = match.Groups["word1"].Value;
                string word2 = match.Groups["word2"].Value;

                string word2Reversed = string.Join("", word2.Reverse());

                if (word1 == word2Reversed)
                {
                    mirrorWords.Add(new string[] { word1, word2 });
                }
            }

            if (mirrorWords.Count > 0)
            {
                string[] words = mirrorWords.Select(word => $"{word[0]} <=> {word[1]}").ToArray();
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine(string.Join(", ", words));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
