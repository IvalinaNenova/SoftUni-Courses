using System;
using System.Text;

namespace T03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToSearch = Console.ReadLine();

            string text = Console.ReadLine();

            int index = text.IndexOf(wordToSearch);

            while (index >= 0)
            {
                text = text.Remove(index, wordToSearch.Length);
                index = text.IndexOf(wordToSearch);
            }

            Console.WriteLine(text);
        }
    }
}
