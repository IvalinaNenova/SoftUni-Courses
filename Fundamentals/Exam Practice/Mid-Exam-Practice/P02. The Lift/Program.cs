using System;
using System.Linq;

namespace P02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeopleWaiting = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            const int maxCapacity = 4;

            for (int i = 0; i < lift.Length; i++)
            {
                while (lift[i] < maxCapacity && numberOfPeopleWaiting > 0)
                {
                    lift[i]++;
                    numberOfPeopleWaiting--;
                }
            }

            if (lift.Any(n => n != 4))
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (numberOfPeopleWaiting != 0)
            {
                Console.WriteLine($"There isn't enough space! {numberOfPeopleWaiting} people in a queue!");
            }
            

            Console.WriteLine(string.Join(" ", lift));
        }
    }
}
