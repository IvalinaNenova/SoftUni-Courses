using System;
using System.Collections.Generic;
using System.Linq;

namespace C03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfItems = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] commands = input.Split(" - ");
                string action = commands[0];

                if (action == "Collect")
                {
                    string item = commands[1];

                    if (!listOfItems.Contains(item))
                    {
                        listOfItems.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    string item = commands[1];

                    if (listOfItems.Contains(item))
                    {
                        listOfItems.Remove(item);
                    }
                }
                else if (action == "Combine Items")
                {
                    string[] itemsToCombine = commands[1].Split(":").ToArray();

                    string oldItem = itemsToCombine[0];
                    string newItem = itemsToCombine[1];

                    if (listOfItems.Contains(oldItem))
                    {
                        int indexOfOldItem = listOfItems.IndexOf(oldItem);
                        listOfItems.Insert(indexOfOldItem+1, newItem);
                    }
                }
                else if (action == "Renew")
                {
                    string item = commands[1];

                    if (listOfItems.Contains(item))
                    {
                        listOfItems.Remove(item);
                        listOfItems.Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", listOfItems));
        }
    }
}
