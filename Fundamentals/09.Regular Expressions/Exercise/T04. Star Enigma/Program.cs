using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string decryptedMessage = DecryptedMessage(input).ToString();

                string pattern =
                    @"[^@\-!:>]*@(?<name>[A-Za-z]*)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>(?:A|D))![^@\-!:>]*->(?<soldiers>\d+)";
                Match match = Regex.Match(decryptedMessage, pattern);

                if (match.Success)
                {
                    string planetName = match.Groups["name"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            PrintOutput(attackedPlanets, destroyedPlanets);
        }
        private static StringBuilder DecryptedMessage(string input)
        {
            string decryptPattern = @"[star]";
            int count = Regex.Matches(input, decryptPattern, RegexOptions.IgnoreCase).Count;

            StringBuilder decryptedMessage = new StringBuilder();

            foreach (var symbol in input)
            {
                decryptedMessage.Append((char)(symbol - count));
            }

            return decryptedMessage;
        }

        public static void PrintOutput(List<string> attacked, List<string> destroyed)
        {
            int attackedCount = attacked.Count;
            int destroyedCount = destroyed.Count;

            string output = $"Attacked planets: {attackedCount}\n";

            if (attacked.Count > 0)
            {
                foreach (var planet in attacked.OrderBy(x=>x))
                {
                    output += $"-> {planet}\n";
                }
            }

            output += $"Destroyed planets: {destroyedCount}\n";

            if (destroyed.Count > 0)
            {
                foreach (var planet in destroyed.OrderBy(x => x))
                {
                    output += $"-> {planet}\n";
                }
            }

            Console.WriteLine(output.Trim());
        }
    }
}
