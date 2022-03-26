using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(word => word.ToLower()).ToArray();

            Dictionary<string, int> wordAppearance = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!wordAppearance.ContainsKey(words[i]))
                {
                   wordAppearance.Add(words[i],0); 
                }

                wordAppearance[words[i]]++;
            }

            foreach (var word in wordAppearance)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
