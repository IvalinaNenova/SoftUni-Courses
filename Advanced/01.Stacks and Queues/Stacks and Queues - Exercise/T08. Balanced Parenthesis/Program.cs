using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace T08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            Stack<char> open = new Stack<char>();
            bool isBalanced = true;
            foreach (char bracket in sequence)
            {
                if (bracket == '(' || bracket == '{' || bracket == '[')
                {
                    open.Push(bracket);
                }
                else
                {
                    if (!open.Any())
                    {
                        isBalanced = false;
                        Console.WriteLine("NO");
                        break;
                    }
                    else if (bracket == ')' && open.Peek() == '(')
                    {
                        open.Pop();
                    }
                    else if (bracket == '}' && open.Peek() == '{')
                    {
                        open.Pop();
                    }
                    else if (bracket == ']' && open.Peek() == '[')
                    {
                        open.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        Console.WriteLine("NO");
                        break;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
