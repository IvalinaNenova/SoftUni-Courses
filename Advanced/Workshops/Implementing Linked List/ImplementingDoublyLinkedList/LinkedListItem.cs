using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingDoublyLinkedList
{
    public class LinkedListItem
    {
        public LinkedListItem Previous { get; set; }
        public LinkedListItem Next { get; set; }
        public int Value { get; set; }

        public LinkedListItem(int value)
        {
            Value = value;
        }
    }
}
