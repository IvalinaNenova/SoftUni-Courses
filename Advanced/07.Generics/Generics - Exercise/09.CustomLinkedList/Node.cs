﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
