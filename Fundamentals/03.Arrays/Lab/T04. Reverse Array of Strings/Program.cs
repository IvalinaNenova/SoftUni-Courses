using System;
using System.Linq;

namespace T04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] symbols = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < symbols.Length; i++)
            {
                string[] reversedSymbols = new string[symbols.Length];
                reversedSymbols[i] = symbols[symbols.Length - i - 1];
                Console.Write(reversedSymbols[i] + " ");
            }
            
            Console.WriteLine(String.Join(" ", symbols.Reverse()));
        }
    }
}
