using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingDoublyLinkedList
{
    public class CustomDoublyLinkedList
    {
        private LinkedListItem _first;
        private LinkedListItem _last;

        //public int Count // Read-only property (get only)
        //{
        //    get
        //    {
        //        var count = 0;
        //        var current = _first;
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
                return GetCount(_first);
            }
        }
        public int GetCount(LinkedListItem current)
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
        public void AddFirst(int element)
        {
            var newItem = new LinkedListItem(element);
            if (_first == null)
            {
                _first = newItem;
                _last = newItem;
            }
            else
            {
                newItem.Next = _first;
                _first.Previous = newItem;
                _first = newItem;
            }
        }
        //•	void AddLast(int element) – adds an element at the end of the collection
        public void AddLast(int element)
        {
            var newItem = new LinkedListItem(element);
            if (_first == null)
            {
                _first = newItem;
                _last = newItem;
            }

            else
            {
                _last.Next = newItem;
                newItem.Previous = _last;
                _last = newItem;
            }
        }
        //•	int RemoveFirst() – removes the element at the beginning of the collection
        public int RemoveFirst()
        {
            var currentFirstValue = _first.Value;

            if (_first == null) // 0 elements
            {
                throw new InvalidOperationException("Linked List empty!");
            }
            else if (_first == _last)// 1 element
            {
                _first = null;
                _last = null;
            }
            else//more than one element
            {
                var newFirst = _first.Next;
                newFirst.Previous = null;
                _first = newFirst;
            }

            return currentFirstValue;
        }
        //•	int RemoveLast() – removes the element at the end of the collection
        public int RemoveLast()
        {
            var currentLastElement = _last.Value;

            if (_last == null)
            {
                throw new InvalidOperationException("Linked List empty!");
            }
            else if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                var newLast = _last.Previous;
                newLast.Next = null;
                _last = newLast;
            }

            return currentLastElement;
        }
        //•	void ForEach() – goes through the collection and executes a given action
        public void ForEach(Action<int> action)
        {
            var current = _first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
        
        //•	int[] ToArray() – returns the collection as an array
        public int[] ToArray()
        {
            var array = new int[Count];
            var current = _first;

            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
    }
}
