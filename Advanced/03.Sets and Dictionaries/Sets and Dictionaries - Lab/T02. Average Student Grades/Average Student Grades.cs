using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentData = Console.ReadLine().Split(' ');
                string studentName = studentData[0];
                decimal studentGrade = decimal.Parse(studentData[1]);

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new List<decimal>();
                }
                students[studentName].Add(studentGrade);
            }

            foreach (var student in students)
            {
                decimal averageGrade = student.Value.Average();
                string gradesAsString = string.Join(" ", student.Value.Select(grade => grade.ToString("f2")));

                Console.WriteLine($"{student.Key} -> {gradesAsString} (avg: {averageGrade:f2})");
            }
        }
    }
}
