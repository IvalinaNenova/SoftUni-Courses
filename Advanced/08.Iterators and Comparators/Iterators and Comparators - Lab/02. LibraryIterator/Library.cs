using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }


        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
            /*
             for (int index = 0; index < books.Count; index++) - Used to skip creating custom Iterator class.
            {
                 yield return books[index];
            }
             */
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }
            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < books.Count;
            }
            public Book Current => books[currentIndex];
            object IEnumerator.Current => Current;
            public void Reset() => currentIndex = -1;

            public void Dispose() { }
        }
    }
}