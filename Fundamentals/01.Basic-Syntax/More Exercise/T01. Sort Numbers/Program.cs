using System;
using System.Collections.Immutable;
using System.Linq;

namespace T01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3];

            for (int i = 0; i < 3; i++)
            {
                int num = int.Parse(Console.ReadLine());
                array[i] = num;
            }
            
            Array.Sort(array);

            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
