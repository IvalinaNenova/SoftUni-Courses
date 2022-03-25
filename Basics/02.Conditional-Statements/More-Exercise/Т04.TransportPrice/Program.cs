using System;

namespace Т04.TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double taxi = 0.0;
            double bus = kilometers * 0.09;
            double train = kilometers * 0.06;
            if (timeOfDay == "day")
            {
                taxi = kilometers * 0.79 + 0.70;
            }
            else if (timeOfDay == "night")
            {
                taxi = kilometers * 0.90 + 0.70;
            }

            if (kilometers < 20)
            {
                Console.WriteLine($"{taxi:f2}");
            }
            else if (kilometers >= 20 && kilometers <100)
            {
                Console.WriteLine($"{bus:f2}");
            }
            else
            {
                Console.WriteLine($"{train:f2}");
            }
        }
    }
}
