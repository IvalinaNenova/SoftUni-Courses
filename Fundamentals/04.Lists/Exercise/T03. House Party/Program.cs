using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                List<string> command = Console.ReadLine()
                    .Split(' ')
                    .ToList();
                string name = command[0];
                if (command.Count == 3)
                {
                    if (guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(command[0]);
                    }
                }
                else
                {
                    if (guestList.Contains(name))
                    {
                        guestList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n", guestList));
        }
    }
}
