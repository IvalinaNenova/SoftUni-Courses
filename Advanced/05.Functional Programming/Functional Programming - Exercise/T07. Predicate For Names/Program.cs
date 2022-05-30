using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ').ToList();

            Func<string, bool> function = name => name.Length <= targetLength;

            names = names.Where(function).ToList();

            Action<List<string>> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            print(names);
        }
    }
}
