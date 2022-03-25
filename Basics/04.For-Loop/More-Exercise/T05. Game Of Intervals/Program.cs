using System;

namespace T05._Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());
            int numbers0to10 = 0;
            int numbers10to20 = 0;
            int numbers20to30 = 0;
            int numbers30to40 = 0;
            int numbers40to50 = 0;
            int invalidNumbers = 0;
            double totalPoints = 0;

            for (int i = 0; i < turns; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0 || number > 50)
                {
                    totalPoints /= 2;
                    invalidNumbers++;
                }
                else if (number < 10)
                {
                    totalPoints += number * 0.2;
                    numbers0to10++;
                }
                else if (number < 20)
                {
                    totalPoints += number * 0.3;
                    numbers10to20++;
                }
                else if (number < 30)
                {
                    totalPoints += number * 0.4;
                    numbers20to30++;
                }
                else if (number < 40)
                {
                    totalPoints += 50;
                    numbers30to40++;
                }
                else if (number <= 50)
                {
                    totalPoints += 100;
                    numbers40to50++;
                }

            }
            double p1 = 1.0 * numbers0to10 / turns * 100;
            double p2 = 1.0 * numbers10to20 / turns * 100;
            double p3 = 1.0 * numbers20to30 / turns * 100;
            double p4 = 1.0 * numbers30to40 / turns * 100;
            double p5 = 1.0 * numbers40to50 / turns * 100;
            double p6 = 1.0 * invalidNumbers / turns * 100;

            Console.WriteLine($"{totalPoints:f2}");
            Console.WriteLine($"From 0 to 9: {p1:f2}%");
            Console.WriteLine($"From 10 to 19: {p2:f2}%");
            Console.WriteLine($"From 20 to 29: {p3:f2}%");
            Console.WriteLine($"From 30 to 39: {p4:f2}%");
            Console.WriteLine($"From 40 to 50: {p5:f2}%");
            Console.WriteLine($"Invalid numbers: {p6:f2}%");
        }
    }
}
