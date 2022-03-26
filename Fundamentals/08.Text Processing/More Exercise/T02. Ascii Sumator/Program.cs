using System;

namespace T02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startSymbol = char.Parse(Console.ReadLine());
            char endSymbol = char.Parse(Console.ReadLine());

            string text = Console.ReadLine();
            int sum = 0;

            for (int i = startSymbol + 1; i < endSymbol; i++)
            {
                foreach (char symbol in text)
                {
                    if (symbol == (char)i)
                    {
                        sum += i;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
