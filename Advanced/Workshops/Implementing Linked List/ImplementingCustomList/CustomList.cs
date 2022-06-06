using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImplementingCustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }

        //•	Resize – this method will be used to increase the internal collection's length twice.
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        //•	void Add(int element) – Adds the given element to the end of the list
        public void Add(int element)
        {
            if (items.Length == Count)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }
        //•	Shift – this method will help us to rearrange the internal collection's elements after removing one.
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < Count- 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i-1];
            }

            items[index] = default(int);
        }
        //•	Shrink – this method will help us to decrease the internal collection's length twice.
        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
        //•	int RemoveAt(int index) – Removes the element at the given index
        public int RemoveAt(int index)
        {
            if (index<0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var item = items[index];
            items[index] = default(int);
            ShiftToLeft(index);
            Count--;

            if (Count <= items.Length/4)
            {
                Shrink();
            }

            return item;
        }
        //•	bool Contains(int element) - Checks if the list contains the given element returns(True or False)
        public bool Contains(int element)
        {
           
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        //    •	void Insert(int Index, Int Item) Method - Inserts a given element at the given index.
        public void Insert(int index, int element)
        {
            if (index <0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (items.Length == Count)
            {
                Resize();
            }
            ShiftToRight(index);
            items[index] = element;
            Count++;
        }
        //    •	void Swap(int firstIndex, int secondIndex) - Swaps the elements at the given indexes
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex <0 || 
                firstIndex>= Count || 
                secondIndex<0 || 
                secondIndex>= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            (items[secondIndex], items[firstIndex]) = (items[firstIndex], items[secondIndex]);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Count-1; i++)
            {
                sb.Append(items[i] + ", ");
            }

            sb.Append(items[Count - 1]);
            return sb.ToString();
        }
    }
}
