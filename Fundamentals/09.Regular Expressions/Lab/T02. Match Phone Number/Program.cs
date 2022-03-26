using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359(\s|-)2\1\d{3}\1\d{4}\b";
            string phoneNumbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(phoneNumbers, pattern);

            string[] matchedPhones = matches.Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
