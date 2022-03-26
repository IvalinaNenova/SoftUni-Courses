using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            List<int> result = numbers.ToList();

            string command = Console.ReadLine();
            int number = 0;

            while (command != "end")
            {
                string[] action = command.Split();
                if (action.Length>2)
                {
                    number = int.Parse(action[2]);
                }

                if (action[0] == "Add")
                {
                    result.Add(int.Parse(action[1]));
                }
                else if (action[0] == "Remove")
                {
                    result.Remove(int.Parse(action[1]));
                }
                else if (action[0] == "RemoveAt")
                {
                    result.RemoveAt(int.Parse(action[1]));
                }
                else if (action[0] == "Insert")
                {
                    result.Insert(number, int.Parse(action[1]));
                }

                else if (action[0] == "Contains")
                {

                    if (numbers.Contains(int.Parse(action[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (action[0] == "PrintEven")
                {
                    Console.WriteLine(String.Join(" ", numbers.Where(n => n % 2 == 0)));
                }
                else if (action[0] == "PrintOdd")
                {
                    Console.WriteLine(String.Join(" ", numbers.Where(n => n % 2 == 1)));
                }
                else if (action[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (action[0] == "Filter")
                {
                    if (action[1] == ">")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n > number)));
                    }
                    else if (action[1] == "<")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n < number)));
                    }
                    else if (action[1] == ">=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n >= number)));
                    }
                    else if (action[1] == "<=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n <= number)));
                    }
                }

                command = Console.ReadLine();
            }

            if (!result.SequenceEqual(numbers))
            {
                Console.WriteLine(String.Join(" ", result));
            }
        }
    }
}
