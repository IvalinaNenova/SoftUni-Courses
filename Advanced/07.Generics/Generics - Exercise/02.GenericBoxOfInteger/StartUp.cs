using System;

namespace _02.GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>();
                box.Value = num;
                Console.WriteLine(box.ToString());
            }
        }
    }
}
