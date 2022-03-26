using System;
using System.Collections.Generic;
using System.Linq;

namespace B02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryList = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] command = input.Split();

                string action = command[0];
                string item = command[1];

                if (action == "Urgent")
                {
                    if (groceryList.Contains(item))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    groceryList.Insert(0, item);
                }
                else if (action == "Unnecessary")
                {
                    if (groceryList.Contains(item))
                    {
                        groceryList.Remove(item);
                    }
                }
                else if (action == "Correct")
                {
                    string newItem = command[2];

                    if (groceryList.Contains(item))
                    {
                        int indexToReplace = groceryList.IndexOf(item);
                        groceryList.Remove(item);
                        groceryList.Insert(indexToReplace, newItem);
                    }
                }
                else if (action == "Rearrange")
                {
                    if (groceryList.Contains(item))
                    {
                        groceryList.Remove(item);
                        groceryList.Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceryList)); 
        }
    }
}
