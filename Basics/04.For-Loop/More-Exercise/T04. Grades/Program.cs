using System;

namespace T04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            double averageGrade = 0;
            int topStudents = 0;
            int between4and5 = 0;
            int between3and4 = 0;
            int failedStudents = 0;

            for (int i = 0; i < numberOfStudents; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                averageGrade += grade;
                if (grade < 3)
                {
                    failedStudents++;
                }
                else if (grade < 4)
                {
                    between3and4++;
                }
                else if (grade < 5)
                {
                    between4and5++;
                }
                else
                {
                    topStudents++;
                }

            }
            averageGrade = averageGrade / numberOfStudents;
            double topStudentsPercent = 1.0 * topStudents / numberOfStudents * 100;
            double between4and5StudentsPersent = 1.0 * between4and5 / numberOfStudents * 100;
            double between3and4StudentsPercent = 1.0 * between3and4 / numberOfStudents * 100;
            double failedStudentsPercent = 1.0 * failedStudents / numberOfStudents * 100;
            Console.WriteLine($"Top students: {topStudentsPercent:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {between4and5StudentsPersent:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {between3and4StudentsPercent:f2}%");
            Console.WriteLine($"Fail: {failedStudentsPercent:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
