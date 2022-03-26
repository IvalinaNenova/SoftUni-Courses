using System;

namespace T03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = GetFibonaci(n);

            Console.WriteLine(result);
        }

        private static int GetFibonaci(int n)
        {
            if (n == 2 || n == 1)
            {
                return 1;
            }
            return GetFibonaci(n - 1) + GetFibonaci(n - 2);
        }
    }
}
