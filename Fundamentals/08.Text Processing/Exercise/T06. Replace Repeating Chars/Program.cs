using System;
using System.Text;

namespace T06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < text.Length-1; i++)
            {
                if (text[i] == text[i+1])
                {
                    text.Remove(i + 1, 1);
                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}
