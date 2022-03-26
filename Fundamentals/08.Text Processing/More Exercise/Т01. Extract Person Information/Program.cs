using System;

namespace Т01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int nameStartIndex = input.IndexOf('@');
                int nameEndIndex = input.IndexOf('|');

                string name = input.Substring(nameStartIndex + 1, nameEndIndex - nameStartIndex - 1);

                int ageStartIndex = input.IndexOf('#');
                int ageEndIndex = input.IndexOf('*');

                string age = input.Substring(ageStartIndex + 1, ageEndIndex - ageStartIndex - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
