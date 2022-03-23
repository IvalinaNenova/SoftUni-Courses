using System;

namespace T07.ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());
            int timeNeeded = numberOfProjects * 3;

            Console.WriteLine($"The architect {name} will need {timeNeeded} hours to complete {numberOfProjects} project/s.");

        }
    }
}
