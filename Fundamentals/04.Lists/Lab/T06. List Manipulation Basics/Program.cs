using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
 
            while (command != "end")
            {
                string [] action = command.Split();

                if (action[0] == "Add")
                {
                    numbers.Add(int.Parse(action[1]));
                }
                else if (action[0] == "Remove")
                {
                    numbers.Remove(int.Parse(action[1]));
                }
                else if (action[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(action[1]));
                }
                else if (action[0] == "Insert")
                {
                    numbers.Insert(int.Parse(action[2]), int.Parse(action[1]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
