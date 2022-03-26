using System;

namespace T02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split();
            string[] array2 = Console.ReadLine().Split();

            foreach (var item in array1)
            {
                foreach (var element in array2)
                {
                    if (item == element)
                    {
                        Console.Write(item + " ");
                    }
                }
            }
        }
    }
}
