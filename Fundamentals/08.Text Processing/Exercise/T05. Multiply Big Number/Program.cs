using System;
using System.Text;

namespace T05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
           int multiplier = int.Parse(Console.ReadLine());

           StringBuilder finalResult = new StringBuilder();

           int remainder = 0;

           for (int i = input.Length - 1; i >= 0; i--)
           {
               int digit = int.Parse(input[i].ToString());
               int product = digit * multiplier + remainder;
               int result = product % 10;
               remainder = product / 10;
               finalResult.Insert(0, result);
           }

           if (remainder >0)
           {
               finalResult.Insert(0, remainder);
           }

           if (multiplier == 0)
           {
               finalResult = finalResult.Remove(1, finalResult.Length - 1);
           }

           Console.WriteLine(finalResult);
        }
    }
}
