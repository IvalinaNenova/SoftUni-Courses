using System;

namespace T01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = int.Parse(Console.ReadLine());
            decimal kilometers = meters / 1000;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
