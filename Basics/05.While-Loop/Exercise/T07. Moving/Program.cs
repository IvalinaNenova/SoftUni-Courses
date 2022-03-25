using System;

namespace T07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int usedCubicMeters = 0;
            int totalCubicMeters = width * height * lenght;
            string input = Console.ReadLine();

            while (input != "Done")
            {
                int boxes = int.Parse(input);
                usedCubicMeters += boxes;
                if (usedCubicMeters >=totalCubicMeters)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs (usedCubicMeters - totalCubicMeters)} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (totalCubicMeters >usedCubicMeters)
            {
                Console.WriteLine($"{Math.Abs (usedCubicMeters - totalCubicMeters)} Cubic meters left.");
            }
        }
    }
}
