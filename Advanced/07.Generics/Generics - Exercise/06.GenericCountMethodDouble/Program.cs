using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                double item = double.Parse(Console.ReadLine());
                boxes.Add(new Box<double>(item));
            }
            double itemToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(CompareItems<double>(boxes, itemToCompare));
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
