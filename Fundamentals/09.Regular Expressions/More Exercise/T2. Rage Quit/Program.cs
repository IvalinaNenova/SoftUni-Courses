using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T2._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\D]+)([0-9]+)";

            string inputString = Console.ReadLine();

            MatchCollection matches = Regex.Matches(inputString, pattern);
            StringBuilder outputString = new StringBuilder();

            foreach (Match match in matches)
            {
                string letters = match.Groups[1].Value;
                int count = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < count; i++)
                {
                    outputString.Append(letters.ToUpper());
                }
            }

            int uniqueChars = outputString.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {uniqueChars}");
            Console.WriteLine(outputString);
        }
    }
}
