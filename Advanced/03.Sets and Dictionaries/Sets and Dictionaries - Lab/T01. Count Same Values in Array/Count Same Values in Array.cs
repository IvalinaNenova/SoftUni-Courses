using System;
using System.Collections.Generic;

namespace T01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-2.5 4 3 - 2.5 - 5.5 4 3 3 - 2.5 3

            string[] numbersAsString = Console.ReadLine().Split(' ');
            Dictionary<double,int> numbers = new Dictionary<double,int>();

            foreach (var number in numbersAsString)
            {
                double num = double.Parse(number);

                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }

                numbers[num]++;
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
