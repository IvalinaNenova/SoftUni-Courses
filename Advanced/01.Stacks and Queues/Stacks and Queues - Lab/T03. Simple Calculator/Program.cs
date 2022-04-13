using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> mathExpression = new Stack<string>(Console.ReadLine().Split(' ').Reverse());

            while (mathExpression.Count > 1)
            {
                int firstNumber = int.Parse(mathExpression.Pop());
                string operation = mathExpression.Pop();
                int secondNumber = int.Parse(mathExpression.Pop());

                if (operation == "-")
                {
                    mathExpression.Push((firstNumber - secondNumber).ToString());
                }
                else if (operation == "+")
                {
                    mathExpression.Push((firstNumber + secondNumber).ToString());
                }
            }

            Console.WriteLine(mathExpression.Peek());
        }
    }
}