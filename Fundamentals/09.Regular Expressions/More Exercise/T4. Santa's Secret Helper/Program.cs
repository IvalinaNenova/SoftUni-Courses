using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace T4._Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string encryptedMessage = Console.ReadLine();

            List<string> goodChildren = new List<string>();

            while (encryptedMessage != "end")
            {
                string decryptedMessage = DecryptMessage(encryptedMessage, key);
                string validPattern = @"@(?<name>[A-Za-z]+)[^\-@!:>]*![G]!";

                Match match = Regex.Match(decryptedMessage, validPattern);

                if (match.Success)
                {
                    string childName = match.Groups["name"].Value;

                    goodChildren.Add(childName);
                }

                encryptedMessage = Console.ReadLine();
            }

            foreach (string child in goodChildren)
            {
                Console.WriteLine(child);
            }
        }

        private static string DecryptMessage(string encryptedMessage, int key)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            foreach (char symbol in encryptedMessage)
            {
                decryptedMessage.Append((char)(symbol - key));
            }

            return decryptedMessage.ToString();
        }
    }
}
