using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < numberOfQueries; i++)
            {
                List<int> tempListOfElements = new List<int>();
                string[] queryType = Console.ReadLine().Split();

                if (queryType[0] == "1")
                {
                    int elementToAdd = int.Parse(queryType[1]);
                    numbers.Push(elementToAdd);
                }
                else if (queryType[0] == "2")
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }
                else if (queryType[0] == "3")
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }
                else if (queryType[0] == "4")
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
