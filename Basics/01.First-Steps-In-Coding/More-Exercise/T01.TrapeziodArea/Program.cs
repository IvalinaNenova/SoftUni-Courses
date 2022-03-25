using System;

namespace T01.TrapeziodArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double TrapeziodArea = (b1 + b2) * h / 2;
            Console.WriteLine($"{TrapeziodArea:f2}");

        }
    }
}
