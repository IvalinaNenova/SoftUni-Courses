using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person()
            {
                Name = "Peter",
                Age = 20
            };

            Console.WriteLine(person1.Name+ " " +person1.Age);
        }
    }

   
}
