using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int countOfExceptions = 0;

            while (countOfExceptions != 3)
            {
                string[] commands = Console.ReadLine().Split();
                string action = commands[0];

                try
                {
                    switch (action)
                    {
                        case "Replace":
                        {
                            int index = int.Parse(commands[1]);
                            int element = int.Parse(commands[2]);

                            numbers[index] = element;
                            break;
                        }
                        case "Print":
                        {
                            int startIndex = int.Parse(commands[1]);
                            int endIndex = int.Parse(commands[2]);

                            var rangeToPrint = new List<int>();

                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                rangeToPrint.Add(numbers[i]);
                            }

                            Console.WriteLine(string.Join(", ", rangeToPrint));
                            break;
                        }
                        case "Show":
                        {
                            int index = int.Parse(commands[1]);
                            Console.WriteLine(numbers[index]);
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    countOfExceptions++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countOfExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
