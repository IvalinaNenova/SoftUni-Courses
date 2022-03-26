using System;
using System.Linq;

namespace T02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            PrintVowelsCount(text);
        }

        private static void PrintVowelsCount(string text)
        {
            char[] vowels = { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
            int vowelsCounter = 0;

            foreach (char ch in text)
            {
                if (vowels.Contains(ch))
                {
                    vowelsCounter++;
                }
            }

            //for (int i = 0; i < text.Length; i++)
            //{
            //    for (int j = 0; j < vowels.Length; j++)
            //    {
            //        if (text[i] == vowels[j])
            //        {
            //            vowelsCounter++;
            //        }
            //    }
            //}

            Console.WriteLine(vowelsCounter);
        }
    }
}
