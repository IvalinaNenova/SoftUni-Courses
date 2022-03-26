using System;

namespace T03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double eps = 0.000001;

            bool areEqual = Math.Abs(num1-num2) < eps;

            Console.WriteLine(areEqual);
        }
    }
}
