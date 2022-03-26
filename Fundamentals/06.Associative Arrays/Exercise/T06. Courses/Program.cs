using System;
using System.Collections.Generic;

namespace T06._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputData = input.Split(" : ");
                string courseName = inputData[0];
                string studentName = inputData[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses[courseName].Add(studentName);
                }

                input = Console.ReadLine();
            }

            foreach (var course in courses)
            {
                int numberOfStudent = course.Value.Count;

                Console.WriteLine($"{course.Key}: {numberOfStudent}");

                for (int i = 0; i < course.Value.Count; i++)
                {
                    Console.WriteLine($"-- {course.Value[i]}");
                }
            }
        }
    }
}
