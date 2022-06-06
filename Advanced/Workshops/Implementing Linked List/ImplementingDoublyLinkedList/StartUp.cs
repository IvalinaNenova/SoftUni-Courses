using System;

namespace ImplementingDoublyLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList list = new CustomDoublyLinkedList();
            list.AddFirst(3);
            //3
            list.AddFirst(2);
            //2-3
            list.AddFirst(1);
            //1-2-3
            list.AddLast(4);
            //1-2-3-4
            list.AddFirst(0);
            //0-1-2-3-4
            list.AddLast(100);
            //0-1-2-3-4-100
            list.RemoveFirst();
            //1-2-3-4-100
            list.RemoveLast();
            //1-2-3-4
            list.AddLast(5);
            //1-2-3-4-5
            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(", ", list.ToArray()));
            list.ForEach(x=> Console.WriteLine($"--{x}"));
            //1, 2, 3, 4, 5
        }
    }
}
