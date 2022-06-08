using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> internalList  = new List<T>();
       
        public int Count { get; }
        private int count = 0;

        public void Add(T element)
        {
            this.internalList.Add(element);
        }

        public T Remove()
        {
            var element = internalList[internalList.Count -1];
            internalList.RemoveAt(internalList.Count -1);
            return element;
        }
    }
}
