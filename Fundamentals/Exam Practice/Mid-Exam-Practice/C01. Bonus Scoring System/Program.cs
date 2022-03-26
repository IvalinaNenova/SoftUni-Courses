using System;

namespace C01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int bestAttendance = 0;

            for (int i = 0; i < numberOfStudents; i++)
            {
                int currentStudentAttendance = int.Parse(Console.ReadLine());

                double currentStudentBonus = (double)currentStudentAttendance / numberOfLectures * (5 + additionalBonus);

                if (currentStudentBonus > maxBonus)
                {
                    maxBonus = currentStudentBonus;
                    bestAttendance = currentStudentAttendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {bestAttendance} lectures.");
        }
    }
}
