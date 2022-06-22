using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, HashSet<char>>
            {
                {"pear", new HashSet<char> ()},
                {"flour", new HashSet<char>() },
                {"pork", new HashSet<char>() },
                {"olive", new HashSet<char>() }
            };

            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ').Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ').Select(char.Parse).ToArray());
            List<string> completedWords = new List<string>();

            while (consonants.Any())
            {
                char vowel = vowels.Peek();
                char consonant = consonants.Peek();

                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        word.Value.Add(vowel);
                    }
                    if (word.Key.Contains(consonant))
                    {
                        word.Value.Add(consonant);
                    }
                }
                consonants.Pop();
                vowels.Enqueue(vowels.Dequeue());
            }

            var filtered = words.Where(word => word.Key.Length == word.Value.Count).Select(word => word.Key).ToList();

            Console.WriteLine($"Words found: {filtered.Count}");
            foreach (var word in filtered)
            {
                Console.WriteLine(word);
            }
        }
    }
}