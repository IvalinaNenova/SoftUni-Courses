using System;

namespace ImplementingCustomList
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList numbers = new CustomList();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            Console.WriteLine(numbers[2]);
            numbers.Insert(0, 0);
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers.RemoveAt(1));
            numbers.Contains(5);
            numbers.Swap(0, 1);
            Console.WriteLine(numbers.ToString());

        }
    }
}
