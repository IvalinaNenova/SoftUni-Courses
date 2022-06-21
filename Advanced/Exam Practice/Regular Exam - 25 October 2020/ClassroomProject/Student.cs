using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    internal class Student
    {
        //First, write a C# class Student with the following properties:
        //•	FirstName: string
        //•	LastName: string
        //•	Subject: string
        //    The class constructor should receive firstName, lastName and subject.You need to create the appropriate getters and setters.The class should override the ToString() method in the following format:
        //"Student: First Name = {firstName}, Last Name = {lastName}, Subject = {subject}"
        private string firstName;
        private string lastName;
        private  string subject;
        public string FirstName 
        { 
            get=> firstName;
            set => firstName = value;

        }

        public string LastName
        {
            get=> lastName;
            set=> lastName = value;
        }

        public string Subject
        {
            get=> subject;
            set=> subject = value;
        }

        public Student(string firstName, string lastName, string subject)
        {
            this.firstName = firstName; 
            this.lastName = lastName;
            this.subject = subject;
        }

        public override string ToString()
        {
            return $"Student: First Name = {firstName}, Last Name = {lastName}, Subject = {subject}";
        }
    }
}
