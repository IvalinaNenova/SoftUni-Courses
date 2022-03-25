using System;

namespace ExamProblem4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int S = int.Parse(Console.ReadLine());

            for (int address = M; address >= N; address--)
            {
                if (address == S && address % 2 == 0 && address % 3 == 0)
                {
                    break;
                }
                if (address % 2 == 0 && address % 3 == 0)
                {
                    Console.Write($"{address} ");
                }
            }
        }
    }
}
