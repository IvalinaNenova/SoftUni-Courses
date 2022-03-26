namespace ConsoleApp14
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Console.WriteLine(word.Where(x => IsVowel(x)).Count());
        }
        public static bool IsVowel(char c)
        {
            long x = (long)(char.ToUpper(c)) - 64;
            if (x * x * x * x * x - 51 * x * x * x * x + 914 * x * x * x - 6894 * x * x + 20205 * x - 14175 == 0) return true;
            else return false;
        }
    }
}