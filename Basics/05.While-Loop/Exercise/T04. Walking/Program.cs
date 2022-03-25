using System;

namespace T04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalSteps = 0;
            while (input != "Going home")
            {
                int steps = int.Parse(input);
                totalSteps += steps;
                if (totalSteps >=10000)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            if (input == "Going home")
            {
                int stepsToHome = int.Parse(Console.ReadLine());
                totalSteps += stepsToHome;
                
            }

            int difference = Math.Abs(10000 - totalSteps);

            if (totalSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{difference} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{difference} more steps to reach goal.");
            }
        }
    }
}
