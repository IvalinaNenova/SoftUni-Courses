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
                    int maxElement = int.MinValue;

                    if (numbers.Count > 0)
                    {
                        while (numbers.Count > 0)
                        {
                            int currentElement = numbers.Pop();
                            tempListOfElements.Add(currentElement);
                            if (currentElement > maxElement)
                            {
                                maxElement = currentElement;
                            }
                        }

                        Console.WriteLine(maxElement);

                        for (int j = tempListOfElements.Count - 1; j >= 0; j--)
                        {
                            numbers.Push(tempListOfElements[j]);
                        }
                    }

                }
                else if (queryType[0] == "4")
                {
                    int minElement = int.MaxValue;

                    if (numbers.Count > 0)
                    {
                        while (numbers.Count > 0)
                        {
                            int currentElement = numbers.Pop();
                            tempListOfElements.Add(currentElement);

                            if (currentElement < minElement)
                            {
                                minElement = currentElement;
                            }
                        }

                        Console.WriteLine(minElement);

                        for (int j = tempListOfElements.Count-1; j >= 0; j--)
                        {
                            numbers.Push(tempListOfElements[j]);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
