using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> list2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> resultList = new List<int>(list1.Count+list2.Count);

            for (int i = 0; i < Math.Min(list1.Count,list2.Count); i++)
            {
                resultList.Add(list1[i]);
                resultList.Add(list2[i]);
            }

            List<int> longerList = new List<int>();

            if (list1.Count > list2.Count)
            {
                longerList = list1;
            }
            else
            {
                longerList = list2;
            }

            int difference = Math.Abs(list1.Count - list2.Count);

            resultList.AddRange(longerList.TakeLast(difference));
            
            Console.WriteLine(String.Join(" ", resultList));
        }
    }
}
