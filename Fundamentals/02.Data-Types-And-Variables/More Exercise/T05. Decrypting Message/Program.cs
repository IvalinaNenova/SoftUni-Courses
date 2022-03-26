using System;

namespace T05._Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfInputs = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < numberOfInputs; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                int newLetter = Convert.ToInt32(letter) + key;

                message += (char)newLetter;
            }

            Console.WriteLine(message);
        }
    }
}
