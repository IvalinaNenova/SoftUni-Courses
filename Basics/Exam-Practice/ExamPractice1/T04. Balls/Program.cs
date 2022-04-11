using System;

namespace T04._Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double totalPoints = 0;
            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int whiteBalls = 0;
            int otherBalls = 0;
            int divides = 0;

            for (int i = 0; i < n; i++)
            {
                string color = Console.ReadLine();
                switch (color)
                {
                    case "red":
                        totalPoints += 5;
                        redBalls++;
                        break;

                    case "orange":
                        totalPoints += 10;
                        orangeBalls++;
                        break;

                    case "yellow":
                        totalPoints += 15;
                        yellowBalls++;
                        break;

                    case "white":
                        totalPoints += 20;
                        whiteBalls++;
                        break;
                    case "black":

                        totalPoints = Math.Floor(totalPoints / 2);
                        divides++;
                        break;

                    default:
                        otherBalls++;
                        break;
                }
            }

            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Red balls: {redBalls}");
            Console.WriteLine($"Orange balls: {orangeBalls}");
            Console.WriteLine($"Yellow balls: {yellowBalls}");
            Console.WriteLine($"White balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherBalls}");
            Console.WriteLine($"Divides from black balls: {divides}");
           
        }
    }
}
