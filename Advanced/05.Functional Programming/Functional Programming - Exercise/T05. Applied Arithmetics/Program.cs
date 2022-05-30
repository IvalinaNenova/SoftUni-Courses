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
            Func<int, int> function = num => num;
            Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            while (command != "end")
            {
                if (command == "add")
                {
                    function = n => n + 1;
                    numbers = numbers.Select(function).ToArray();

                }
                else if (command == "multiply")
                {
                    function = n => n * 2;
                    numbers = numbers.Select(function).ToArray();

                }
                else if (command == "subtract")
                {
                    function = n => n - 1;
                    numbers = numbers.Select(function).ToArray();

                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
