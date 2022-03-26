using System;

namespace T01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();

            Random random = new Random();
            
            for (int i = 0; i < words.Length; i++)
            {
                int index = random.Next(words.Length);
                (words[i], words[index]) = (words[index], words[i]);
            }

            Console.WriteLine(string.Join("\n", words));

        }
    }
}
