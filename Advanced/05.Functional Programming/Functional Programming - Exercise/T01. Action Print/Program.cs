using System;
using System.Linq;

namespace T01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = Console.WriteLine;

            string[] names = Console.ReadLine().Split(' ');
            foreach (var name in names)
            {
                printName(name);
            }
        }
    }
}
