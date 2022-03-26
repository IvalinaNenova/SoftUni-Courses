using System;
using System.Text.RegularExpressions;

namespace T06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(?<=\s|^)[a-z0-9]+[\.\-_a-z0-9]+@[a-z\-]+\.([\.A-Za-z]+)+\b";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
    }
}
