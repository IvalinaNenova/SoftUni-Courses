using System;
using System.Linq;

namespace T03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(word => char.IsUpper(word[0]))
                .ToArray();

            foreach (string word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}
