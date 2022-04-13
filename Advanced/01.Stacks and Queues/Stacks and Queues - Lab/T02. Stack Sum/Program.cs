using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numStack = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray());

            string inputLine = Console.ReadLine().ToLower();

            while (inputLine != "end")
            {
                string[] commands = inputLine.Split(" ");
                string action = commands[0];

                if (action == "add")
                {
                    numStack.Push(int.Parse(commands[1]));
                    numStack.Push(int.Parse(commands[2]));
                }
                else if (action == "remove")
                {
                    int numbersToRemove = int.Parse(commands[1]);
                    if (numbersToRemove <= numStack.Count)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            numStack.Pop();
                        }
                    }
                }

                inputLine = Console.ReadLine().ToLower();
            }

            int sum = numStack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
