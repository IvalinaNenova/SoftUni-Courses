using System;

namespace Т01._Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int detergent = int.Parse(Console.ReadLine());
            int totalDetergentMililiters = detergent * 750;
            int detergentUsed = 0;
            string input = Console.ReadLine();
            int i = 1;
            int numberOfDishes = 0;
            int numberOfPots = 0;

            while (input != "End")
            {
                int dishes = int.Parse(input);
                if (i % 3 == 0)
                {
                    numberOfPots += dishes;
                    detergentUsed += dishes * 15;
                }
                else 
                {
                    numberOfDishes += dishes;
                    detergentUsed += dishes * 5;
                }
                if (detergentUsed > totalDetergentMililiters)
                {
                    break;
                }

                input = Console.ReadLine();
                i++;
            }

            int difference = Math.Abs(totalDetergentMililiters - detergentUsed);
            if (detergentUsed <= totalDetergentMililiters)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{numberOfDishes} dishes and {numberOfPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {difference} ml.");


            }
            else
            {
                Console.WriteLine($"Not enough detergent, {difference} ml. more necessary!");
            }
        }
    }
}
