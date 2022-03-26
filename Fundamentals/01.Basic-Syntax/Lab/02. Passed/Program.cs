using System;

namespace _02._Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 3)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
