using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace ImplementingCustomQueue
{
    public class CustomQueue<T>
    {
        //•	It should hold a sequence of items in an array.
        //•	The structure should have a capacity that grows twice when it is filled, always starting at 4. 
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;
        private const int FirstElementIndex = 0;
        public CustomQueue()
        {
            items = new T[InitialCapacity];
            count = 0;
        }

        public int Count => count;
        //The CustomQueue class should have the properties listed below:
        //•	void Enqueue(int element) – Adds the given element to the queue
        public void Enqueue(T element)
        {
            if (Count == items.Length)
            {
                IncreaseSize();
            }
            items[count] = element;
            count++;
        }

        private void IncreaseSize()
        {
            T[] newItems = new T[InitialCapacity * 2];
            items.CopyTo(newItems,0);
            items = newItems;
        }

        private void IsEmpty()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The Queue is empty!");
            }
        }

        public T Dequeue() //Removes the first element
        {
            IsEmpty();
            T element = items[FirstElementIndex];
            count--;
            ShiftElements();
            return element;
        }
        private void ShiftElements()
        {
            items[FirstElementIndex] = default(T);
            for (int i = 0; i < items.Length-1; i++)
            {
                items[i] = items[i + 1];
            }
            items[^1] = default(T);
        }
        //•	int Peek() – Returns the first element in the queue without removing it
        public T Peek()
        {
            IsEmpty();
            return items[FirstElementIndex];
        }
        
        //•	void Clear() – Delete all elements in the queue
        public void Clear()
        {
            IsEmpty();
            items = new T[InitialCapacity];
            count = 0;
        }
        //•	void ForEach(Action<int> action) – Goes through each of the elements in the queue
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }

        public override string ToString()
        {
            
            var sb = new StringBuilder();
            for (int i = 0; i < Count - 1; i++)
            {
                sb.Append(items[i] + ", ");
            }

            if (count != 0)
            {
                sb.Append(items[count - 1]);
            }
            return sb.ToString();
        }
    }
}
