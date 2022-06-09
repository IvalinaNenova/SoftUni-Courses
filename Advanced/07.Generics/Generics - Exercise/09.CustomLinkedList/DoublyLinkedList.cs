using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;

        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            Node<T> newHead = new Node<T>(element);

            if (Count == 0)
            {
                head = tail = newHead;
            }
            else
            {
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            Node<T> newTail = new Node<T>(element);

            if (Count == 0)
            {
                head = tail = newTail;
            }
            else
            {
                newTail.Previous = tail;
                tail.Next = newTail;
                tail = newTail;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;

            head = head.Next;

            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }
            Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = tail.Value;

            tail = tail.Previous;

            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }
            Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var current = head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            var node = head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }

            return array;
        }
    }
}