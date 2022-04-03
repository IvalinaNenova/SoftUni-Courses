using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam_Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            string pattern = @"(?<=\s|^)([$|%])(?<tag>[A-Z][a-z]{2,})\1: (?<message>\[\d+\]\|\[\d+\]\|\[\d+\]\|)(?=\s|$)";

            for (int i = 0; i < numberOfInputs; i++)
            {
                string message = Console.ReadLine();
                Match match = Regex.Match(message, pattern);

                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value;
                    string encryptedMessage = match.Groups["message"].Value;

                    string[] asciiValues = encryptedMessage.Split(new[] {'|', ']', '['}, StringSplitOptions.RemoveEmptyEntries);

                    StringBuilder decryptedMessage = new StringBuilder();

                    foreach (var symbol in asciiValues)
                    {
                        decryptedMessage.Append((char) int.Parse(symbol));
                    }

                    Console.WriteLine($"{tag}: {decryptedMessage}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
