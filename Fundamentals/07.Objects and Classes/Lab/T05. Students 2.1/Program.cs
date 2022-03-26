using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Students_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> listOfStudents = new List<Student>();

            while (input != "end")
            {
                string[] data = input.Split();

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];

                Student student = listOfStudents.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

                if (student == null)
                {
                    listOfStudents.Add(new Student ()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    });
                }
                else
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                }

                input = Console.ReadLine();
            }

            string city = Console.ReadLine();

            List<Student> filteredStudents = listOfStudents.Where(s => s.HomeTown == city).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
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
