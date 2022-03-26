using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> command = input.Split().ToList();

                int element = int.Parse(command[1]);

                if (command[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == element);
                }
                else if (command[0] == "Insert")
                {
                    int position = int.Parse(command[2]);

                    numbers.Insert(position, element);
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
