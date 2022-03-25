using System;

namespace T05._Average_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                total += num;

            }
            Console.WriteLine($"{total/n:f2}");
        }
    }
}
