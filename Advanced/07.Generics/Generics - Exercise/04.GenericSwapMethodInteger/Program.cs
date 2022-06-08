using System;
using System.Collections.Generic;

namespace _04.GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                boxes.Add(new Box<int>(num));
            }
            
            Swap<Box<int>>(boxes);

            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }

        private static void Swap<T>(List<Box<int>> boxes)
        {
            string[] indices = Console.ReadLine().Split();
            int index1 = int.Parse(indices[0]);
            int index2 = int.Parse(indices[1]);

            (boxes[index1], boxes[index2]) = (boxes[index2], boxes[index1]);
        }
    }
}
