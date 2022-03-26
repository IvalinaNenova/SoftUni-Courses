using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                List<string> action = input
                    .Split(' ')
                    .ToList();

                int number = 0;
                int index = 0;

                string command = action[0];

                if (command == "Add")
                {
                    number = int.Parse(action[1]);
                    list.Add(number);
                }
                else if (command == "Insert")
                {
                    index = int.Parse(action[2]);
                    
                    if (IsIndexInRange(list, index))
                    {
                        number = int.Parse(action[1]);
                        list.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                }
                else if (command == "Remove")
                {
                    index = int.Parse(action[1]);

                    if (IsIndexInRange(list, index))
                    {
                        list.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                }
                else if (command == "Shift")
                {
                    string direction = action[1];
                    int count = int.Parse(action[2]);

                    for (int i = 0; i < count; i++)
                    {
                        if (direction == "left")
                        {
                            int first = list[0];
                            list.RemoveAt(0);
                            list.Add(first);
                        }
                        else if (direction == "right")
                        {
                            int last = list[list.Count - 1];
                            list.RemoveAt(list.Count - 1);
                            list.Insert(0, last);
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", list));
        }

        private static bool IsIndexInRange(List<int> list, int index)
        {
            bool isValid = true;
            if (index >= list.Count || index < 0)
            {
                isValid = false;
            }
            return isValid;
        }

    }
}
