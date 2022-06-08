using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                boxes.Add(new Box<string>(item));
            }
            string itemToCompare = Console.ReadLine();
            Console.WriteLine(CompareItems(boxes, itemToCompare));
        }
        public static int CompareItems<T>(List<Box<T>> boxes, T item)
            where T : IComparable<T>
        {
            int count = 0;
            foreach (var box in boxes)
            {
                if (box.CompareTo(item) > 0) 
                {
                    count++;
                }
            }
            return count;
        }
    }
}
