using System;

namespace ExamProblem6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLoctions = int.Parse(Console.ReadLine());

            for (int location = 0; location < numberOfLoctions; location++)
            {
                double expectedAverageYieldPerDay = double.Parse(Console.ReadLine());
                int daysPerLocation = int.Parse(Console.ReadLine());
                double totalGoldPerLocation = 0;

                for (int day = 0; day < daysPerLocation; day++)
                {
                    double goldYieldPerDay = double.Parse(Console.ReadLine());
                    totalGoldPerLocation += goldYieldPerDay;
                }

                double averageGoldYielded = totalGoldPerLocation / daysPerLocation;

                if (averageGoldYielded >= expectedAverageYieldPerDay)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageGoldYielded:f2}.");
                }
                else
                {
                    double difference = expectedAverageYieldPerDay - averageGoldYielded;
                    Console.WriteLine($"You need {difference:f2} gold.");
                }
            }
        }
    }
}
