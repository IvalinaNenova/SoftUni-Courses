using System;
using System.Linq;

namespace T05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                bool isGreater = true;

                int number = array[i];
               
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (number <= array[j])
                    {
                        isGreater = false;
                        break;
                    }
                }
                if (isGreater)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
