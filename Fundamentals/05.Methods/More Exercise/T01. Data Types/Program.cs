using System;

namespace T01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfDigit = Console.ReadLine();
            string digitAsText = Console.ReadLine();

            string multiplyerIfInt = "2";
            string multiplyerIfFloat = "1.5";
            string printChar = "$";

            if (typeOfDigit == "int")
            {
                PrintResult(digitAsText, multiplyerIfInt, typeOfDigit);
            }
            else if (typeOfDigit == "real")
            {
                PrintResult(digitAsText, multiplyerIfFloat, typeOfDigit);
            }
            else
            {
                PrintResult(digitAsText, printChar, typeOfDigit);
            }

        }

        private static void PrintResult(string digitText, string condition, string variableType)
        {

            if (variableType == "int")
            {
                int number = int.Parse(digitText);
                int a = int.Parse(condition);
                int result = number * a;
                Console.WriteLine(result);
            }
            else if (variableType == "real")
            {
                double floatNumber = double.Parse(digitText);
                double b = double.Parse(condition);
                double result = floatNumber * b;
                Console.WriteLine($"{result:f2}");
            }
            else
            {
                Console.WriteLine($"{condition}{digitText}{condition}");
            }
        }
    }
}
