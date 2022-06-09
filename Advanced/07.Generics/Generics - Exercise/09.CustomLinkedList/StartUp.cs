using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> intList = new DoublyLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                intList.AddFirst(i + 1);
            }

            for (int i = 0; i < 5; i++)
            {
                intList.AddLast(i + 1);
            }

            intList.ForEach(x => Console.WriteLine(x + " "));

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(intList.RemoveFirst());
            }

            DoublyLinkedList<string> stringList = new DoublyLinkedList<string>();

            for (int i = 0; i < 3; i++)
            {
                stringList.AddFirst($"Gosho {i + 2}");
            }

            for (int i = 0; i < 3; i++)
            {
                stringList.AddLast($"Pesho {i + 1}");
            }

            stringList.ForEach(x => Console.WriteLine(x + " "));

            Console.WriteLine(string.Join('|', stringList.ToArray()));
            
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(stringList.RemoveFirst());
            }
        }
    }
}
