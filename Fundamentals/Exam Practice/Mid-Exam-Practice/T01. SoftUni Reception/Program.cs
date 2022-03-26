using System;

namespace T01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employeeOneEfficiency = int.Parse(Console.ReadLine());
            int employeeTwoEfficiency = int.Parse(Console.ReadLine());
            int employeeThreeEfficiency = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int totalEfficiency = employeeOneEfficiency + employeeTwoEfficiency + employeeThreeEfficiency;

            int time = 0;

            while (students>0)
            {
                students -= totalEfficiency;
                time++;

                if (time % 4 == 0)
                {
                    time++;
                }
            }

            Console.WriteLine($"Time needed: {time}h.");

        }
    }
}
