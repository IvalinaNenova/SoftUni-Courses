using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var threads = new Queue<int>(input2);
            var tasks = new Stack<int>(input1);

            int taskToKill = int.Parse(Console.ReadLine());
            int thread = 0;

            while (true)
            {
                thread = threads.Peek();
                int task = tasks.Peek();

                if (task == taskToKill)
                {
                    tasks.Pop();
                    break;
                }
                else if (thread >= task && task != taskToKill)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (thread < task)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {thread} killed task {taskToKill}");
            Console.WriteLine($"{string.Join(" ", threads)}");
        }
    }
}
