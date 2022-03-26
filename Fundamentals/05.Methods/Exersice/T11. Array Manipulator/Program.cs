using System;
using System.Collections.Generic;
using System.Linq;

namespace T11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] action = command.Split();

                if (action[0] == "exchange")
                {
                    Exchange(array, action);
                }

                else if (action[0] == "max")
                {
                    PrintMaxIndex(array, action);
                }

                else if (action[0] == "min")
                {
                    PrintMinIndex(array, action);
                }

                else if (action[0] == "last")
                {
                    PrintLastEvenOrOdd(array, action);
                }

                else if (action[0] == "first")
                {
                    PrintFirstEvenOrOdd(array, action);
                }
            }

            Console.WriteLine($"[{String.Join(", ", array)}]");
        }

        private static void PrintFirstEvenOrOdd(int[] array, string[] action)
        {
            int count = int.Parse(action[1]);
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (action[2] == "odd")
                {
                    List<int> oddNumbers = array.Where(x => x % 2 != 0).ToList();

                    if (oddNumbers.Count >= count)
                    {
                        Console.WriteLine($"[{string.Join(", ", oddNumbers.Take(count))}]");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", oddNumbers)}]");
                    }

                }
                else if (action[2] == "even")
                {
                    List<int> evenNumbers = array.Where(x => x % 2 == 0).ToList();

                    if (evenNumbers.Count >= count)
                    {
                        Console.WriteLine($"[{string.Join(", ", evenNumbers.Take(count))}]");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", evenNumbers)}]");
                    }
                }
            }
        }

        private static void PrintLastEvenOrOdd(int[] array, string[] action)
        {
            int count = int.Parse(action[1]);

            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (action[2] == "odd")
                {
                    List<int> oddNumbers = array.Where(x => x % 2 != 0).ToList();

                    if (oddNumbers.Count >= count)
                    {
                        Console.WriteLine($"[{string.Join(", ", oddNumbers.TakeLast(count))}]");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", oddNumbers)}]");
                    }

                }
                else if (action[2] == "even")
                {
                    List<int> evenNumbers = array.Where(x => x % 2 == 0).ToList();

                    if (evenNumbers.Count >= count)
                    {
                        Console.WriteLine($"[{string.Join(", ", evenNumbers.TakeLast(count))}]");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", evenNumbers)}]");
                    }

                }
            }
        }

        private static void PrintMinIndex(int[] array, string[] action)
        {
            int minNum = int.MaxValue;
            int minIndex = 0;

            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (action[1] == "even")
                {

                    if (array[i] <= minNum && array[i] % 2 == 0)
                    {
                        minNum = array[i];
                        minIndex = i;
                        isFound = true;
                    }
                }
                else if (action[1] == "odd")
                {
                    if (array[i] <= minNum && array[i] % 2 != 0)
                    {
                        minNum = array[i];
                        minIndex = i;
                        isFound = true;
                    }
                }
            }
            if (isFound)
            {
                Console.WriteLine(minIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        private static void PrintMaxIndex(int[] array, string[] action)
        {
            int maxNum = int.MinValue;
            int maxIndex = 0;

            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (action[1] == "even")
                {

                    if (array[i] >= maxNum && array[i] % 2 == 0)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                        isFound = true;
                    }
                }
                else if (action[1] == "odd")
                {
                    if (array[i] >= maxNum && array[i] % 2 != 0)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                        isFound = true;
                    }
                }
            }
            if (isFound)
            {
                Console.WriteLine(maxIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        private static void Exchange(int[] array, string[] action)
        {
            int numberOfRotations = int.Parse(action[1]);

            if (numberOfRotations > array.Length - 1 || numberOfRotations < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int rotation = 0; rotation <= numberOfRotations; rotation++)
            {
                int firstNumber = array[0];

                for (int i = 1; i < array.Length; i++)
                {
                    array[i - 1] = array[i];
                }

                array[array.Length - 1] = firstNumber;
            }

        }
    }
}
