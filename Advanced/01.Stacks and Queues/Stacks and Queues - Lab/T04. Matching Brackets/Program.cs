using System;
using System.Collections;
using System.Collections.Generic;

namespace T04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> indices = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indices.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int openBracketIndex = indices.Pop();
                    int closeBracketIndex = i;

                    Console.WriteLine(expression.Substring(openBracketIndex, closeBracketIndex - openBracketIndex + 1));
                }
            }
        }
    }
}
