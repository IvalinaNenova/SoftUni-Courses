using System;
using System.Collections.Generic;

namespace T03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> wordsDictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (wordsDictionary.ContainsKey(word))
                {
                    wordsDictionary[word].Add(synonym);
                }
                else
                {
                    wordsDictionary.Add(word, new List<string>());
                    wordsDictionary[word].Add(synonym);
                }
            }

            foreach (var word in wordsDictionary)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
