using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace T05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            while (command != "end")
            {

                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int, int> function = GetFunction(command);
                    numbers = numbers.Select(function).ToArray();
                }

                command = Console.ReadLine();
            }
        }

        public static Func<int, int> GetFunction(string command)
        {
            Func<int, int> function = n => n;

            if (command == "add")
            {
                function = n => n + 1;
            }
            else if (command == "multiply")
            {
                function = n => n * 2;
            }
            else if (command == "subtract")
            {
                function = n => n - 1;
            }

            return function;
        }
    }
}
