using System;

namespace S04._Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string actorName = Console.ReadLine();
            double moneyLeft = budget;


            while (actorName != "ACTION")
            {
                if (actorName.Length > 15)
                {
                    moneyLeft -= moneyLeft * 0.2;
                }
                else
                {
                    moneyLeft -= double.Parse(Console.ReadLine());
                }
                if (moneyLeft < 0)
                {
                    break;
                }
                actorName = Console.ReadLine();
            }


            if (moneyLeft >= 0)
            {
                Console.WriteLine($"We are left with {moneyLeft:f2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(moneyLeft):f2} leva for our actors.");
            }
        }
    }
}
