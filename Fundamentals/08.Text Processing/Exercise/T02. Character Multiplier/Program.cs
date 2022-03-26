using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace T02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().OrderBy(word => word.Length).ToArray();

            StringBuilder word1 = new StringBuilder(words[0]);
            StringBuilder word2 = new StringBuilder(words[1]);

            int sum = GetSumOfChars(word1, word2);

            Console.WriteLine(sum);
        }

        private static int GetSumOfChars(StringBuilder word1, StringBuilder word2)
        {
            int sum = 0;

            while (word1.Length > 0)
            {
                sum += word1[0] * word2[0];
                word1.Remove(0, 1);
                word2.Remove(0, 1);
            }

            for (int i = 0; i < word2.Length; i++)
            {
                sum += word2[i];
            }

            return sum;
        }
    }
}
