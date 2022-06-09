using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class LinkedListItem<T>
    {
        public LinkedListItem<T> Previous { get; set; }
        public LinkedListItem<T> Next { get; set; }
        public T Value { get; set; }

        public LinkedListItem(T value)
        {
            Value = value;
        }
    }
}
