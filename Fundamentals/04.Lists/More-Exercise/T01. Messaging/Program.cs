using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            StringBuilder text = new StringBuilder(Console.ReadLine());
            StringBuilder message = new StringBuilder();

            while (numbers.Count > 0)
            {
                int sum = GetSum(numbers);
                int index = sum;

                if (index > text.Length - 1)
                {
                    //index -= text.Length;

                    for (int i = 0; i < sum; i++)
                    {
                        if (i >= text.Length - 1)
                        {
                            i = 0;
                            sum -= text.Length - 1;
                        }
                        index = i;
                    }
                }

                message.Append(text[index]);
                text.Remove(index, 1);
                numbers.RemoveAt(0);
            }
            Console.WriteLine(message);
        }

        private static int GetSum(List<int> numbers)
        {
            int number = numbers.First();
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
    }
}
