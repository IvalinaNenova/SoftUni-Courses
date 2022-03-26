using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Т3._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputMessage = Console.ReadLine().Split("|");

            string capitalLettersPattern = @"(\$|#|%|\*|&)([A-Z]+)\1";
           
            Match match = Regex.Match(inputMessage[0], capitalLettersPattern);
            string capitalLetters = match.Groups[2].Value;

            string digitsPattern = @"(\d{2}):(\d{2})";
            MatchCollection digits = Regex.Matches(inputMessage[1], digitsPattern);
            

            foreach (var symbol in capitalLetters)
            {
                foreach (Match number in digits)
                {
                    char charFound = (char)int.Parse(number.Groups[1].Value);
                    int wordLength = int.Parse(number.Groups[2].Value);

                    if (symbol == charFound)
                    {
                        string wordPattern = $@"(?<=\s|^)[{symbol}][^\s]{{{wordLength}}}\b";
                        Match word = Regex.Match(inputMessage[2], wordPattern);

                        Console.WriteLine(word);
                        break;
                    }
                }
            }
        }
    }
}
