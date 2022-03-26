using System;
using System.Collections.Generic;

namespace T04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] data = input.Split();

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = homeTown;

                students.Add(student);

                input = Console.ReadLine();
            }

            string cityName = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == cityName)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string HomeTown { get; set; }
        }
    }
}
