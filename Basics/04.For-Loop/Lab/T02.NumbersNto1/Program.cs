using System;

namespace T02.NumbersNto1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = n; i>=1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
