using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double experienceNeeded = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());

            double playerExperience = 0;
            bool isSuccessfull = false;

            for (int battle = 1; battle <= battlesCount; battle++)
            {
                double currentBattleExp = double.Parse(Console.ReadLine());

                if (battle % 3 == 0)
                {
                    currentBattleExp *= 1.15;
                }

                if (battle % 5 == 0)
                {
                    currentBattleExp *= 0.9;
                }

                if (battle % 15 == 0)
                {
                    currentBattleExp *= 1.05;
                }

                playerExperience += currentBattleExp;

                if (playerExperience >= experienceNeeded)
                {
                    isSuccessfull = true;
                    Console.WriteLine($"Player successfully collected his needed experience for {battle} battles.");
                    break;
                }
            }

            if (!isSuccessfull)
            {
                double difference = experienceNeeded - playerExperience;
                Console.WriteLine($"Player was not able to collect the needed experience, {difference:f2} more needed.");
            }
        }
    }
}
