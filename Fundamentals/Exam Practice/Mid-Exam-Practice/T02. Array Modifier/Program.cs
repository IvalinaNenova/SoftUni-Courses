using System;
using System.Linq;

namespace T02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commands = input.Split();
                string action = commands[0];

                int index1 = 0;
                int index2 = 0;


                if (commands.Length == 3)
                {
                    index1 = int.Parse(commands[1]);
                    index2 = int.Parse(commands[2]);
                }

                if (action == "swap")
                {
                    (array[index1], array[index2]) = (array[index2], array[index1]);
                }
                else if (action == "multiply")
                {
                    array[index1] *= array[index2];
                }
                else if (action == "decrease")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i]--;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
