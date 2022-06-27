using System;

namespace Person
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age < 0)
            {
                return;
            }

            Person person;

            person = age <= 15 ? new Child(name, age) : new Person(name, age);

            Console.WriteLine(person);

        }
    }
}
