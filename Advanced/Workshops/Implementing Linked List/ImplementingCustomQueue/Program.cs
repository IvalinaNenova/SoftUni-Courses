using System;
using System.Threading.Channels;

namespace ImplementingCustomQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> numbersQueue = new CustomQueue<int>();
            numbersQueue.Enqueue(5);
            //5
            numbersQueue.Enqueue(4);
            //5-4
            numbersQueue.Enqueue(1);
            //5-4-1
            numbersQueue.Enqueue(2);
            //5-4-1-2
            numbersQueue.Enqueue(3);
            //5-4-1-2-3
            numbersQueue.Dequeue();
            //4-1-2-3
            numbersQueue.Enqueue(numbersQueue.Dequeue());
            //1-2-3-4
            numbersQueue.Enqueue(5);
            //1-2-3-4-5
            Console.WriteLine(numbersQueue.Peek()); // 1
            numbersQueue.ForEach(num => Console.Write(num + " "));
            //1 2 3 4 5
            numbersQueue.Clear();
            //
            Console.WriteLine();
            Console.WriteLine(numbersQueue.ToString());
            //
        }
    }
}
