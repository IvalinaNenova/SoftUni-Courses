using System;

namespace T02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printTitle = name => Console.WriteLine($"Sir {name}");
            string[] names = Console.ReadLine().Split(' ');
            foreach (string name in names)
            {
                printTitle(name);
            }
        }
    }
}
