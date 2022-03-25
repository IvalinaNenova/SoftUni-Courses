using System;

namespace T06.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string ActorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int numberOfJudges = int.Parse(Console.ReadLine());
            double totalPoints = academyPoints;

            for (int i = 0; i < numberOfJudges; i++)
            {
                string judgeName = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());
               
                double totalPointsFromJudge = (judgeName.Length * points) / 2;
                totalPoints += totalPointsFromJudge;

                if (totalPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {ActorName} got a nominee for leading role with {totalPoints:f1}!");
                    break;
                }

            }

            if (totalPoints <= 1250.5)
            {
                Console.WriteLine($"Sorry, {ActorName} you need {1250.5 - totalPoints:f1} more!");
            }

        }
    }
}
