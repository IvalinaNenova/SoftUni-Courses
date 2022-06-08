using System;
using System.Collections.Generic;

namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                var box = new Box<string>(value);
                boxes.Add(box);
            }

            Swap(boxes);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        private static void Swap<T>(List<Box<T>> boxes)
        {
            string[] swapIndexes = Console.ReadLine().Split();
            int index1 = int.Parse(swapIndexes[0]);
            int index2 = int.Parse(swapIndexes[1]);

            (boxes[index1], boxes[index2]) = (boxes[index2], boxes[index1]);
        }
    }
}
