using System;
using System.Text;

namespace T04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder encryptedText = new StringBuilder();

            foreach (char symbol in text)
            {
                encryptedText.Append((char)(symbol + 3));
            }

            Console.WriteLine(encryptedText);
        }
    }
}
