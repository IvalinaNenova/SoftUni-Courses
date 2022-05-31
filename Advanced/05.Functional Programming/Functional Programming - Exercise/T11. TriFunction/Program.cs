using System;
using System.Collections.Generic;
using System.Linq;

namespace T11._TriFunction
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetNumber = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ').ToList();
            Func<string, int, bool> func = (name, target) =>
            {
                int sum = 0;
                foreach (var symbol in name)
                {
                    sum += symbol;
                    if (sum >= target)
                    {
                        return true;
                    }
                }
                return false;
            };

            string name = GetName(func, names, targetNumber);
            Console.WriteLine(name);
        }

        public static string GetName(Func<string, int, bool> func, List<string> names, int targetNumber)
        {
            foreach (var name in names)
            {
                if (func(name, targetNumber))
                {
                    return name;
                }
            }

            return null;
        }
    }
}
    

