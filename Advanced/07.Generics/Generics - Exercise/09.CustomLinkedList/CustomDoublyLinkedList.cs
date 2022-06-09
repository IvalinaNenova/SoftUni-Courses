using System;
using System.Collections.Generic;
using System.Text;


namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private LinkedListItem<T> first;
        private LinkedListItem<T> last;

        //public int Count // Read-only property (get only)
        //{
        //    get
        //    {
        //        var count = 0;
        //        var current = first;
        //        while (current != null)
        //        {
        //            count++;
        //            current = current.Next;
        //        }
        //        return count;
        //    }

        //}

        public int Count // Get count with recursion
        {
            get
            {
                return GetCount(first);
            }
        }
        public int GetCount(LinkedListItem<T> current)
        {
            if (current == null)
            {
                return 0;
            }
            else
            {
                return 1 + GetCount(current.Next);
            }
        }
        //•	void AddFirst(int element) – adds an element at the beginning of the collection
        public void AddFirst(T element)
        {
            var newItem = new LinkedListItem<T>(element);
            if (first == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Next = first;
                first.Previous = newItem;
                first = newItem;
            }
        }
        //•	void AddLast(int element) – adds an element at the end of the collection
        public void AddLast(T element)
        {
            var newItem = new LinkedListItem<T>(element);
            if (first == null)
            {
                first = newItem;
                last = newItem;
            }

            else
            {
                last.Next = newItem;
                newItem.Previous = last;
                last = newItem;
            }
        }
        //•	int RemoveFirst() – removes the element at the beginning of the collection
        public T RemoveFirst()
        {
            var currentFirstValue = first.Value;

            if (first == null) // 0 elements
            {
                throw new InvalidOperationException("Linked List empty!");
            }
            else if (first == last)// 1 element
            {
                first = null;
                last = null;
            }
            else//more than one element
            {
                var newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
            }

            return currentFirstValue;
        }
        //•	int RemoveLast() – removes the element at the end of the collection
        public T RemoveLast()
        {
            var currentLastElement = last.Value;

            if (last == null)
            {
                throw new InvalidOperationException("Linked List empty!");
            }
            else if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
            }

            return currentLastElement;
        }
        //•	void ForEach() – goes through the collection and executes a given action
        public void ForEach(Action<T> action)
        {
            var current = first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        //•	int[] ToArray() – returns the collection as an array
        public T[] ToArray()
        {
            var array = new T[Count];
            var current = first;

            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
    }
}
