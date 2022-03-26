using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsData = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (studentsData.ContainsKey(student))
                {
                    studentsData[student].Add(grade);
                }
                else
                {
                    studentsData.Add(student, new List<double>());
                    studentsData[student].Add(grade);
                }
            }

            foreach (var student in studentsData)
            {
                double averageGrade = student.Value.Average();

                if (averageGrade >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:f2}");
                }
            }
        }
    }
}
