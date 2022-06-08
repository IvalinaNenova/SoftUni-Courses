using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> internalList  = new List<T>();

        public int Count => internalList.Count;

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
//public class Box<T>
//{
//private List<T> internalList = new List<T>();

//public void Add(T item)
//{
//    internalList.Add(item);
//}

//public T Remove()
//{
//    T removedItem = internalList[internalList.Count - 1];
//    internalList.RemoveAt(internalList.Count - 1);
//    return removedItem;
//}

//public int Count => internalList.Count;

//}
