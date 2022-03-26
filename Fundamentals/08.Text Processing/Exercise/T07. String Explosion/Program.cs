using System;
using System.Text;
using Microsoft.VisualBasic;

namespace T07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int lastBomb = text.LastIndexOf('>');

            StringBuilder sb = new StringBuilder();

            int strength = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (symbol != '>' && strength > 0)
                {
                    strength--;

                }
                else if (symbol == '>')
                {
                    sb.Append(symbol);
                    strength += int.Parse(text[i + 1].ToString());
                }
                else
                {
                    sb.Append(symbol);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
