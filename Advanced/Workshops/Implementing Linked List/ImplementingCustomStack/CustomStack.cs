using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ImplementingCustomStack
{
    public class CustomStack<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            items = new T[InitialCapacity];
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Push(T element)
        {
            if (Count == items.Length)
            {
                T[] copy = new T[items.Length*2];
                for (int i = 0; i < items.Length; i++)
                {
                    copy[i] = items[i];
                }
                items = copy;
            }
            items[Count] = element;
            count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Custom stack is empty!");
            }

            T element = items[Count-1];
            items[Count-1] = default(T);
            count--;

            return element;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Custom stack is empty!");
            }

            T element = items[Count - 1];
            return element;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
    }
}
