using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    internal class Classroom
    {
        //Next, write a C# class Classroom that has students (a collection, which stores the students) and a certain capacity. All entities inside the repository have the same fields. Also, the Classroom class should have the following properties:

        private List<Student> students;

        public int Capacity { get; set; }

        public int Count => students.Count;



        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            bool hasBeenRemoved = students.Remove(students.Find(e => e.FirstName == firstName && e.LastName == lastName));
            return hasBeenRemoved
                ? $"Dismissed student {firstName} {lastName}"
                : "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var filtered = students.Where(e => e.Subject == subject).ToList();

            if (filtered.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                StringBuilder output = new StringBuilder();

                output.AppendLine($"Subject: {subject}");
                output.AppendLine($"Students:");

                foreach (var student in filtered)
                {
                    output.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return output.ToString().TrimEnd();
            }
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.Find(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
