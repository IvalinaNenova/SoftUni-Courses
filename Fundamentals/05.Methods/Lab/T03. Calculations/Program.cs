using System;

namespace T03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Add(a, b);
                    break;
                case "multiply":
                    Multiply(a, b);
                    break;
                case "subtract":
                    Subtract(a, b);
                    break;
                case "divide":
                    Divide(a, b);
                    break;
            }
        }

        private static void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }

        private static void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        private static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        private static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
}
