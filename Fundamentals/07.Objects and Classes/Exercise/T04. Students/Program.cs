using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Students
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName{ get; set; }

        public double  Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> studentList = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentData = Console.ReadLine().Split();

                string firstName = studentData[0];
                string lastName = studentData[1];
                double grade = double.Parse(studentData[2]);

                studentList.Add(new Student(firstName, lastName, grade));
            }

            List<Student> sortedList = studentList.OrderByDescending(student => student.Grade).ToList();

            foreach (Student student in sortedList)
            {
                Console.WriteLine(student);
            }


        }
    }
}
