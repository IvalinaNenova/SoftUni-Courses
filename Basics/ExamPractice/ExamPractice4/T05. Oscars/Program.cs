using System;

namespace T05._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academiPoints = double.Parse(Console.ReadLine());
            int numberOfJudges = int.Parse(Console.ReadLine());
            double totalPoints = academiPoints;

            for (int i = 1; i <= numberOfJudges; i++)
            {
                string judgeName = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());
                totalPoints += points * judgeName.Length / 2;

                if (totalPoints>=1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {totalPoints:f1}!");
                    break;
                }

            }
            if (totalPoints<1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5-totalPoints:f1} more!");
            }

        }
    }
}
