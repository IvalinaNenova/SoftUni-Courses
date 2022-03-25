using System;

namespace T02.BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            double bonus = 0.0;
            int num = int.Parse(Console.ReadLine());
            if (num <= 100)
            {
                bonus = 5;
            }
            else if (num > 1000)
            {
                bonus = num * 0.1;
            }
            else
            {
                bonus = num * 0.2;
            }
            if (num % 2 == 0)
            {
                bonus += 1;
            }
            else if (num % 10 == 5)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(num + bonus);
        }
    }
}
