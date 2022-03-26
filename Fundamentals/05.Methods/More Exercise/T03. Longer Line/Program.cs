using System;

namespace T03._Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double line1Lenght = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double line2Lenght = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));

            if (line1Lenght>=line2Lenght)
            {
                PrintClosestTo0(x1, y1, x2, y2);
            }
            else
            {
                PrintClosestTo0(x3, y3, x4, y4);
            }
        }
        private static void PrintClosestTo0(double a, double b, double c, double d)
        {
            if (a * a + b * b <= c * c + d * d)
            {
                Console.WriteLine($"({a}, {b})({c}, {d})");
            }
            else
            {
                Console.WriteLine($"({c}, {d})({a}, {b})");
            }
        }
    }
}
