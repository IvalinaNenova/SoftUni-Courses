using System;

namespace T09.LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int total1 = 0;
            for (int i = 0; i < n ; i++)
            {
                int num = int.Parse(Console.ReadLine());
                total1 += num;
            }
            int total2 = 0;
            for (int i = 0; i < n ; i++)
            {
                int num = int.Parse(Console.ReadLine());
                total2 += num;
            }
            int difference = Math.Abs(total1 - total2);
            if (total1==total2 )
            {
                Console.WriteLine($"Yes, sum = {total1}");
            }
            else
            {
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
