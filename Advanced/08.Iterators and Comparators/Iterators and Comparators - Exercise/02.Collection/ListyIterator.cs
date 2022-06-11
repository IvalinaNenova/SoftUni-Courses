using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int currentIndex = 0;
        public ListyIterator(List<T>list)
        {
            this.list = list.ToList();
        }

        public bool Move()
        {
            if (currentIndex + 1 < list.Count)
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return currentIndex +1 < list.Count;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
