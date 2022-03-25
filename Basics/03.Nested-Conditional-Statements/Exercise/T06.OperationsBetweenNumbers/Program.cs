using System;

namespace T06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double result = 0;
            string type = "";
            if (operation == "+")
            {
                result = N1 + N2;
                if (result % 2 == 0)

                {
                    type = "even";
                    Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
                }
                else
                {
                    type = "odd";
                    Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
                }
            }
            else if (operation == "-")
            {
                result = N1 - N2;
                if (result % 2 == 0)

                {
                    type = "even";
                    Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
                }
                else
                {
                    type = "odd";
                    Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
                }
            }
            else if (operation == "*")
            {
                result = N1 * N2;
                if (result % 2 == 0)

                {
                    type = "even";
                    Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
                }
                else
                {
                    type = "odd";
                    Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
                }
            }
            else if (operation == "/")
            {
                if (N2 !=0)
                {
                    result = (N1*1.0) / N2;
                    Console.WriteLine($"{N1} {operation} {N2} = {result:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
            else if (operation == "%")
            {
                if (N2 != 0)
                {
                    result = N1  % N2;
                    Console.WriteLine($"{N1} {operation} {N2} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
        }
    }
}
