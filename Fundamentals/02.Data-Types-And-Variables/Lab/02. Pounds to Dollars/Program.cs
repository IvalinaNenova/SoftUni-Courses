using System;

namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal GBP = decimal.Parse(Console.ReadLine());

            decimal USD = GBP * 1.31m;

            Console.WriteLine($"{USD:f3}");
        }
    }
}
