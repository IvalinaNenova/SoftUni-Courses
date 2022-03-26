using System;
using System.Linq;

namespace T04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int numberOfRotations = int.Parse(Console.ReadLine());

            //for (int i = 0; i < numberOfRotations; i++)
            //{
            //    int lastNum = inputArray[inputArray.Length - 1];

            //    for (int k = inputArray.Length - 1; k >= 1; k--)
            //    {
            //        inputArray[k] = inputArray[k - 1];

            //    }
            //    inputArray[0] = lastNum;
            //}

            //Console.WriteLine(string.Join(" ", inputArray));

            //for (int i = 0; i < numberOfRotations; i++)
            //{
            //    int firstNum = inputArray[0];

            //    for (int j = 0; j < inputArray.Length-1; j++)
            //    {
            //        inputArray[j] = inputArray[j + 1];
            //    }

            //    inputArray[inputArray.Length - 1] = firstNum;
            //}
            //Console.WriteLine(string.Join(" ", inputArray));

            string[] array = Console.ReadLine()
                .Split()
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            if (rotations >= array.Length)
            {
                rotations %= array.Length;
            }

            for (int i = 0; i < rotations; i++)
            {
                string firstElement = array[0];

                for (int j = 0; j < array.Length-1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
