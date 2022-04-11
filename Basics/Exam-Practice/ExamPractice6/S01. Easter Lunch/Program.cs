using System;

namespace S01._Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfEasterBreads = int.Parse(Console.ReadLine());
            int numberOfEggCartons = int.Parse(Console.ReadLine());
            int killosOfCookies = int.Parse(Console.ReadLine());

            double total = numberOfEasterBreads * 3.20 + numberOfEggCartons * 4.35 + killosOfCookies * 5.40 + (numberOfEggCartons * 12) * 0.15;

            Console.WriteLine($"{total:f2}");

        }
    }
}
