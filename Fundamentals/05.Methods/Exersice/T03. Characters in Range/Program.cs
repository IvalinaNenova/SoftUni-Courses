using System;

namespace T03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char character1 = char.Parse(Console.ReadLine());
            char character2 = char.Parse(Console.ReadLine());

            char start = character1;
            char end = character2;

            if (character1 > character2)
            {
                start = character2;
                end = character1;
            }

            PrintCharactersInRange(start, end);
        }

        private static void PrintCharactersInRange(char start, char end)
        {

            for (char i = (char)(start + 1); i < end; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}
