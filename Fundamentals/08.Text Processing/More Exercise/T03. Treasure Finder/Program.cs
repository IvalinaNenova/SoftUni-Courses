using System;
using System.Linq;
using System.Text;

namespace T03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string encryptedMessage = Console.ReadLine();


            while (encryptedMessage != "find")
            {
                StringBuilder message = new StringBuilder();

                int key = 0;
                for (int i = 0; i < encryptedMessage.Length; i++)
                {
                    message.Append((char) (encryptedMessage[i] - keys[key]));
                    key++;

                    if (key > keys.Length-1)
                    {
                        key = 0;
                    }
                }

                string decryptedMessage = message.ToString();

                string treasure = GetString(decryptedMessage, '&');
                string coordinates = GetString(decryptedMessage, '<');

                Console.WriteLine($"Found {treasure} at {coordinates}");

                encryptedMessage = Console.ReadLine();
            }
        }

        private static string GetString(string decryptedMessage, char symbol)
        {
            int startIndex = decryptedMessage.IndexOf(symbol);
            int endIndex = decryptedMessage.LastIndexOf(symbol);

            if (symbol == '<')
            {
                endIndex = decryptedMessage.Length - 1;
            }

            string word = decryptedMessage.Substring(startIndex + 1, endIndex - startIndex - 1);
            return word;
        }
    }
}
