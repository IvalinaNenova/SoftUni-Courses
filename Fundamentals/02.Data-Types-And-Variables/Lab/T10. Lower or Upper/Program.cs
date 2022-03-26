using System;

namespace T10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());

            if (character >= 65 && character <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (character >= 97 && character <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
