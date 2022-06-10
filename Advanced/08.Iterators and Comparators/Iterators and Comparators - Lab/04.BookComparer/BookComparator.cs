using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            int result = book1.Title.CompareTo(book2.Title);
            if (result == 0)
            {
                if (book1.Year > book2.Year)
                {
                    result = -1;
                }else if (book1.Year < book2.Year)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
