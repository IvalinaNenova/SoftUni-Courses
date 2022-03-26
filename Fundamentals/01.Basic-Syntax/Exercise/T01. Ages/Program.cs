using System;

namespace T01._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string ageGroup = string.Empty;

            if (age >= 66)
            {
                ageGroup = "elder";
            }
            else if (age >= 20)
            {
                ageGroup = "adult";
            }
            else if (age >= 14)
            {
                ageGroup = "teenager";
            }
            else if (age >= 3)
            {
                ageGroup = "child";
            }
            else if (age >= 0)
            {
                ageGroup = "baby";
            }

            Console.WriteLine(ageGroup);
        }
    }
}
