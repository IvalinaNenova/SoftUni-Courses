using System;

namespace ImplementingCustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());

        }
    }
}
