using System;

namespace T08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = RaisedNumber(number,power);
            Console.WriteLine(result);
        }

         static double RaisedNumber(double number, double power)
        {
            double result = Math.Pow(number, power);
            return result;
        }
    }
}
