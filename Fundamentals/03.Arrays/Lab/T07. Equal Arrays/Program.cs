using System;
using System.Linq;

namespace T07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool areIdentical = false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
                else
                {
                    areIdentical = true;
                }
            }
            if (areIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {array1.Sum()}");
            }
        }
    }
}
