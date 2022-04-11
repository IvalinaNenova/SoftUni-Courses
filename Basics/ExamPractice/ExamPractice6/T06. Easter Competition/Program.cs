using System;

namespace T06._Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEasterBreads = int.Parse(Console.ReadLine());
            int maxPoints = int.MinValue;
            string bestChef = "";

            for (int i = 0; i < numberOfEasterBreads; i++)
            {
                string name = Console.ReadLine();
                string command = Console.ReadLine();
                int pointsPerChef = 0;
                while (command!= "Stop" )
                {
                    int points = int.Parse(command);
                    pointsPerChef += points;

                    command = Console.ReadLine();
                }
                Console.WriteLine($"{name} has {pointsPerChef} points.");
                if (pointsPerChef>maxPoints)
                {
                    maxPoints = pointsPerChef;
                    bestChef = name;
                    Console.WriteLine($"{bestChef} is the new number 1!");
                }
            }
            Console.WriteLine($"{bestChef} won competition with {maxPoints} points!");
        }
    }
}
