using System;

namespace T05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = SumOfFirstTwoNumbers(num1, num2);
            int finalResult = SubstractThirdNum(num3, sum);

            Console.WriteLine(finalResult);
        }

        private static int SubstractThirdNum(int num3, int sum)
        {
           return sum - num3;
        }

        private static int SumOfFirstTwoNumbers(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
