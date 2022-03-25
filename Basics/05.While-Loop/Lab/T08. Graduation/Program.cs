using System;

namespace T08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            int fail = 0;
            double total = 0;

            while (grade <= 12)
            {
                double yearlyGradeAverage = double.Parse(Console.ReadLine());
                total += yearlyGradeAverage;

                if (grade == 12)
                {
                    double averageGrade = total / grade;
                    Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
                }

                grade++;

                if (yearlyGradeAverage < 4)
                {
                    grade--;
                    fail++;
                    if (fail == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                }
            }
        }
    }
}
