using System;
using System.Collections.Generic;
using System.Linq;


namespace T04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] array = Console.ReadLine()
                .Split()
                .Select (int.Parse)
                .ToArray();

            List<int> list = array.ToList();

            int count = array.Length / 4;

            List<int> reversed = array.Take(array.Length/4).Reverse().ToList();
            reversed.AddRange(array.TakeLast(array.Length / 4).Reverse().ToList());

            list.RemoveRange(0, count);
            list.RemoveRange(list.Count - count, count);


            for (int i = 0; i < list.Count; i++)
            {
                int sum = list[i] + reversed[i];
                Console.Write(sum + " ");
            }
        }
    }
}
