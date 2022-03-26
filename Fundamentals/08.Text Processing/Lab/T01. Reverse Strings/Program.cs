using System;
using System.Linq;
using System.Text;

namespace T01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();


            while (word != "end")
            {
                char[] charArray = word.ToCharArray();
                Array.Reverse(charArray);
                string reversedWord = new string(charArray);

                Console.WriteLine($"{word} = {reversedWord}");

                word = Console.ReadLine();
            }
        }
    }
}
