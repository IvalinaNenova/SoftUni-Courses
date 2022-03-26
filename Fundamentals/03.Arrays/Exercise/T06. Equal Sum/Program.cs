using System;
using System.Linq;

namespace T06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false;
            int index = 0;
            if (array.Length == 1)
            {
                Console.WriteLine("0");
                return;
            }
            else
            {
                for (int middNumber = 1; middNumber < array.Length; middNumber++)
                {
                    int leftSum = 0;
                    int rightSum = 0;

                    //for (int j = 0; j < middNumber; j++)
                    //{
                    //    leftSum += array[j];
                    //}
                    //for (int k = middNumber + 1; k < array.Length; k++)
                    //{
                    //    rightSum += array[k];
                    //}
                    leftSum = array.Take(middNumber).Sum();
                    rightSum = array.TakeLast(array.Length - 1-middNumber).Sum();
                    if (rightSum == leftSum)
                    {
                        isFound = true;
                        index = middNumber;
                    }

                }
            }


            if (isFound)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
