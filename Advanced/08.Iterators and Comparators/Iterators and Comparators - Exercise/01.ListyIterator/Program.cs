using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace _01.ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> iterator = null;
            string input = Console.ReadLine();

            while (!input.Contains("END"))
            {
                string[] commands = input.Split(' ');
                string action = commands[0];
                switch (action)
                {
                    case "Create":
                        List<string> list = commands.Skip(1).ToList();
                        iterator = new ListyIterator<string>(list);
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }
        public static void Create(List<string> collection)
        {
            var iterator = new ListyIterator<string>(collection);
        }
    }
}
