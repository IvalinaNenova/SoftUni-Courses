using System;

namespace ImplementingCustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("Iva");
            stack.Push("Marina");
            stack.Push("Ivan");
            stack.Push("Pesho");
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            stack.ForEach(Console.WriteLine);
        }
    }
}
