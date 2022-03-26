using System;

namespace T04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = startNum; i <= endNum; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
