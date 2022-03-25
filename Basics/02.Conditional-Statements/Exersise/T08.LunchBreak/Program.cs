using System;

namespace T08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            int episodeMintes = int.Parse(Console.ReadLine());
            int lunchBreak = int.Parse(Console.ReadLine());

            double timeLeft = lunchBreak - lunchBreak * 0.125 - lunchBreak * 0.25;

            if (timeLeft >= episodeMintes)
            {
                Console.WriteLine($"You have enough time to watch {series} and left with {Math.Ceiling(timeLeft - episodeMintes)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {series}, you need {Math.Ceiling(episodeMintes - timeLeft)} more minutes.");
            }

        }
    }
}
