using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>{"Diana", "Marina", "Vania", "Hristo", "Zari"};
            StackOfStrings myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(myList);
            Console.WriteLine(myStack.Count);
            Console.WriteLine(myStack.IsEmpty());
        }
    }
}
