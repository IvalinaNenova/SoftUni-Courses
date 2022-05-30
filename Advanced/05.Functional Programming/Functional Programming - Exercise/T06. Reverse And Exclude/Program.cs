using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
           
            int divider = int.Parse(Console.ReadLine());

            Predicate<int> filter = num => num % divider != 0;

            numbers.Reverse();
            numbers = MyWhere(numbers, filter);

            Console.WriteLine(string.Join(' ', numbers));
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> filter)
        {
            List<int> newList = new List<int>();
            foreach (var number in numbers)
            {
                if (filter(number))
                {
                    newList.Add(number);
                }
            }

            return newList;
        }
    }
}
