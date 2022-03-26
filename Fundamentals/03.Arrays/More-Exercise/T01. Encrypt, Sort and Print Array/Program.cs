using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            List<int> values = new List<int>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                int totalSum = 0;
               
                foreach (char letter in name)
                {
                    if (vowels.Contains(letter))
                    {
                        totalSum += (int)letter * name.Length;
                    }
                    else
                    {
                        totalSum += (int)letter / name.Length;
                    }
                }
                
                values.Add(totalSum);
            }
            values.Sort();

            Console.WriteLine(string.Join("\n", values));

        }
    }
}
